using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFondo : MonoBehaviour
{
    private Material mat;
    public int velocidad;

    // Start is called before the first frame update
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, velocidad/100f) * Time.deltaTime;
    }
}
