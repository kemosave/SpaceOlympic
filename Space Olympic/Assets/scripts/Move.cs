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

	void Update()
	{
        Target += Time.deltaTime / 125;

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.01f);

        //自分の向きベクトルを取得する
        float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);

        // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            velocity = transform.forward;
        if (Input.GetKey(KeyCode.A))
            velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            velocity = -transform.forward;
        if (Input.GetKey(KeyCode.D))
            velocity.x += 1;

        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // いずれかの方向に移動している場合
        if (velocity.magnitude > 0)
        {
            // プレイヤーの位置(transform.position)の更新
            // 移動方向ベクトル(velocity)を足し込みます
            transform.position += velocity;
        }
    }
}