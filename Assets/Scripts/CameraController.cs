using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    Vector3 offset ;
    void Start()
    {
        
        offset = transform.position - target.transform.position;
    }

   
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + offset;
        }
       
    }
}
