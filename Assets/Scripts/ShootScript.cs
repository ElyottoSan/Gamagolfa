using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootScript : MonoBehaviour
{   

    public int nbTireRestant = 15; //Nombre de coups restants
    int puissance = 1000; //Puissance de tir
    public GameObject Balle; //La balle
    public TextMeshProUGUI txtNbTirs; //Texte nb coups
    public TextMeshProUGUI txtPower; //Texte puissance du tir
    public Slider slider; //Le slider
    public AudioClip son1; //Le bruit de la balle
    public AudioClip son2; //Le bruit de la balle
    public Image FlècheDirectionnelle; //On récupère ici la flèche qui sert à viser

    private void Start()
    {
        //Affichage du nombre de coups
        txtNbTirs.text = "Tirs restants : " + nbTireRestant;
    }

    //Fonction de tir
    public void Shoot()
    {
        if(nbTireRestant > 0) //S'il reste des coups
        {
            //Nous récupérons la valeur du slider pour la puissance
            puissance = (int)slider.value * 25;
            //On réinitialise le slider
            slider.value = 0;
            nbTireRestant--; //On soustrait le nombre de coups
            //On modifie le texte
            txtNbTirs.text = "Tirs restants : " + nbTireRestant;
            //On propulse la balle devant
            Balle.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * puissance);
            if (puissance <= 1249)
            {
                //Jouer le son de tir
                Balle.GetComponent<AudioSource>().PlayOneShot(son1);
            }
            if (puissance >= 1250)
            {
                //Jouer le son de tir
                Balle.GetComponent<AudioSource>().PlayOneShot(son2);
            }
            StartCoroutine("LockSlider"); //Appel de la coroutine
        }
    }
    IEnumerator LockSlider() //Coroutine
    {
        yield return new WaitForSeconds(0.2f); //0.2 secondes après le tir
        slider.interactable = false; //On bloque le slider après le tir
        FlècheDirectionnelle.enabled = false; //On masque également la flèche de visée
    }
    
    //Définir texte puissance
    public void PuissanceDeTir()
    {
        //On récupère et convertit la valeur
        int val = (int)slider.value;
        txtPower.text = val + "%"; //On modifie le texte
    }

    private void Update()
    {
        //Si la vitesse de balle est faible et le slider bloqué
        if (Balle.GetComponent<Rigidbody>().velocity.magnitude < 0.2f && slider.interactable == false)
        {
            slider.interactable = true; //On réactive le slider
            FlècheDirectionnelle.enabled = true; //Et la flèche aussi
        }
    }
}
