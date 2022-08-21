using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamano : MonoBehaviour
{
    public float tama�oOriginal;
    public float tama�oMaximo;
    public float velocidadCrecimiento;
    public bool creciendo = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creciendo && transform.localScale.x < tama�oMaximo)
        {
            transform.localScale += Vector3.one * Time.deltaTime * velocidadCrecimiento;
        }
        else if(creciendo && transform.localScale.x > tama�oMaximo)
        {
            creciendo = false;
        }
        else if(!creciendo && transform.localScale.x > tama�oOriginal)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * velocidadCrecimiento;
        }
        else if(!creciendo && transform.localScale.x <= tama�oOriginal)
        {
            creciendo = true;
        }
    }
}
