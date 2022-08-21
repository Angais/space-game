using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoGolpes;
    [SerializeField] private TextMeshProUGUI textoGolpesTotales;
    [SerializeField] private GameObject Panel;
    [SerializeField] private int Golpes;
    [SerializeField] private int GolpesMaximos;
    [SerializeField] private float TiempoReaparecer;
    private Rigidbody2D rb;
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadGiro;
    public Sprite[] Skins = { null, null, null, null, null };
    public int Skin;
    private SpriteRenderer renderer;
    private SpriteRenderer rendererMeta;
    private bool Perdio = false;
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
    public Color[] coloresParticulas = { Color.white, Color.white, Color.white };
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = camTransform.localPosition;
        renderer = GetComponent<SpriteRenderer>();
        rendererMeta = GameObject.FindGameObjectWithTag("Respawn").GetComponent<SpriteRenderer>();
        if(PlayerPrefs.HasKey("Skin"))
        {
            Skin = PlayerPrefs.GetInt("Skin");
        }
        if (Panel.activeSelf)
        {
            Panel.SetActive(false);
        }

        if(TiempoReaparecer <= 0)
        {
            TiempoReaparecer = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, velocidadGiro * Time.deltaTime * 100);

        if (Input.GetKey(KeyCode.W) || Input.touchCount > 0)
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


        if (Skins[Skin] != renderer.sprite || Skins[Skin] != rendererMeta.sprite)
        {
            renderer.sprite = Skins[Skin];
            rendererMeta.sprite = Skins[Skin];
            PlayerPrefs.SetInt("Skin", Skin);
            PlayerPrefs.Save();
        }

        if(Perdio && TiempoReaparecer > 0)
        {
            TiempoReaparecer -= Time.deltaTime;
        }
        else if(TiempoReaparecer <= 0)
        {
            //recarga este nivel
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (GolpesMaximos - Golpes > 0)
            textoGolpes.SetText("Golpes Máximos: " + (GolpesMaximos - Golpes));
        else
        {
            Perdio = true;
            textoGolpes.SetText("Perdiste ;(\n" +"Reiniciando en " + Mathf.RoundToInt(TiempoReaparecer) + " segundos");
            Debug.Log("Perdiste");
            
        }
        
    }

    private void Mover()
    {
        rb.AddForce(transform.up * velocidad * Time.deltaTime * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.magnitude > sensibilidad && !Perdio)
        {
            Golpes++;
            shakeDuration += tiempo;
            if(collision.transform.CompareTag("Meteorito"))
            {
                ParticleSystem part = Instantiate(PolvoPrefab, collision.GetContact(0).point, Quaternion.identity).GetComponent<ParticleSystem>();
                part.startColor = coloresParticulas[0];
            }
            if (collision.transform.CompareTag("Pared"))
            {
                ParticleSystem part = Instantiate(PolvoPrefab, collision.GetContact(0).point, Quaternion.identity).GetComponent<ParticleSystem>();
                part.startColor = coloresParticulas[1];
            }
            if (collision.transform.CompareTag("Finish"))
            {
                ParticleSystem part = Instantiate(PolvoPrefab, collision.GetContact(0).point, Quaternion.identity).GetComponent<ParticleSystem>();
                part.startColor = coloresParticulas[2];
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Finish") && !Perdio)
        {
            Debug.Log("Felicidades!");
            Panel.SetActive(true);
            textoGolpesTotales.SetText("Golpes Totales: " + Golpes + "/" + GolpesMaximos);
        }
    }
    
    public void MenuPrincipal()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
    }

    public void SiguienteNivel()
    {
        Debug.Log("Siguiente");
        if (SceneManager.GetActiveScene().buildIndex < 12)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
