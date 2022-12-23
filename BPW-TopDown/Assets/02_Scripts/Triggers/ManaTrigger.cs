using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ManaTrigger : MonoBehaviour
{
    public delegate void UIUpdateMana();
    public static event UIUpdateMana uiUpdateMana;
    public float ManaAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.Mana += ManaAmount;

            uiUpdateMana();

            Destroy(gameObject);
        }
    }
}