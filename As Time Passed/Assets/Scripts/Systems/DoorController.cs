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
        //Debug.Log("Door collided with Danmaku bullet");
        
        foreach (DanmakuCollision i in collisionList)
        {
            JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemyHitByBullet);
            collisions += 1;
            i.Danmaku.Destroy();
        }
    }

    void FixedUpdate()
    {
        if(collisions >= 9)
        {
            GameObject.Find("BossController").GetComponent<Animator>().SetBool("Battle Ongoing?", true);
            GetComponent<Rigidbody2D>().gravityScale = 4;
            StartCoroutine(DeleteCollider2D());
        }
        collisions = 0;
    }

    IEnumerator DeleteCollider2D()
    {
        if (JSAM.AudioManager.IsSoundPlaying(JSAM.Sounds.Explosion))
        {
            JSAM.AudioManager.PlaySound(JSAM.Sounds.Explosion);
        }
        yield return new WaitForSeconds(0.3f);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
