using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{

    public GameObject ObjectToAttachTo;
    public bool changeScale;
    public bool changeRotation = true;
    public float xoffset;
    public float yoffset;
    public float zoffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ObjectToAttachTo.transform.position;
        Transform temp = transform;
        temp.position = new Vector3(temp.position.x + xoffset, temp.position.y + yoffset, temp.position.z + zoffset);
        transform.position = temp.position;
        if (changeRotation)
        {
            transform.localRotation = ObjectToAttachTo.transform.localRotation;
        }
        if (changeScale)
        {
            transform.localScale = ObjectToAttachTo.transform.localScale;
        }
    }
}
