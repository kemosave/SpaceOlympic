using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Asteroid : MonoBehaviour
{

    [SerializeField] int point = 1;
    Score score;

    [SerializeField] ParticleSystem gunParticle;//爆発演出
    [SerializeField] Transform asteroid;

    private void Start()
    {
        var gameObj = GameObject.FindWithTag("Score");//ゲームオブジェクトを検索
        score = gameObj.GetComponent<Score>();
    }

    void OnHitBullet()
    {
        GetComponent<MeshRenderer>().enabled = false;//MeshRecderコンポーネントのチェックを消して、見えなくする
        Instantiate(gunParticle,asteroid.position,asteroid.rotation);
        //gunParticle.Play();//演出を再生
        Destroy(gameObject);
    }
}