using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamano : MonoBehaviour
{
    public float tamañoOriginal;
    public float tamañoMaximo;
    public float velocidadCrecimiento;
    public bool creciendo = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creciendo && transform.localScale.x < tamañoMaximo)
        {
            transform.localScale += Vector3.one * Time.deltaTime * velocidadCrecimiento;
        }
        else if(creciendo && transform.localScale.x > tamañoMaximo)
        {
            creciendo = false;
        }
        else if(!creciendo && transform.localScale.x > tamañoOriginal)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * velocidadCrecimiento;
        }
        else if(!creciendo && transform.localScale.x <= tamañoOriginal)
        {
            creciendo = true;
        }
    }
}
