using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject bulletPrefabs;  //弾丸のプレハブ
    [SerializeField] Transform gunBarrelEnd;    //銃口位置

    // Update is called once per frame
    void Update() {
        //enterが押されたとき発砲する
        if (Input.GetKeyDown(KeyCode.Return)) {
            Shoot();
        }
    }

    void Shoot() {
        //弾丸プレハブを元に戻し、シーン上に再生成
        Instantiate(bulletPrefabs, gunBarrelEnd.position, gunBarrelEnd.rotation);
    }
}
