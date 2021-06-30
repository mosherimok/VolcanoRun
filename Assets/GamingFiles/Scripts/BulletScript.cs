﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float bulletLifeTime = 2f;
    public float bulletPower;
    EthanScript myPlayerScript;

    public void Seek(Transform _target)
    {
        target = _target;
        myPlayerScript = target.GetComponent<EthanScript>();
    }

    void Awake()
    {
        Destroy(gameObject, bulletLifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        myPlayerScript.loseHealth(bulletPower);
        Destroy(gameObject);
    }
}
