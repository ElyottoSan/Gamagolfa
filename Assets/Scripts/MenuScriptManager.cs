using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScriptManager : MonoBehaviour
{
    public GameObject menuStarting;
    public GameObject menuControles;

    // Start is called before the first frame update
    private void Start()
    {
        menuControles.SetActive(false);
    }

    public void Controles()
    {
        menuStarting.SetActive(false);
        menuControles.SetActive(true);
    }

    public void Croix()
    {
        menuControles.SetActive(false);
        menuStarting.SetActive(true);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    // Charger un niveau
    public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
