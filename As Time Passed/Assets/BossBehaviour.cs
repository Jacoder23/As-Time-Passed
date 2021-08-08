using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;

public class BossBehaviour : MonoBehaviour
{
    int collisions;
    GameObject emitter;
    // DanmakuCollision bossProjectile;

    void Start()
    {
        // bossProjectile = GameObject.Find("Boss Danmaku Prefab").GetComponent<DanmakuPrefab>().gameObject;
        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;

        emitter = GameObject.Find("Boss Emitter");
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        Debug.Log("Boss collided with Danmaku bullet");

        foreach (DanmakuCollision i in collisionList)
        {
            if (i.Danmaku.Pool.Capacity != 2000)
            {
                collisions += 1;
                i.Danmaku.Destroy();
            }
        }
    }

    void FixedUpdate()
    {
        if (collisions >= 30)
        {
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
            emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
        }
        else
        {
            emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
        }
    }
}
