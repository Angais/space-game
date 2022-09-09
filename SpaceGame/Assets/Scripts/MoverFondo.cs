using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFondo : MonoBehaviour
{
    private Material mat;
    public float velocidad;
    public float multiplicadorJugador = 1.5f;
    private Movimiento player;
    public Sprite[] Planetas;
    public GameObject PlanetaPref;
    public float Tiempo;

    // Start is called before the first frame update
    void Awake()
    {
        mat = GetComponent<Renderer>().material;
        player = GameObject.Find("Nave").GetComponent<Movimiento>();
        Tiempo = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {
        float vel;
        vel = velocidad + player.rb.velocity.magnitude * multiplicadorJugador;
        mat.mainTextureOffset += new Vector2(0, vel/100f) * Time.deltaTime;

        if (Tiempo > 0)
        {

            Tiempo -= Time.deltaTime;
        }
        else
        {
            SpriteRenderer rend;
            rend = Instantiate(PlanetaPref, new Vector3(Random.Range(-2, 2), 3, 0), Quaternion.identity).GetComponent<SpriteRenderer>();
            rend.sprite = Planetas[Random.Range(0, Planetas.Length - 1)];
            rend.gameObject.GetComponent<Planeta>().Vel = vel;
            Tiempo = Random.Range(5, 15);
        }
    }
}
