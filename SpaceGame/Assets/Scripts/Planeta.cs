using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public float Tiempo = 10;
    public float Vel;
    void Update()
    {
        transform.position -= new Vector3(0, Vel, 0) * Time.deltaTime;

        if (Tiempo > 0)
        {

            Tiempo -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
