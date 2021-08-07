using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using DanmakU.Fireables;

public class SpellcardController : MonoBehaviour
{
    Animator KosuzuAnimation;
    GameObject KosuzuEmitter;
    // Start is called before the first frame update
    void Start()
    {
        KosuzuAnimation = GameObject.Find("KosuzuController").GetComponent<Animator>();
        KosuzuEmitter = GameObject.Find("DanmakuEmitter");
    }

    // Update is called once per frame
    void Update()
    {
        if (KosuzuAnimation.GetBool("Fire Bullet?"))
        {
            KosuzuEmitter.SetActive(true);
        }
        else
        {
            KosuzuEmitter.SetActive(false);
        }
    }
}
