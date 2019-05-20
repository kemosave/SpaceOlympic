using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Asteroid : MonoBehaviour
{
    [SerializeField] ParticleSystem gunParticle;//爆発演出
    [SerializeField] Transform asteroid;    //隕石の位置

    private void Start() {

    }

    void OnHitBullet() {
        GetComponent<MeshRenderer>().enabled = false;   //MeshRecderコンポーネントのチェックを消して、見えなくする
        Instantiate(gunParticle,asteroid.position,asteroid.rotation);   //パーティクルを隕石オブジェクトの位置に設定する
        Destroy(gameObject);
    }
}