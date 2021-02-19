using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryZone : MonoBehaviour
{
    public GameObject E_Object;

    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("DeleteZone"))
        {
            Destroy(E_Object);
        }
        if (collider.CompareTag("E_Bullet"))
        {
            Destroy(E_Object);
        }
        //if (collider.CompareTag("Player"))
        //{
        //    Destroy(E_Bullet);
        //}
        //if (collider.CompareTag("E_Bullet"))
        //{
        //    Destroy(E_Bullet);
        //}

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(E_Object);
        }
    }
}
