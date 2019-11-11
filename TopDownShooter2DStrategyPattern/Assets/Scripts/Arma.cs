using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] protected sbyte damage;
    public sbyte getDano()
    {
        return damage;
    }
}
