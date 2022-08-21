using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Panel;
    public Button[] BotonesNiveles;
    public Image SkinSeleccionada;
    public int SkinActual;
    public Sprite[] Skins;

    // Start is called before the first frame update
    void Start()
    {
        if (Panel.activeSelf)
            Panel.SetActive(false);

        if(PlayerPrefs.HasKey("1"))
        {
            BotonesNiveles[0].interactable = true;
        }
        if (PlayerPrefs.HasKey("2"))
        {
            BotonesNiveles[1].interactable = true;
        }
        else
            BotonesNiveles[1].interactable = false;
        if (PlayerPrefs.HasKey("3"))
        {
            BotonesNiveles[2].interactable = true;
        }
        else
            BotonesNiveles[2].interactable = false;
        if (PlayerPrefs.HasKey("4"))
        {
            BotonesNiveles[3].interactable = true;
        }
        else
            BotonesNiveles[3].interactable = false;
        if (PlayerPrefs.HasKey("5"))
        {
            BotonesNiveles[4].interactable = true;
        }
        else
            BotonesNiveles[4].interactable = false;
        if (PlayerPrefs.HasKey("6"))
        {
            BotonesNiveles[5].interactable = true;
        }
        else
            BotonesNiveles[5].interactable = false;
        if (PlayerPrefs.HasKey("7"))
        {
            BotonesNiveles[6].interactable = true;
        }
        else
            BotonesNiveles[6].interactable = false;
        if (PlayerPrefs.HasKey("8"))
        {
            BotonesNiveles[7].interactable = true;
        }
        else
            BotonesNiveles[7].interactable = false;
        if (PlayerPrefs.HasKey("9"))
        {
            BotonesNiveles[8].interactable = true;
        }
        else
            BotonesNiveles[8].interactable = false;
        if (PlayerPrefs.HasKey("10"))
        {
            BotonesNiveles[9].interactable = true;
        }
        else
            BotonesNiveles[9].interactable = false;
        if (PlayerPrefs.HasKey("11"))
        {
            BotonesNiveles[10].interactable = true;
        }
        else
            BotonesNiveles[10].interactable = false;
        if (PlayerPrefs.HasKey("12"))
        {
            BotonesNiveles[11].interactable = true;
        }
        else
            BotonesNiveles[11].interactable = false;

        if (PlayerPrefs.HasKey("Skin"))
        {
            SkinActual = PlayerPrefs.GetInt("Skin");
            SkinSeleccionada.sprite = Skins[SkinActual];
        }
    }

    // Update is called once per frame
    void Update()
    {
        SkinSeleccionada.transform.Rotate(0, 0, 250 * Time.deltaTime);
    }

    public void MostrarPanel()
    {
        Panel.SetActive(true);
    }

    public void CargarNivel(int Numero)
    {
        SceneManager.LoadScene(Numero);
    }

    public void MenosSkin()
    {
        if (SkinActual > 0)
            SkinActual--;
        else if (SkinActual <= 0)
            SkinActual = 4;

        SkinSeleccionada.sprite = Skins[SkinActual];
        PlayerPrefs.SetInt("Skin", SkinActual);
        PlayerPrefs.Save();
    }

    public void MasSkin()
    {
        if (SkinActual < 4)
            SkinActual++;
        else if (SkinActual >= 4)
            SkinActual = 0;

        SkinSeleccionada.sprite = Skins[SkinActual];
        PlayerPrefs.SetInt("Skin", SkinActual);
        PlayerPrefs.Save();
    }
}
