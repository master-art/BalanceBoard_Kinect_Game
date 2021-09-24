using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{

    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    //[SerializeField] private List<Transform> carTransformList;

    private List<CheckpointSingle> checkpointSingleList;
    private int nextCheckpointSingleIndex;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingleList = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            Debug.Log(checkpointSingleTransform);
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingleList.Add(checkpointSingle);
        }
        
            nextCheckpointSingleIndex = 0; ;
        
    }

    //Check whether player has passed thorugh the checkpoint or not if doesnot and if enter wrong one it spawn back to safe point
    public void CarThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingleList.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            // Correct checkpoint
            Debug.Log("Correct");
            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Hide();

            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingleList.Count;
           
            Debug.Log(nextCheckpointSingleIndex);
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // Wrong checkpoint
            Debug.Log("Wrong");
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSingle = checkpointSingleList[nextCheckpointSingleIndex];
            correctCheckpointSingle.Show();
            CheckpointSingle spawnCheckpointSingleZero = checkpointSingleList[0];
            if (nextCheckpointSingleIndex == 0)
            {
                GameObject.Find("CarSubset").GetComponent<PCarController>().transform.position = spawnCheckpointSingleZero.transform.position;
                GameObject.Find("CarSubset").GetComponent<PCarController>().transform.rotation = spawnCheckpointSingleZero.transform.rotation;
            }
            Debug.Log("Inside Wrong Direction" + (nextCheckpointSingleIndex - 1));
            CheckpointSingle spawnCheckpointSingle = checkpointSingleList[(nextCheckpointSingleIndex - 1)];
            GameObject.Find("CarSubset").GetComponent<PCarController>().transform.position = spawnCheckpointSingle.transform.position;
            GameObject.Find("CarSubset").GetComponent<PCarController>().transform.rotation = spawnCheckpointSingle.transform.rotation;
        }
    }


}
