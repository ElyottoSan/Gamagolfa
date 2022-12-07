using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject menuPause; //Le menu pause
   
    void Start ()
    {
        menuPause.SetActive(false);
    }
    //La fonction de mise en pause
    public void ActiverPause()
    {
            menuPause.SetActive(true); //On active le menu pause
            Time.timeScale = 0.0f; //On arrête le temps
    }
    //Retour au jeu
    public void DesactiverPause()
    {
            menuPause.SetActive(false); //On désactive le menu pause
            Time.timeScale = 1.0f; //On met le temps à 1    
    }
    //Recharger le niveau
    public void Reload()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Retour au menu principal
    public void RetoourAuMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0); //Charger la scène 0 = le menu
    }
}
