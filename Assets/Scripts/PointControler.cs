using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControler : MonoBehaviour
{   
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {   
            other.transform.position = transform.position + new Vector3(0,1,0);
        }
    }
}
