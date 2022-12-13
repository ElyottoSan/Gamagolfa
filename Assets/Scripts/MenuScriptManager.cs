using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScriptManager : MonoBehaviour
{
    public GameObject menuStarting;
    public GameObject menuControles;
    public GameObject menuSelectionNiveaux;
    Button[] btns;

    // Start is called before the first frame update
    void Start()
    {
        menuControles.SetActive(false);
        menuSelectionNiveaux.SetActive(false);
        int lastLevel = PlayerPrefs.GetInt("DernierNiveau");
        btns = GameObject.FindObjectsOfType<Button>();
        foreach(Button btn in btns)
        {
            int level = int.Parse(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);
            if (level <= lastLevel)
            {
                btn.interactable = true;
            }
        }
    }

    public void SelectionNiveaux()
    {
        menuSelectionNiveaux.SetActive(true);
        menuStarting.SetActive(false);
    }

    public void Controles()
    {
        menuStarting.SetActive(false);
        menuControles.SetActive(true);
    }

    public void Croix()
    {
        menuControles.SetActive(false);
        menuSelectionNiveaux.SetActive(false);
        menuStarting.SetActive(true);
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void LoadSelectedLevel(int Niveau)
    {
        SceneManager.LoadScene(Niveau);
    }
}
