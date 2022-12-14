using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptIntro : MonoBehaviour
{
    public GameObject Player;
    public GameObject Canva;
    public GameObject CameraIntro;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.FadeIn(3f);
        Player.SetActive(false);
        Canva.SetActive(false);
    }

    // Update is called once per frame
    public void FinAnim()
    {
        Player.SetActive(true);
        Canva.SetActive(true);
        CameraIntro.SetActive(false);
    }
}
