using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControler : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    
}
