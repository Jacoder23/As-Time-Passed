using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuOrientation : MonoBehaviour
{
    CharacterController2D playerController;
    Animator animationController;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("KosuzuController").GetComponent<CharacterController2D>();
        animationController = GameObject.Find("KosuzuController").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = playerController.m_FacingRight;
        if (facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (!animationController.GetBool("Charge Spell?") && !animationController.GetBool("Fire Spell?"))
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    //transform.localRotation = Quaternion.Euler(0, 0, 135);
                    transform.localRotation = Quaternion.Euler(0, 0, 30);
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    //transform.localRotation = Quaternion.Euler(0, 0, 45);
                    transform.localRotation = Quaternion.Euler(0, 0, 150);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 270);

                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    //transform.localRotation = Quaternion.Euler(0, 0, 225);
                    transform.localRotation = Quaternion.Euler(0, 0, -30);
                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    //transform.localRotation = Quaternion.Euler(0, 0, -45);
                    transform.localRotation = Quaternion.Euler(0, 0, 210);
                }
            }
        }
    }
}
