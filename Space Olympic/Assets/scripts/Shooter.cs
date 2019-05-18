using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject bulletPrefabs;  //弾丸のプレハブ
    [SerializeField] Transform gunBarrelEnd;    //銃口位置

    [SerializeField] ParticleSystem gunParticle;    //発射時の演出
    [SerializeField] AudioSource gunAudioSource;    //発射音の音源

    // Update is called once per frame
#if UNITY_EDITOR
    void Update() {
        //enterが押されたとき発砲する
        if (Input.GetKeyDown(KeyCode.Return)) {
            Shoot();
        }
    }
#endif

    void Shoot() {
        //弾丸プレハブを元に戻し、シーン上に再生成
        Instantiate(bulletPrefabs, gunBarrelEnd.position, gunBarrelEnd.rotation);

        //発射時に演出を再生する
        gunParticle.Play();

        //発射時に音声を再生する
        gunAudioSource.Play();
    }
}
