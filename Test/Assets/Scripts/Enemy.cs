using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int point = 1;             //倒したときに得るスコア
    Score score;                                //スコア

    [SerializeField] ParticleSystem gunParticle;    //爆発演出
    [SerializeField] Transform target;  //ターゲットの位置

    private void Start() {
        var gameObj = GameObject.FindWithTag("Score");  //ゲームオブジェクトを検索
        score = gameObj.GetComponent<Score>();  //gameObjに含まれるScoreコンポーネントを取得
    }

    //命中時処理
    void OnHitBullet() {
        score.AddScore(point);  //スコアを加算する
        GetComponent<MeshRenderer>().enabled = false;   //MeshRecderコンポーネントのチェックを消して、見えなくする
        Instantiate(gunParticle, target.position, target.rotation); //パーティクルをターゲットの位置に設定する
        Destroy(gameObject);
    }
}
