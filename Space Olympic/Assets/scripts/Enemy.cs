using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Collider enemyCollider;
    [SerializeField] Renderer enemyRenderer;
    [SerializeField] int point = 1;
    Score score;

    private void Start()
    {
        var gameObj = GameObject.FindWithTag("Score");//ゲームオブジェクトを検索
        score = gameObj.GetComponent<Score>();
    }

    void OnHitBullet()
    {
        score.AddScore(point);
        Destroy(gameObject);
    }
}
