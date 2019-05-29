using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetObjects : MonoBehaviour {

    public GameObject targetObj;
    public float targetDistance;
    private Transform targetTrans;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        targetDistance = float.MaxValue;
        TargetDistance();
    }

    public void TargetDistance() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets) {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            Transform trans = target.transform;
            if (targetDistance > dist) {
                targetObj = target;
                targetDistance = dist;
                targetTrans = trans;
            }
        }
        
        print("最も近いターゲットの座標 : " + targetTrans.position);
        //targetObj.GetComponent<Renderer>().material.color = Color.red;
        if (Input.GetKeyDown(KeyCode.P)) {
            var aim = targetTrans.position - transform.position;
            transform.rotation = Quaternion.LookRotation(aim);
        }
    }
}
    



