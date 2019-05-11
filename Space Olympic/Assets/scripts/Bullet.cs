using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour { 
    [SerializeField] float speed = 20f; //弾速 [m/s]

    // Start is called before the first frame update
    void Start() {
        //ゲームオブジェクトの前方向へのベクトルを計算
        var velocity = speed * transform.forward;

        //Rigidbodyコンポーネントを取得
        var rigidbody = GetComponent<Rigidbody>();

        //Rigidbodyを使って弾丸に初速を与える
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
