using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCarController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody carRB;

    public float forwardAccel = 3f, reverseAccel = 4f, maxSpeed = 10f, turnStrength = 180, gravityForce = 10f, dragOnGround = 3f;

    private float speedInput, turnInput, leftTarget, rightTarget;

    private bool grounded;

    public LayerMask whatIsGround;
    public float groundLength = 0.5f;
    public Transform groundPoint;

    public Transform leftFrontW, rightFrontW;
    public float maxWheelTurn = 25f;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;
    float x;


    //This function is for car controlls
    public static PCarController Instance;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //WiiController.Instance.allowSending = true;

        carRB.transform.parent = null;

    }

    //public float Inputfunction()
    //{
    //    if(leftTarget > 0)
    //    {
    //        return x = leftTarget;
    //    }
    //    {
    //      return  x = rightTarget;
    //    }

    //}

    // Update is called once per frame
    void Update()
    {

#if !UNITY_EDITOR
       turnInput = BoardController.CenterOfBalance.x;
#else
        turnInput = Input.GetAxis("Horizontal");
        //turnInput = BoardController.CenterOfBalance.x;
#endif

        // turnInput = Input.GetAxis("Horizontal");
        Debug.Log("Right and LEft key value" + turnInput);
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

        if (Physics.Raycast(groundPoint.position, -transform.up, out hit, groundLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;

        if (grounded)
        {
            carRB.drag = dragOnGround;
            carRB.AddForce(transform.forward * forwardAccel * 1000f);
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
}
