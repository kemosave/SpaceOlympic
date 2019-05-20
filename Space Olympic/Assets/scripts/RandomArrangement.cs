using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrangement : MonoBehaviour {

    [SerializeField] GameObject targetGameObject;   //ランダム生成を行うオブジェクト
    [SerializeField] int objectQuantity = 30;    //生成するオブジェクトの数
    [SerializeField] float MinRange = -100;    //最小の初期座標
    [SerializeField] float MaxRange = 100;    //最大の初期座標

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i <= objectQuantity; i++) {
            Instantiate(targetGameObject, new Vector3(Random.Range(MinRange, MaxRange),
                  Random.Range(MinRange, MaxRange),
                  Random.Range(MinRange, MaxRange)),
                  Quaternion.Euler(Random.Range(0, 180),
                                   Random.Range(0, 180),
                                   Random.Range(0, 180)));
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
