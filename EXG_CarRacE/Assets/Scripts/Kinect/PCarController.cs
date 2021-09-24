using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCarController : MonoBehaviour
{
    public enum ControlType
    {
        Keyboard,
        Balanceboard,
        Kinect
    }

    [Header("Type of Controls")]
    public static ControlType ControlTypeOption;


    [Header("RigidBody")]
    public Rigidbody carRB;

    [Header("Car Controls")]
    public float forwardAccel, reverseAccel, maxSpeed, turnStrength, gravityForce, dragOnGround;
    public float turnAccel;
    public Text ControllerType;
    private float turnInput, rightHand;
    public float curSpeed = 0;
    public Transform leftFrontW, rightFrontW;
    public float maxWheelTurn = 25f;

    [Header("For Ground Check")]
    private bool grounded;
    public LayerMask whatIsGround;
    public float groundLength = 0.5f;
    public Transform groundPoint;



    [Header("Smoke Particle")]
    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    [Header("Camera Object")]
    public GameObject NearCamera;
    public GameObject FarCamera;


    public Transform[] safePoints;


    // first, find the closest safe place
    Transform closestTransform;

    //This function is for car controlls
    public static PCarController Instance;



    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        FarCamera.SetActive(true);
        carRB.transform.parent = null;
        ControllerType.text = ControlTypeOption.ToString();
    }

    void Update()
    {
        CheckCarFlip();

        //Camera Change
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FarCamera.SetActive(true);
            NearCamera.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FarCamera.SetActive(false);
            NearCamera.SetActive(true);
        }

        //To know which controller is used to control the car on UI
        ControllerType.text = ControlTypeOption.ToString();


        //Switch case to choose the controller to control the car
        switch (ControlTypeOption)
        {
            case ControlType.Balanceboard:
                if (BoardController.CenterOfBalance.x >= -0.7 && BoardController.CenterOfBalance.x <= 0.7)
                {
                    turnInput = BoardController.CenterOfBalance.x;
                }
                break;
            case ControlType.Keyboard:
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    curSpeed -= turnAccel;
                }
                turnInput = Input.GetAxis("Horizontal");
                break;
            case ControlType.Kinect:
                rightHand = KinectControl.KinectInput.x;
                if (rightHand >= -0.99 & rightHand <= 0.99)
                {
                    if (rightHand <= -0.5 & rightHand >= -0.5)
                    {
                        curSpeed -= turnAccel;
                    }
                    turnInput = rightHand;
                }
                break;
            default:
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    curSpeed -= turnAccel;
                }
                turnInput = Input.GetAxis("Horizontal");
                break;
        }

        //If car is grounded then to make car left or right movement
        if (grounded)
        {

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        }


        leftFrontW.localRotation = Quaternion.Euler(leftFrontW.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontW.localRotation.eulerAngles.z);
        rightFrontW.localRotation = Quaternion.Euler(rightFrontW.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontW.localRotation.eulerAngles.z);

        transform.position = carRB.transform.position;

    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        //Raycast is used to check if car is on ground and if not then will bring it down
        if (Physics.Raycast(groundPoint.position, -transform.up, out hit, groundLength, whatIsGround))
        {
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;
        //Car is on ground moves forward with certain speed
        if (grounded)
        {
            carRB.drag = dragOnGround;
            carRB.AddForce(transform.forward * curSpeed);
            curSpeed += forwardAccel * Time.deltaTime;
            if (curSpeed > maxSpeed)
                curSpeed = maxSpeed;

            emissionRate = maxEmission;
        }
        else
        {
            carRB.drag = 0.1f;
            carRB.AddForce(Vector3.up * -gravityForce * 100f);
        }

        foreach (ParticleSystem partS in dustTrail)
        {
            var emissionModule = partS.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }

    //Method to check if car flips up side down or not. if does call reset method
    private void CheckCarFlip()
    {
        // You have to set up an input button in the Input manager for this!
        if (Input.GetKeyDown(KeyCode.R) || Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            // put this in a different function for general cleanliness
            ResetAICar();
        }
    }


    //Reset the car back on the track
    private void ResetAICar()
    {
        float closestDistance = 9999999999;
        Vector3 currentPos = transform.position;
        // This goes through every possible safe place and picks the best one
        foreach (Transform trans in safePoints)
        {
            float currentDistance = Vector3.Distance(currentPos, trans.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestTransform = trans;
            }
        }

        // Now we reset the car!
        transform.position = closestTransform.position;
        transform.rotation = closestTransform.rotation;
    }



}
