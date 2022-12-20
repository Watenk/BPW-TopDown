using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            Instantiate(BulletParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}