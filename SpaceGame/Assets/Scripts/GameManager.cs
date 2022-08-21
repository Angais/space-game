using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        if (Panel.activeSelf)
            Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarPanel()
    {
        Panel.SetActive(true);
    }

    public void CargarNivel(int Numero)
    {
        EditorSceneManager.LoadScene(Numero);
    }
}
