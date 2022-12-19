using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class Alive : MonoBehaviour, IDamagable, IKillable
{
    public float Health;
    public float MaxHealth;
    public float Speed;

    public virtual void OnAwake()
    {

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

    public void TakeDamage(float _damage)
    {
        Health -= _damage;
        if (Health <= 0) { Kill (); }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
    }
}
