using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instancia = null;
    [SerializeField] private Transform player;


    private void Awake()
    {
        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(this);


    }
    public Vector3 GetPlayerPosition()
    {
        return player.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
