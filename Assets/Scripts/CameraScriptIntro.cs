using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptIntro : MonoBehaviour
{
    public GameObject Player; //la balle
    public GameObject Canva; //l'interface
    public GameObject CameraIntro; //la pr�sente cam�ra

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.FadeIn(3f);
        Player.SetActive(false); //la balle est d�sactiv�e lors de la cin�matique
        Canva.SetActive(false); //Idem pour l'interface
    }

    public void FinAnim()
    {
        Player.SetActive(true); // Puis r�activ�e � la fin
        Canva.SetActive(true); //Pareil
        CameraIntro.SetActive(false); //La cam�ra d'intro est d�sactiv�e
    }
}
