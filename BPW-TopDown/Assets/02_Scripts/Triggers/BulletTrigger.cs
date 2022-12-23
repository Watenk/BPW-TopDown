using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public float Damage;
    public GameObject BulletParticle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collidable"))
        {
            Instantiate(BulletParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(Damage);
            other.gameObject.GetComponent<Enemy>().TakeKnockback(gameObject, other.gameObject);
            Instantiate(BulletParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}