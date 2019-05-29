using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Starts : StartSystem
{
    public SteamVR_Action_Boolean triggerAction;
    public SteamVR_Input_Sources handType;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnHitBullet()
    {
        GameStart();

    }

}

