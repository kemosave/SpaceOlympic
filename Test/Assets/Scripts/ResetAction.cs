using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ResetAction : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean triggerAction;

    private GameObject resetButton = null;

    public List<Vector3> pinStartPos;
    public List<Quaternion> pinStartRot;

    public List<Vector3> ballStartPos;
    public List<Quaternion> ballStartRot;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins)
        {
            pinStartPos.Add(pin.transform.position);
            pinStartRot.Add(pin.transform.rotation);
        }

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            ballStartPos.Add(ball.transform.position);
            ballStartRot.Add(ball.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerAction.GetStateDown(handType) && resetButton != null)
        {
            Debug.Log("Reset!");
            GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");

            for (int i=0; i < pins.Length; i++)
            {
                pins[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                pins[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                pins[i].transform.position = pinStartPos[i];
                pins[i].transform.rotation = pinStartRot[i];
            }

            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

            for (int i=0; i < balls.Length; i++)
            {
                balls[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                balls[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
                balls[i].transform.position = ballStartPos[i];
                balls[i].transform.rotation = ballStartRot[i];
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reset")
        {
            Debug.Log("Touching reset button!");
            resetButton = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (resetButton != null && resetButton.tag == "Reset")
        {
            Debug.Log("Not touching reset button!");
            resetButton = null;
        }
    }
}
