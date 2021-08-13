﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int collisions;
    public int HP = 4;
    int maxHP = 4;
    float invincibilityTimer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DanmakuCollider>().OnDanmakuCollision += OnDanmakuCollision;
    }

    void LateUpdate()
    {
        if (invincibilityTimer <= 0f)
        {
            GameObject.Find("KosuzuController").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GameObject.Find("KosuzuController").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        invincibilityTimer -= Time.deltaTime;
    }

    void OnDanmakuCollision(DanmakuCollisionList collisionList)
    {
        if (transform.parent.GetComponent<SpellcardController>().spellTimer < 0f)
        {
            //Debug.Log("Player collided with Danmaku bullet");
            //Debug.Log(collisionList[0].ToString());

            foreach (DanmakuCollision i in collisionList) {
                if (i.Danmaku.Pool.Capacity != 1000 && invincibilityTimer <= 0f)
                {
                    JSAM.AudioManager.PlaySound(JSAM.Sounds.Explosion);
                    collisions += 1;
                    HP -= 1;
                    i.Danmaku.Destroy();
                    invincibilityTimer = 3f;
                }
            }
            GameObject.Find("PlayerHPSlider").GetComponent<Image>().fillAmount = (float)HP / (float)maxHP;
        }
    }
}