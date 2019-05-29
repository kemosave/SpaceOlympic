using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f;   //回転角度
    float horizontalAngle = 0f; //水平方向の回転量を保存しておく
    float verticalAngle = 0f;   //垂直方向の回転量を保存しておく

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
#if UNITY_EDITOR
    void Update() {
        //矢印キーからの入力による回転量を取得
        if (Input.GetKey(KeyCode.UpArrow)) {
            var horizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
            var verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;


            //回転量を更新
            horizontalAngle += horizontalRotation;
            verticalAngle += verticalRotation;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            var horizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
            var verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;


            //回転量を更新
            horizontalAngle += horizontalRotation;
            verticalAngle += verticalRotation;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            var horizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
            var verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;


            //回転量を更新
            horizontalAngle += horizontalRotation;
            verticalAngle += verticalRotation;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            var horizontalRotation = Input.GetAxis("Horizontal") * angularVelocity * Time.deltaTime;
            var verticalRotation = Input.GetAxis("Vertical") * angularVelocity * Time.deltaTime;


            //回転量を更新
            horizontalAngle += horizontalRotation;
            verticalAngle += verticalRotation;
        }

        //transformに回転量を適応する
        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
    }
#endif
}
