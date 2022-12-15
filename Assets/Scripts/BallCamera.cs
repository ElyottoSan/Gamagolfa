using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public float rotationSpeed = 45f; //vitesse de rotation
    public GameObject Balle; //La balle
    private Vector3 m_currentVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // On applique la rotation
        transform.Rotate(0f, Input.GetAxis("CameraPivot") * Time.deltaTime * rotationSpeed, 0f);
        //On bloque la caméra sur l'axe y
        if (transform.position.y < 3.0f)
        {
            transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
        }
        //Calcul de la position de la caméra
        if (Balle != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Balle.transform.position, ref m_currentVelocity, Time.deltaTime);
        }
    }
}
