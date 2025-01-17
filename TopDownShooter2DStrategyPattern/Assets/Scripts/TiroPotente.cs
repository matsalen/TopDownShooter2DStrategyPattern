﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPotente : Arma, IArma
{
    float speed;
    Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        speed = 6;
        damage = 5;
    }
    public void Atirar()
    {
        GameObject bullet = Instantiate(Resources.Load("Bullet1", typeof(GameObject)))
            as GameObject;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
