using UnityEngine; 
using System.Collections;

public class Move : MonoBehaviour
{

    [SerializeField] private Vector3 velocity;              // 移動方向
    [SerializeField] private float moveSpeed = 5.0f;        // 移動速度

    float Target;
	void Start()
	{
        //print("Thanks for buying this, if you need any support, email support@dilapidatedmeow.com. " + "Please note I cannot help with scripting related problems.");
	}

#if UNITY_EDITOR
    void Update()
	{
        Target += Time.deltaTime / 125;

        //自分の向きベクトルを取得する
        float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);

        int magnificution = 10; //速度倍率

        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得る
        velocity = Vector3.zero;

        //右シフトを押しながら移動するとき速度を10倍にする
        if (Input.GetKey(KeyCode.W)) {
            velocity = 10 * transform.forward;
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                moveSpeed = magnificution * moveSpeed;
            }
            if(Input.GetKeyUp(KeyCode.RightShift)) {
                moveSpeed = moveSpeed / magnificution;
            }
        }
        if (Input.GetKey(KeyCode.A)) {
            velocity.x -= 10;
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                moveSpeed = magnificution * moveSpeed;
            }
            if (Input.GetKeyUp(KeyCode.RightShift)) {
                moveSpeed = moveSpeed / magnificution;
            }
        }
        if (Input.GetKey(KeyCode.S)) {
             velocity = -10 * transform.forward;
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                moveSpeed = magnificution * moveSpeed;
            }
            if (Input.GetKeyUp(KeyCode.RightShift)) {
                moveSpeed = moveSpeed / magnificution;
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            velocity.x += 10;
            if (Input.GetKeyDown(KeyCode.RightShift)) {
                moveSpeed = magnificution * moveSpeed;
            }
            if (Input.GetKeyUp(KeyCode.RightShift)) {
                moveSpeed = moveSpeed / magnificution;
            }
        }
        

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整する
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0) {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込む
            transform.position += velocity;
        }

        //カメラと移動を同時に行ったとき速度の値が予期しない値にならないようにする
        if (moveSpeed < 50) {
            moveSpeed = 50.0f;
        } 

        if (moveSpeed > 500) {
            moveSpeed = 500.0f;
        }
    }
#endif
}