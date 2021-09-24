using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("ThemeMusic");
    }

    public void PlayScene()
    {
        PCarController.ControlTypeOption = PCarController.ControlType.Keyboard;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void KinectScene()
    {
        PCarController.ControlTypeOption = PCarController.ControlType.Kinect;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NBBScene()
    {
        PCarController.ControlTypeOption = PCarController.ControlType.Balanceboard;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
