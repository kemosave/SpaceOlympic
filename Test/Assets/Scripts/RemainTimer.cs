using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Text))]

public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gameTime = 30.0f; //ゲーム制限時間
    Text uiText;//UITextコンポーネント
    float currentTime;//残り時間タイマー
    
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>(); //Textコンポーネント取得
        currentTime = gameTime;//残り時間を設定

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;  //残り時間を計算
        if (currentTime <= 0.0f)    //0秒以下にはならない
        {
            currentTime = 0.0f;
        }
        uiText.text = string.Format("残り時間:{0:F}秒", currentTime);    //残り時間テキスト更新

        if (!IsCountingDown()) {
            SceneManager.LoadScene("RestartActivity");
        }
        
    }
    public bool IsCountingDown()    //カウントダウンを行っているか
    {
        return currentTime > 0.0f;  //カウンターが0でないなら、カウント中
    }
}
