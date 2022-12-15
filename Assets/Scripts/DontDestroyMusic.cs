using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    void Update()
    {
        //La scène active
        Scene currentScene = SceneManager.GetActiveScene();

        //Désactiver la musique dans les niveaux de gameplay seulement
        if (currentScene.name == "Parcours 1 - Mer")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Parcours 2 - Désert")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Parcours 3 - Neige")
        {
            Destroy(this.gameObject);
        }
        if (currentScene.name == "Parcours 4 - Feu")
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        //La musique ne sera pas détruite à la scène suivante
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
