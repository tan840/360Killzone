using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{
    // Start is called before the first frame update
    NavMeshAgent pathFinder;
    Transform target;
    public CameraShake camShake;
    public GameObject deathParticle;
    //public int count1, count2, count3, count4 = 0;
    public UI_Elements ui_show;
    public int kill_collision = 3;

    public SpawnScript spawnScript;
    protected  override void Start()
    {
        base.Start();
        pathFinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine("UpdatePath");

        camShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();

        ui_show = GameObject.Find("Canvas").GetComponent<UI_Elements>();

        spawnScript = GameObject.Find("SpawnPoints").GetComponent<SpawnScript>();





    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collisioninfo)
    {
        //print("ok! enemy");
        //Debug.Log(collisioninfo.collider.name);
        if (collisioninfo.collider.CompareTag("Bullet"))
        {
            
            Destroy(collisioninfo.gameObject);
            Destroy(this.gameObject);
            camShake.shouldShake = true;
            Instantiate(deathParticle, this.transform.position, Quaternion.identity);
            // print("ok! DIEEEEE");
        }
        if (collisioninfo.collider.CompareTag("Barrier1"))
        {
            spawnScript.count1++;
            if(spawnScript.count1 > kill_collision)
            {
                print("1");
                Destroy(collisioninfo.gameObject);
            }


        }
        if (collisioninfo.collider.CompareTag("Barrier2"))
        {
            spawnScript.count2++;
            if (spawnScript.count2 == kill_collision)
            {
                print("3");
                Destroy(collisioninfo.gameObject);
            }

        }
        if (collisioninfo.collider.CompareTag("Barrier3"))
        {
            spawnScript.count3++;
            if (spawnScript.count3== kill_collision)
            {
                print("3");
                Destroy(collisioninfo.gameObject);
            }

        }
        if (collisioninfo.collider.CompareTag("Barrier4"))
        {
            spawnScript.count4++;
            if (spawnScript.count4 == kill_collision)
            {
                print("4");
                Destroy(collisioninfo.gameObject);
            }

        }
        if (collisioninfo.collider.CompareTag("Player"))
        {

            ui_show.GameOver_panel.SetActive(true);
            Time.timeScale = 0.2f;
        }

    }

    IEnumerable UpdatePath()
    {
        float refreshRate = 1;
        while (target != null)
        {
            Vector3 targetUpdate = new Vector3(target.position.x, 0, target.position.z);
            if (!dead)
            {
                pathFinder.SetDestination(targetUpdate);
            }
            
            yield return new WaitForSeconds(refreshRate);
        }
    }
        
}
