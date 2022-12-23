using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : Oscar
{
    public Slider HealthBar;
    public GameObject Bat;
    public int SummonAmount;
    public float SummonHealthAmount;
    public int SummonOffset;

    private bool SummonedEnemys;

    public override void OnAwake()
    {
        base.OnAwake();
    }

    public override void OnStart()
    {
        base.OnStart();

        HealthBar.maxValue = MaxHealth;
        HealthBar.value = Health;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        SummonEnemys();
    }

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);

        UpdateHealthSlider();
    }

    public override void Kill()
    {
        base.Kill();
        SceneManager.LoadScene("Win");
    }

    private void UpdateHealthSlider()
    {
        HealthBar.value = Health;
    }

    private void SummonEnemys()
    {
        if (Health <= SummonHealthAmount && SummonedEnemys == false)
        {
            SummonedEnemys = true;

            for (int i = 0; i < SummonAmount; i++)
            {
                Vector2 summonLocation = new Vector2(gameObject.transform.position.x + Random.Range(-SummonOffset, SummonOffset), gameObject.transform.position.y + Random.Range(-SummonOffset, SummonOffset));
                GameObject currentEnemy = Instantiate(Bat, summonLocation, Quaternion.identity);
            }
        }
    }
}
