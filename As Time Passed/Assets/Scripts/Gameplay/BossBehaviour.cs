using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    int collisions;
    GameObject emitter;
    public int HP = 300;
    public int maxHP = 300;
    // DanmakuCollision bossProjectile;

    void Start()
    {
        // bossProjectile = GameObject.Find("Boss Danmaku Prefab").GetComponent<DanmakuPrefab>().gameObject;
        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;

        emitter = GameObject.Find("Boss Emitter");
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        //Debug.Log("Boss collided with Danmaku bullet");
        foreach (DanmakuCollision i in collisionList)
        {
            if (i.Danmaku.Pool.Capacity != 2000)
            {
                JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemyHitByBullet);
                collisions += 1;
                HP -= 1;
                i.Danmaku.Destroy();
            }
        }
        GameObject.Find("BossHPSlider").GetComponent<Image>().fillAmount = (float)HP/(float)maxHP;
    }

    void FixedUpdate()
    {
        if (HP <= 0)
        {
            transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 4;
            transform.parent.GetComponent<CircleCollider2D>().enabled = false;
            transform.parent.GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Update()
    {
        if (GameObject.Find("BossController").GetComponent<Animator>().GetBool("Battle Ongoing?"))
        {
            GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 1;
            emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
        }
        else
        {
            GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 0;
            emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
        }
    }
}
