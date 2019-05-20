using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]

public class Countdown : MonoBehaviour
{
    float gameTime = 3.0f; //ゲーム開始までの時間
    Text uiText;//UITextコンポーネント
    float currentTime;//残り時間タイマー

    // Start is called before the first frame update
    void Start() {
        uiText = GetComponent<Text>(); //Textコンポーネント取得
        currentTime = gameTime;//残り時間を設定

    }

    // Update is called once per frame
    void Update() {
        currentTime -= Time.deltaTime;  //残り時間を計算
        if (currentTime <= 0.0f)    //0秒以下にはならない
        {
            currentTime = 0.0f;
        }
        uiText.text = string.Format("ゲーム開始まで:{0:F}", currentTime);    //残り時間テキスト更新

        if (!IsCountingDown()) {
            SceneManager.LoadScene("SpaceOlympicActivity");
        }

    }
    public bool IsCountingDown()    //カウントダウンを行っているか
    {
        return currentTime > 0.0f;  //カウンターが0でないなら、カウント中
    }
}
