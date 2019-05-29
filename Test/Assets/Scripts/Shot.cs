using UnityEngine;
using System.Collections;
using Valve.VR;


public class Shot : MonoBehaviour {
	private const float speed = 5.0f;
    private float acceleration = 0.5f;
    private float totaltime = 0f;
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Input_Sources handType;

   
    // Use this for initialization
    void Start () {
 
	}
 
	// Update is called once per frame
	void Update () {

        if(triggerAction.GetState(handType))
        {
            Debug.Log("A");

            // 自身の向きベクトル取得
            Vector3 dir = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;


            totaltime　+= Time.deltaTime;
            

            // 自身の向きに移動
            transform.position += dir * 0.5f * acceleration * Mathf.Pow(totaltime,2);
        }
        else
        {
            totaltime = 0f;
        }
       
	}
}