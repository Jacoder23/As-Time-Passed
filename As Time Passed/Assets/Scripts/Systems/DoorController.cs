using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    int collisions;
    int everyother;
    float timer;
    bool spellFire;
    bool donealready = false;
    public bool doaflip;
    void Start()
    {
        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;
    }

    //void LateUpdate()
    //{
    //    timer += Time.deltaTime;
    //    if(timer > 0f)
    //    {
    //        collisions = 0;
    //    }
    //}

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {

        foreach (DanmakuCollision i in collisionList)
        {
            JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemyHitByBullet);
            collisions += 1;
            i.Danmaku.Destroy();
        }
    }

    //void OnDanmakuCollision(DanmakuCollisionList collisionList)
    //{
    //    //Debug.Log("Door collided with Danmaku bullet");

    //    foreach (DanmakuCollision i in collisionList)
    //    {
    //        JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemyHitByBullet);
    //        collisions += 1;
    //        i.Danmaku.Destroy();
    //    }
    //    //GameObject.Find("DoorHPSlider").GetComponent<Image>().fillAmount = (float)collisions / (float)30;
    //}

    //void FixedUpdate()
    //{
    //    everyother += 1;
    //    if (everyother > 5)
    //    {
    //        if (!spellFire)
    //        {
    //            spellFire = GameObject.Find("KosuzuController").GetComponent<Animator>().GetBool("Fire Spell?");
    //        }
    //        else
    //        {
    //            spellFire = true;
    //        }
    //        if (collisions >= 5)
    //        {
    //            if (spellFire)
    //            {
    //                GameObject.Find("BossController").GetComponent<Animator>().SetBool("Battle Ongoing?", true);
    //                GetComponent<Rigidbody2D>().gravityScale = 4;
    //                StartCoroutine(DeleteCollider2D());
    //            }
    //        }
    //        else
    //        {
    //            GameObject.Find("DoorHPSlider").GetComponent<Image>().fillAmount = (float)collisions / (float)30;
    //        }
    //        everyother = 0;
    //        collisions = 0;
    //    }
    //}

    void Update()
    {
        if (GameObject.Find("KosuzuController") != null)
        {
            if (GameObject.Find("KosuzuController").transform.position.x > transform.position.x)
            {
                //JSAM.AudioManager.PlayMusic(JSAM.Music.YukariTheme);
                if (GameObject.Find("BossController") != null)
                {
                    GameObject.Find("BossController").GetComponent<Animator>().SetBool("Battle Ongoing?", true);
                }
                GetComponent<Rigidbody2D>().gravityScale = 4;
                if (doaflip)
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                }
                StartCoroutine(DeleteCollider2D());
            }
        }
    }

    IEnumerator DeleteCollider2D()
    {
        if(GameObject.Find("Main Camera").GetComponent<JSAM.PauseMenu>() != null) {
        GameObject.Find("Main Camera").GetComponent<JSAM.PauseMenu>().disabledMusic = false;
        GameObject.Find("Main Camera").GetComponent<JSAM.PauseMenu>().canPause = true;
        }
        if (!donealready)
        {
            JSAM.AudioManager.CrossfadeMusic(GameObject.Find("Main Camera").GetComponent<JSAM.PauseMenu>().previousMusic, 0.5f);
            donealready = true;
        }
        yield return new WaitForSeconds(0.3f);
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(GameObject.Find("DoorHPSlider"));
    }
}
