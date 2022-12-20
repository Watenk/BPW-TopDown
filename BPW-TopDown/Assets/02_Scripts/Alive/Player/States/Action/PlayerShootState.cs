using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootState : BaseState
{
    public GameObject Bullet;
    public GameObject BulletSpawn;
    public float ShootCooldown;
    public float ShootSpeed;
    public float SuperAttackBulletAmount;
    public float SuperAttackCooldown;

    private GameObject player;
    private float shootCooldownTimer;
    private float superAttackTimer;

    public override void OnAwake()
    {
        base.OnAwake();
        player = GetComponent<Player>().gameObject;
    }

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        if (Input.GetMouseButton(0) && shootCooldownTimer <= 0)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;

            Vector3 bulletSpawnPos = Camera.main.WorldToScreenPoint(BulletSpawn.transform.position);
            mousePos.x -= bulletSpawnPos.x;
            mousePos.y -= bulletSpawnPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));

            GameObject currentBullet = Instantiate(Bullet, BulletSpawn.transform.position, bulletRotation);
            currentBullet.GetComponent<Rigidbody2D>().velocity = currentBullet.transform.up * ShootSpeed;

            shootCooldownTimer = ShootCooldown;
        }

        if (shootCooldownTimer >= 0) { shootCooldownTimer -= Time.deltaTime; }

        if (Input.GetKeyDown("q") && superAttackTimer <= 0)
        {
            Quaternion bulletRotation;
            float iRotation = 360 / SuperAttackBulletAmount;
            float currentRotation = 0;

            for (int i = 0; i < SuperAttackBulletAmount; i++)
            {
                currentRotation += iRotation;
                bulletRotation = Quaternion.Euler(new Vector3(0f, 0f, currentRotation));
                GameObject currentBullet = Instantiate(Bullet, BulletSpawn.transform.position, bulletRotation);
                currentBullet.GetComponent<Rigidbody2D>().velocity = currentBullet.transform.up * ShootSpeed;
            }
        }

        if (superAttackTimer >= 0) { superAttackTimer -= Time.deltaTime; }
    }

    public override void OnExit()
    {
    }
}
