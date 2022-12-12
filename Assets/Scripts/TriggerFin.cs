using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFin : MonoBehaviour
{
    public GameObject VFX;
    public GameObject menuFin;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        VFX.SetActive(false);
        menuFin.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
            VFX.SetActive(true);
            Invoke("MenuFin", delay);        
    }
    private void MenuFin()
    {
        menuFin.SetActive(true);
    }
}
