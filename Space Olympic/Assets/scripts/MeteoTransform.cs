using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoTransform : MonoBehaviour {

    // オブジェクト生成時に初速度を与えて等速直線運動をさせる
    void Start() {
        GetComponent<Rigidbody>().velocity = transform.forward;
    }

    // オブジェクトを(x, y, z)すべての成分をランダムにして回転運動をさせる
    void Update() {
        transform.Rotate(new Vector3(Random.Range(0, 180),
                                     Random.Range(0, 180),
                                     Random.Range(0, 180)
                                    ) * Time.deltaTime);
    }
}
