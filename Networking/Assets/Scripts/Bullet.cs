using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ping");
        Debug.Log(collision.ToString());
        Debug.Log(collision.gameObject.name);
        Debug.Log("-x-");
        var hit = collision.gameObject;
        var health = hit.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
            Debug.Log("destroying bullet");
        }
        Destroy(gameObject);
    }
}
