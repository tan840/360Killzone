using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform bulletSpawnLocation;
    public float fireRate = 2f;
    public float fireSpeed = 5;
    public GameObject machineGun;
    public GameObject gun;

    public bool machinGunActive;
    public Bullet bullet;

    public Transform[] machineGunLocation;

    public void Start()
    {
        gun.SetActive(true);
        machinGunActive = false;
        machineGun.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (machinGunActive==true)
        {
            machineGun.SetActive(true);
            gun.SetActive(false);
        }
        else if (machinGunActive ==false)
        {
            machineGun.SetActive(false);
            gun.SetActive(true);
        }
        
    }

    public void Shoot()
    {
        if (bulletSpawnLocation != null && !machineGun.activeSelf)
        {
            Bullet newBullet = Instantiate(bullet, bulletSpawnLocation.position, bulletSpawnLocation.rotation) as Bullet;
        }
        
        if (machineGunLocation != null && machineGun.activeSelf)
        {
            foreach (var pos in machineGunLocation)
            {
                Bullet newBullet = Instantiate(bullet, pos.position, pos.rotation) as Bullet;
            }
            
        }

    }
  
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
