using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour
{
    Text uiText;    //UITextコンポーネント
    public int Points { get; private set; } //現在のスコアポイント

    // Start is called before the first frame update
    void Start() {
        uiText = GetComponent<Text>();
    }

    public void AddScore(int addPoint) {
        Points += addPoint; //現在のポイントに加算
        uiText.text = string.Format("得点：{0:D3}点", Points);  //得点の更新
    }

    // Update is called once per frame
    void Update() {
        
    }
}
