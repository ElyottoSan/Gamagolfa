using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apparition : MonoBehaviour
{
    public GameObject Balle;
    public GameObject Tornado;

    // Start is called before the first frame update
    void Start()
    {
        Tornado.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Balle)
        {
            Tornado.SetActive(true);
        }
    }
}
