using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float Damage;
    public float PlayerknockBack;
    public float EnemyKnockback;
    public GameObject Target; 
    public bool TargetInRange;

    private Player Player;
    private Rigidbody2D PlayerRB;

    public void OnAwake()
    {
        Player = FindObjectOfType<Player>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
    }

    public void DamageEnemy()
    {
        //Target.receiveDamage(Damage, Enemyknockback);
        PlayerRB.AddForce(transform.right * -1 * PlayerknockBack);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TargetInRange = true;
            Target = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        TargetInRange = false;
    }

}