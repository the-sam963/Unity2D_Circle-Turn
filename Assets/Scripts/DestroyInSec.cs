using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSec : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 1.0f;
    void Update()
    {
        Destroy(gameObject, timeToDestroy);

    }
}
