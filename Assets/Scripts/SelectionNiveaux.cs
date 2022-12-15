using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionNiveaux : MonoBehaviour
{
    //variable de type tableau de boutons
    Button[] btns;

    void Start()
    {
        //On r�cup�re le dernier niveau termin�
        int lastLevel = PlayerPrefs.GetInt("DernierNiveau");
        //On r�cup�re tous les GameObject de type bouton du menu
        btns = GameObject.FindObjectsOfType<Button>();
        //Boucler sur l'ensemble des �l�ments du tableau, afin de comparer le num�ro du niveau au num�ro du dernier niveau d�bloqu�
        foreach (Button btn in btns) // btn = le bouton actuel & btns = l�ensemble des boutons � parcourir
        {
            //acc�der � l'enfant du bouton puis acc�der � son composant TEXT pour r�cup�rer la valeur de ce dernier
            int level = int.Parse(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);

            //v�rifier si le niveau a �t� d�bloqu� en comparant sa valeur � la valeur du dernier niveau d�bloqu� puis de rendre le bouton cliquable s'il doit l'�tre
            if (level <= lastLevel)
            {
                btn.interactable = true;
            }
        }
    }

    // Charger un niveau
    public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
