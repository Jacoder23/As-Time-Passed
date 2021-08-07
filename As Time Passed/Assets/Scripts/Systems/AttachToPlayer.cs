using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{

    public GameObject ObjectToAttachTo;
    public bool changeScale;
    public bool changeRotation = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ObjectToAttachTo.transform.position;
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
