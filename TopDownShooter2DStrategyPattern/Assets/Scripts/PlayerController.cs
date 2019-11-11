using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string nomeArmma;

    float moviment;
    Rigidbody2D rb;
    Vector3 mousePos;
    Quaternion rot;
    IArma arma;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ConfigArma(nomeArmma);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            arma.Atirar();
    }


    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);

        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        moviment = Input.GetAxis("Vertical");
        rb.AddForce (transform.up * moviment * speed);

        
    }

    public void ConfigArma(string tag)
    {
        switch (tag)
        {
            case "Pickup":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroSimples>();
                break;
            case "UFO":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroRayCast>();
                break;
            case "Kypton":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroPotente>();
                break;
            default:
                break;
        }
    }

    private void RemoveArma()
    {
        //EVITAR CRIACAO DE MULTIPLOS COMPONENTES NO MESMO GAMEOBJECT
        Component c = gameObject.GetComponent<IArma>() as Component;
        if (c != null) Destroy(c);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            ConfigArma(collision.tag);
    }
}
