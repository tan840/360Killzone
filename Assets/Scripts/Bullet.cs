using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    //float damage = 1;
    //public LayerMask collisonMask;
    // public BoxCollider[] bulletChild;
    //Ray ray;
    //RaycastHit hit;


    private void Start()
    {
        StartCoroutine("DestryBullet");
    }




    void Update()
    {
        float moveDistance = Time.deltaTime * speed;
        //CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
        
    }

    /*void CheckCollisions(float moveDistance)
    {
        ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(ray,out hit,moveDistance,collisonMask,QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }
    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage,hit);
        }
        GameObject.Destroy(gameObject);
        print("BOOM!");
    }*/

    IEnumerator DestryBullet()
    {
        yield return new WaitForSeconds(4f);

        Destroy(this.gameObject);
    }


}
