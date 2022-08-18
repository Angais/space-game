using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadGiro;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime * 100);

        if (Input.GetKey(KeyCode.W))
            Mover();
    }

    private void Mover()
    {
        rb.AddForce(transform.up * velocidad * Time.deltaTime * 100);
    }
}
