using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using UnityEngine.UI;
public enum Boss
{
    ChaseScene,
    Reimu,
    Yukari
}
public class BossBehaviour : MonoBehaviour
{

    public Boss boss;
    int collisions;
    GameObject emitter;
    public int HP = 200;
    public int maxHP = 200;
    public int phasesLeft = 5;
    bool transitionPhase = true;
    bool sansMode = false;
    float spellTimer;
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
            phasesLeft -= 1;
            transitionPhase = true;
        }
        if (HP <= 0 && phasesLeft < 0)
        {
            transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;
            transform.parent.GetComponent<Rigidbody2D>().gravityScale = 4;
            transform.parent.GetComponent<CircleCollider2D>().enabled = false;
            transform.parent.GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (GameObject.Find("BossController").GetComponent<Animator>().GetBool("Battle Ongoing?"))
        {
            GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 1;
            switch (boss)
            {
                case Boss.ChaseScene:
                    break;
                case Boss.Reimu:
                    break;
                case Boss.Yukari:
                    YukariAttacks(emitter.GetComponent<DanmakuEmitter>(), phasesLeft);
                    break;
            }
            //emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
        }
        else
        {
            GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 0;
            emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
        }
    }

    void Update()
    {
        spellTimer += Time.deltaTime;
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.N))
        {
            sansMode = true;
            JSAM.AudioManager.PlaySound(JSAM.Sounds.sans);
        }
    }

    //void Update()
    //{
    //    if (GameObject.Find("BossController").GetComponent<Animator>().GetBool("Battle Ongoing?"))
    //    {
    //        GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 1;
    //        YukariAttacks(emitter.GetComponent<DanmakuEmitter>(), phasesLeft);
    //        emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
    //    }
    //    else
    //    {
    //        GameObject.Find("BossCanvas").GetComponent<CanvasGroup>().alpha = 0;
    //        emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
    //    }
    //}

    void YukariAttacks(DanmakuEmitter emitter, int phasesLeft)
    {
        // NS, S, NS, S, S, LW
        Color temp;
        ColorUtility.TryParseHtmlString("#FFAEF2", out temp);
        int phase = 6 - phasesLeft;
        switch (phase)
        {
            case 1:
                // Non-spell
                if (spellTimer >= 0.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }

                emitter.Speed = 3.5f;
                emitter.AngularSpeed = -0.5f;
                emitter.FireRate = 10f;
                emitter.Arc.Count = 8;
                emitter.Arc.ArcLength = 360;
                emitter.Arc.Radius = 0.2f;
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                    spellTimer = 0f;
                    HP = 300;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                break;
            case 2:
                // Spellcard
                if (spellTimer >= 0.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }

                emitter.Speed = 6.5f;
                emitter.AngularSpeed = -0.3f;
                emitter.FireRate = 13f;
                emitter.Arc.Count = Random.Range(1,2) * 6;
                emitter.Arc.ArcLength = 180;
                emitter.Arc.Radius = 0.2f;
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                    spellTimer = 0f;
                    HP = 250;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                if (GameObject.Find("BossController").GetComponent<SpriteRenderer>().flipX)
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                break;
            case 3:
                // Stronger non-spell
                if (spellTimer >= 0.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }

                GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                emitter.Speed = 4.5f;
                emitter.AngularSpeed = -0.3f;
                emitter.FireRate = 12f;
                emitter.Arc.Count = Random.Range(2,3)*6;
                emitter.Arc.ArcLength = 360;
                emitter.Arc.Radius = 0.2f;
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    spellTimer = 0f;
                    HP = 350;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                break;
            case 4:
                // Spellcard
                if (spellTimer >= 0.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }

                emitter.Speed = 3.5f;
                emitter.AngularSpeed = 0.2f;
                emitter.FireRate = 12f;
                emitter.Arc.Count = 8;
                emitter.Arc.ArcLength = 180;
                emitter.Arc.Radius = -1;
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                    spellTimer = 0f;
                    HP = 135;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                if (GameObject.Find("BossController").GetComponent<SpriteRenderer>().flipX)
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                break;
            case 5:
                // Spellcard
                if (spellTimer >= 0.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }
                if(spellTimer >= 1.25f)
                {
                    emitter.AngularSpeed = -0.4f;
                    emitter.FireRate = 10f;
                    emitter.Arc.Count = Random.Range(1, 2) * 6;
                    emitter.Arc.ArcLength = 180;
                    emitter.Arc.Radius = 0.2f;
                }

                if (spellTimer > -12)
                {
                    emitter.Speed = -spellTimer / 2;
                }
                else
                {
                    emitter.Speed = 6f;
                }
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                    spellTimer = 0f;
                    HP = 350;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                if (GameObject.Find("BossController").GetComponent<SpriteRenderer>().flipX)
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 180);
                }
                else
                {
                    emitter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                break;
            case 6:
                if (spellTimer >= 3.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                    transform.parent.GetComponent<Rigidbody2D>().isKinematic = true;
                    transform.parent.GetComponent<Rigidbody2D>().gravityScale = 0;
                    transform.parent.GetComponent<CircleCollider2D>().enabled = true;
                    transform.parent.GetComponent<Animator>().enabled = true;
                    GetComponent<BoxCollider2D>().enabled = true;
                    transform.parent.GetComponent<Animator>().Play("last_word");
                }
                else
                {
                    emitter.Arc.Count = 8f;
                    transform.parent.GetComponent<Rigidbody2D>().isKinematic = false;
                    transform.parent.GetComponent<Rigidbody2D>().gravityScale = 4;
                    transform.parent.GetComponent<CircleCollider2D>().enabled = false;
                    transform.parent.GetComponent<Animator>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    GameObject.Find("Main Camera").GetComponent<JSAM.PauseMenu>().canPause = false;
                }
                if (spellTimer >= 5.25f)
                {
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
                }

                if (spellTimer < 9)
                {
                    emitter.Speed = -spellTimer;
                    //emitter.AngularSpeed = -spellTimer/10;
                }
                else
                {
                    emitter.Speed = 9f;
                    //emitter.AngularSpeed = -spellTimer/10;
                }
                if (Mathf.Round(spellTimer) % 2 == 0)
                {
                    //emitter.AngularSpeed = spellTimer/10;
                }
                if (spellTimer > 15)
                {
                    spellTimer = 5.26f;
                }
                emitter.FireRate = 8f;
                emitter.Arc.ArcLength = 360+spellTimer;
                emitter.Arc.Radius = 2f;
                emitter.AngularSpeed = 0.1f;
                emitter.Speed = emitter.Speed.GetValue() * 0.525f;
                if (transitionPhase)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemySpellcardBegin);
                    GameObject.Find("BossController").GetComponent<Animator>().SetInteger("Phase", phase);
                    spellTimer = 0f;
                    HP = 1000;
                    maxHP = HP;
                    transitionPhase = false;
                    emitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
                    if (sansMode)
                    {
                        HP = HP / 10;
                    }
                }
                break;
        }
    }
}
