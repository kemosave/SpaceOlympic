using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour {

    //スタートボタンを押したら実行する
    public void GameStart()
    {
        SceneManager.LoadScene("CountDownActivity");
    }
}


