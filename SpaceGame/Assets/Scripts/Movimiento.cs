using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadGiro;

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    public float sensibilidad = 1;
    public float tiempo = 0.1f;
    public Transform PolvoPrefab;
    public TrailRenderer trail;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = camTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime * 100);

        if (Input.GetKey(KeyCode.W))
            Mover();

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }

        if (rb.velocity.magnitude > 0)
            trail.emitting = true;
        else
            trail.emitting = false;
    }

    private void Mover()
    {
        rb.AddForce(transform.up * velocidad * Time.deltaTime * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude > sensibilidad)
        {
            shakeDuration += tiempo;
            if(collision.transform.CompareTag("Meteorito"))
            {
                Instantiate(PolvoPrefab, collision.GetContact(0).point, Quaternion.identity);
            }

        }
    }
}
