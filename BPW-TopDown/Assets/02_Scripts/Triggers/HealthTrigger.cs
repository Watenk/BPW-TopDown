using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    public delegate void UIUpdateHealth();
    public static event UIUpdateHealth uiUpdateHealth;
    public float HealAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player.Health <= player.MaxHealth - HealAmount)
            {
                player.Health += HealAmount;
                uiUpdateHealth();
            }

            Destroy(gameObject);
        }
    }
}