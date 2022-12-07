using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public GameObject Balle;
    private Vector3 m_currentVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Input.GetAxis("CameraPivot") * Time.deltaTime * rotationSpeed, 0f);
        if (transform.position.y < 3.0f)
        {
            transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
        }
        if (Balle != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Balle.transform.position, ref m_currentVelocity, Time.deltaTime);
        }
    }
}
