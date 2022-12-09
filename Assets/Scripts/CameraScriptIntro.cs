using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptIntro : MonoBehaviour
{
    public GameObject Player;
    public GameObject Canva;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(false);
        Canva.SetActive(false);
    }

    // Update is called once per frame
    public void FinAnim()
    {
        Player.SetActive(true);
        Canva.SetActive(true);
        Camera.SetActive(false);
    }
}
