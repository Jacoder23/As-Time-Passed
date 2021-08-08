using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;

public class DoorController : MonoBehaviour
{
    int collisions;
    void Start()
    {
        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        Debug.Log("Door collided with Danmaku bullet");

        foreach (DanmakuCollision i in collisionList)
        {
            collisions += 1;
            i.Danmaku.Destroy();
        }
    }

    void FixedUpdate()
    {
        if(collisions >= 10)
        {
            GameObject.Find("BossController").GetComponent<Animator>().SetBool("Battle Ongoing?", true);
            GetComponent<Rigidbody2D>().gravityScale = 4;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        collisions = 0;
    }
}
