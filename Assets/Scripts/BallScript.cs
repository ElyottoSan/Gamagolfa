using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public AudioSource audiofail;
    public AudioSource audiowin;
    public Easing.Type easing;
    Vector3 lastPos;
    public float delay;
    public GameObject menuFin;
    public GameObject VFX;

    void start()
    {
        menuFin.SetActive(false);
        VFX.SetActive(false);
        Camera.main.FadeIn(3f, easing);
        lastPos = this.transform.position;
    }

    //Si on touche un Collider
    private void OnCollisionEnter(Collision collision)
    {
        //Si le tag du mesh est "SortieParcours"
        if (collision.gameObject.tag == "SortieParcours")
        {
            audiofail.Play();
            GetComponent<Renderer>().enabled = false;
            StartCoroutine("ResetBall");
        }
    }

    void Update()
    {
            //On démarre la coroutine
            if (this.GetComponent<Rigidbody>().velocity.magnitude < 0.2f)
            {
                StartCoroutine(CheckIfBallhasStopped());
            }
    }

    IEnumerator CheckIfBallhasStopped()
    {
        //0.7 secondes après l'arrêt de la balle, on sauvegarde sa position actuelle
        yield return new WaitForSeconds(0.7f);
        if(this.GetComponent<Rigidbody>().velocity.magnitude < 0.2f)
        {
            lastPos = this.transform.position;
        }
    }

    IEnumerator ResetBall()
    {
        //Puis, si elle sort du parcours et percute le décor, elle est repositionnée à sa dernière position gardée en mémoire :)
        yield return new WaitForSeconds(0.2f);
        transform.position = lastPos;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Renderer>().enabled = true;       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fin")
        {
            //Déclencher fin de niveau
            audiowin.Play();
            VFX.SetActive(true);
            Invoke("MenuNextLevel", delay);
            //Récupérer le numéro du niveau. 0 = menu ; 1 = niveau 1 ; 2 = niveau 2 ; etc...
            int niveauActuel = SceneManager.GetActiveScene().buildIndex;
            //Puis sauvegarder le numéro du dernier niveau terminé
            PlayerPrefs.SetInt("DernierNiveau", niveauActuel);
        }        
    }

    void MenuNextLevel()
    {
        Time.timeScale = 0.0f;
        menuFin.SetActive(true);
    }
}
