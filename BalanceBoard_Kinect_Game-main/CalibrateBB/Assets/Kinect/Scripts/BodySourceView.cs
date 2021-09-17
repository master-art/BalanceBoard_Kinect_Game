﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour 
{
    public BodySourceManager mBodySourceManager;
    public GameObject nJointObject;

    public static bool isInstantiate = false;
    
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<Kinect.JointType> _joints = new List<Kinect.JointType>
    {
        Kinect.JointType.HandLeft,
        Kinect.JointType.HandRight,
         Kinect.JointType.Head,
    };

    [System.Obsolete]
    void Update () 
    {
        #region Get Kinect Data
        Kinect.Body[] data = mBodySourceManager.GetData();
        if (data == null)
        {
            return;
        }
        
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
              }
                
            if(body.IsTracked)
            {
                trackedIds.Add (body.TrackingId);
            }
        }
        #endregion

        #region Delete Kinect bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        
        // First delete untracked bodies
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                //Destroy body object
                Destroy(mBodies[trackingId]);

                //Remove the body object
                mBodies.Remove(trackingId);
            }
        }
        #endregion

        #region Create Kinect bodies
        foreach (var body in data)
        {
            //if no body, skip
            if (body == null)
            {
                continue;
            }
            
            if(body.IsTracked)
            {
                //if body isn't tracked, create body
                if(!mBodies.ContainsKey(body.TrackingId))
                {
                    Debug.Log("is this also called in Kinect?" + body.TrackingId);
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }
                
                RefreshBodyObject(body, mBodies[body.TrackingId]);
            }
        }
        #endregion
    }

    private GameObject CreateBodyObject(ulong id)
    {
        //Create Body Parent
        GameObject body = new GameObject("Body:" + id);

        foreach (Kinect.JointType joint in _joints)
        {
            //Create Object
            GameObject jointObj = Instantiate(nJointObject);
            jointObj.name = joint.ToString();
            Debug.Log("is Hand Instantiate");
            isInstantiate = true;
            //Parent to body
            jointObj.transform.parent = body.transform;
        }

        return body;
    }

    [System.Obsolete]
    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {

        foreach (Kinect.JointType _joint in _joints)
        {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            //Get joint, set new position
            Transform jointObj = bodyObject.transform.Find(_joint.ToString());
            jointObj.position = targetPosition;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}