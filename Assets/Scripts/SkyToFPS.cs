using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SkyToFPS : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cineCam;
    [SerializeField] private CinemachineVirtualCamera cineSkyCam;
    [SerializeField] private bool skyMode;
    // Start is called before the first frame update
    void Start()
    {
        //Le skyMode est désactivé par défaut
        cineCam.enabled = !skyMode;
        cineSkyCam.enabled = skyMode;
    }

    // Update is called once per frame
    void Update()
    {
        //Si le joueur appuie sur E
        if (Input.GetKeyDown (KeyCode.E))
        {
            //On active ou désactive le skyMode
            skyMode = !skyMode;
            cineCam.enabled = !skyMode;
            cineSkyCam.enabled = skyMode;
        }
    }
}
