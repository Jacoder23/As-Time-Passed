using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuOrientation : MonoBehaviour
{
    CharacterController2D playerController;
    bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("KosuzuController").GetComponent<CharacterController2D>();
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
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 135);
            }
            else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 45);
            }
        }
    }
}
