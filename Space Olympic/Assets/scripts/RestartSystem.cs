using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartSystem : MonoBehaviour {

    //　リスタートボタンを押したらスタート画面に遷移する
    public void GameRestart()
    {
        SceneManager.LoadScene("CountdownActivity");
    }
}


