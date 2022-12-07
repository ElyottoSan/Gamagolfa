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
    public Image Fl�cheDirectionnelle; //On r�cup�re ici la fl�che qui sert � viser

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
            //Nous r�cup�rons la valeur du slider pour la puissance
            puissance = (int)slider.value * 25;
            //On r�initialise le slider
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
        yield return new WaitForSeconds(0.2f); //0.2 secondes apr�s le tir
        slider.interactable = false; //On bloque le slider apr�s le tir
        Fl�cheDirectionnelle.enabled = false; //On masque �galement la fl�che de vis�e
    }
    
    //D�finir texte puissance
    public void PuissanceDeTir()
    {
        //On r�cup�re et convertit la valeur
        int val = (int)slider.value;
        txtPower.text = val + "%"; //On modifie le texte
    }

    private void Update()
    {
        //Si la vitesse de balle est faible et le slider bloqu�
        if (Balle.GetComponent<Rigidbody>().velocity.magnitude < 0.2f && slider.interactable == false)
        {
            slider.interactable = true; //On r�active le slider
            Fl�cheDirectionnelle.enabled = true; //Et la fl�che aussi
        }
    }
}
