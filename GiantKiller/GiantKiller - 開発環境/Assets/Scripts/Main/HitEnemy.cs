using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject Bullet;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Boss"))
        {
            Destroy(Bullet);
        }
    }
}
