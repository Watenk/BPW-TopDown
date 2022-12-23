using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider HealthSlider;
    public Slider ManaSlider;

    private Player player;

    public void OnAwake()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnStart()
    {
        Player.uiUpdateHealth += UpdateHealth;
        HealthTrigger.uiUpdateHealth += UpdateHealth;
        ManaTrigger.uiUpdateMana += UpdateMana;
    }

    public void OnUpdate()
    {

    }

    public void UpdateHealth()
    {
        HealthSlider.value = player.Health;
    }

    public void UpdateMana()
    {
        ManaSlider.value = player.Mana;
    }
}
