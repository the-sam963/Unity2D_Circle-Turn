using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(other.gameObject);
    }
}
