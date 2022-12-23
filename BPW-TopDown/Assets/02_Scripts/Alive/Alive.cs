using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class Alive : MonoBehaviour, IDamagable, IKillable
{
    public float Health;
    public float MaxHealth;
    public float Speed;
    public float Knockback;
    public int KillScore;
    public GameObject DieParticle;

    protected GameManager gameManager;

    public virtual void OnAwake()
    {
        gameManager= FindObjectOfType<GameManager>();
    }

    public virtual void OnStart()
    {
        Health = MaxHealth;
    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {

    }

    public virtual void TakeDamage(float _damage)
    {
        Health -= _damage;
        if (Health <= 0) { Kill (); }
    }

    public virtual void Kill()
    {
        gameManager.AddScore(KillScore);
        Instantiate(DieParticle, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void TakeKnockback(GameObject object1, GameObject object2)
    {
        Vector2 distanceObject1Vector = object1.transform.position - object2.transform.position;
        Vector2 distanceObject1 = distanceObject1Vector.normalized * Knockback;

        Vector2 distanceObject2Vector = object2.transform.position - object1.transform.position;
        Vector2 distanceObject2 = distanceObject2Vector.normalized * Knockback;

        object1.GetComponent<Rigidbody2D>().AddForce(distanceObject1, ForceMode2D.Impulse);
        object2.GetComponent<Rigidbody2D>().AddForce(distanceObject2, ForceMode2D.Impulse);
    }
}
