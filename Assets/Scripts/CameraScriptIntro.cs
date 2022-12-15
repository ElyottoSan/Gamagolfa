using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptIntro : MonoBehaviour
{
    public GameObject Player; //la balle
    public GameObject Canva; //l'interface
    public GameObject CameraIntro; //la présente caméra

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.FadeIn(3f);
        Player.SetActive(false); //la balle est désactivée lors de la cinématique
        Canva.SetActive(false); //Idem pour l'interface
    }

    public void FinAnim()
    {
        Player.SetActive(true); // Puis réactivée à la fin
        Canva.SetActive(true); //Pareil
        CameraIntro.SetActive(false); //La caméra d'intro est désactivée
    }
}
