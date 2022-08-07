using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    [SerializeField] GameObject player;
        Vector3 DefaultScale;

    private void Start()
    {
        DefaultScale = player.gameObject.transform.localScale;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
           
           player.transform.parent.parent = transform;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.gameObject.transform.localScale = DefaultScale;
            player.transform.parent.parent = null;
        }
    }
    
}
