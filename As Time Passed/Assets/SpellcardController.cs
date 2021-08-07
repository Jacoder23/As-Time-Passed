using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmakU;
using DanmakU.Fireables;

public class SpellcardController : MonoBehaviour
{
    Animator KosuzuAnimation;
    GameObject KosuzuEmitter;
    public bool flying = false;
    float safeFlightTimer;
    // Start is called before the first frame update
    void Start()
    {
        KosuzuAnimation = GameObject.Find("KosuzuController").GetComponent<Animator>();
        KosuzuEmitter = GameObject.Find("Danmaku Emitter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.K))
        {
            if (flying)
            {
                transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
                KosuzuAnimation.Play("spell_charge");
                flying = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!flying)
            {
                transform.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                KosuzuAnimation.Play("float_up");
                flying = true;
                safeFlightTimer = 1f;
            }
        }
        if (transform.position.y < -1.5f)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (flying)
                {
                    transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
                    KosuzuAnimation.Play("float_down");
                    flying = false;
                }
            }
        }
        if (transform.position.y < -1.97f && safeFlightTimer < 0f && flying)
        {
            transform.GetComponent<Rigidbody2D>().gravityScale = 4f;
            KosuzuAnimation.Play("float_down");
            flying = false;
        }

        if (KosuzuAnimation.GetBool("Fire Bullet?"))
        {
            KosuzuEmitter.SetActive(true);
        }
        else
        {
            KosuzuEmitter.SetActive(false);
        }

        safeFlightTimer -= Time.deltaTime;
    }
}
