using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using DanmakU.Fireables;
using JSAM;

public class SpellcardController : MonoBehaviour
{
    Animator KosuzuAnimation;
    GameObject KosuzuEmitter;
    public bool flying = false;
    float safeFlightTimer;
    public float spellTimer;
    bool firstTime;
    // Not a setting
    bool oscilatingEffect;
    float bulletSoundTimer;
    // Start is called before the first frame update
    void Start()
    {
        KosuzuAnimation = GameObject.Find("KosuzuController").GetComponent<Animator>();
        KosuzuEmitter = GameObject.Find("Player Emitter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.K))
        {
            if (flying && !KosuzuAnimation.GetBool("Charge Spell?") && !KosuzuAnimation.GetBool("Fire Spell?"))
            {
                KosuzuAnimation.Play("spell_charge");
            }
        }
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.K))
        {
            if (!flying && !KosuzuAnimation.GetBool("Fire Bullet?"))
            {
                spellTimer = 0.06f;
                KosuzuAnimation.Play("bullet_release");
            }
            //else
            //{
            //    KosuzuAnimation.SetBool("Fire Bullet?", true);
            //}
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.K))
        {
            if (!flying && KosuzuAnimation.GetBool("Fire Bullet?"))
            {
                spellTimer = 0f;
                firstTime = false;
            }
        }
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.L))
        {
            if (!flying)
            {
                JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLift);
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.15f;
                KosuzuAnimation.Play("float_up");
                flying = true;
                safeFlightTimer = 1f;
            }
            else
            {
                JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
                transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
                KosuzuAnimation.Play("float_down");
                flying = false;
            }
        }
        if (transform.position.y < -1.5f)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (flying && !KosuzuAnimation.GetBool("Fire Spell?") && !KosuzuAnimation.GetBool("Fire Bullet?") && !KosuzuAnimation.GetBool("Charge Spell?"))
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
                    transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
                    KosuzuAnimation.Play("float_down");
                    flying = false;
                }
            }
        }
        if (transform.position.y < -1.97f && safeFlightTimer < 0f && flying && !KosuzuAnimation.GetBool("Fire Spell?") && !KosuzuAnimation.GetBool("Fire Bullet?") && !KosuzuAnimation.GetBool("Charge Spell?"))
        {
            JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
            transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
            KosuzuAnimation.Play("float_down");
            flying = false;
        }

        if (KosuzuAnimation.GetBool("Fire Spell?"))
        {
            GetComponent<PlayerMovement>().canMove = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
            //KosuzuEmitter.SetActive(true);
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
            if (firstTime)
            {
                spellTimer = 2f;
                JSAM.AudioManager.PlaySound(JSAM.Sounds.EnemyBulletGroupSpawn);
                firstTime = false;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().AngularSpeed = 0.8f;
            }
            oscilatingEffect = !oscilatingEffect;
            if (oscilatingEffect)
            {
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Speed = 6;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().FireRate = 15f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().AngularSpeed = 0.8f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.ArcLength = 0.450f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.Count = 8f;
            }
            else
            {
                JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerLand);
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Speed = 4;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().FireRate = 20f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().AngularSpeed = 0f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.ArcLength = 360f;
                KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.Count = 16f;
            }
            //else
            //{
            //    KosuzuEmitter.GetComponent<DanmakuEmitter>().Speed = 12;
            //    KosuzuEmitter.GetComponent<DanmakuEmitter>().FireRate = 60f;
            //    KosuzuEmitter.GetComponent<DanmakuEmitter>().AngularSpeed = 0.5f;
            //    KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.ArcLength = 0.450f;
            //}
        }
        else if (KosuzuAnimation.GetBool("Fire Bullet?"))
        {
            //KosuzuEmitter.SetActive(true);
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Line.Count = 1;
            if (firstTime)
            {
                spellTimer = 0.1f;
                firstTime = false;
            }
            if (bulletSoundTimer <= 0f)
            {
                JSAM.AudioManager.PlaySound(JSAM.Sounds.PlayerBulletSpawn);
                bulletSoundTimer = 0.06f;
            }
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Speed = 15f;
            KosuzuEmitter.GetComponent<DanmakuEmitter>().FireRate = 60f;
            KosuzuEmitter.GetComponent<DanmakuEmitter>().AngularSpeed = 0f;
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.ArcLength = 0.14f;
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Arc.Count = 3f;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<PlayerMovement>().canMove = true;
            firstTime = true;
            //TODO: Fix other emitters turning off when this one is off
            //KosuzuEmitter.SetActive(false);
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
        }

        if(spellTimer < 0f)
        {
            //KosuzuEmitter.SetActive(false);
            KosuzuEmitter.GetComponent<DanmakuEmitter>().Line.Count = 0;
        }

        safeFlightTimer -= Time.deltaTime;
        spellTimer -= Time.deltaTime;
        bulletSoundTimer -= Time.deltaTime;
    }
}
