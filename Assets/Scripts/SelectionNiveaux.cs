using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionNiveaux : MonoBehaviour
{
    //variable de type tableau de boutons
    Button[] btns;

    void Start()
    {
        //On récupère le dernier niveau terminé
        int lastLevel = PlayerPrefs.GetInt("DernierNiveau");
        //On récupère tous les GameObject de type bouton du menu
        btns = GameObject.FindObjectsOfType<Button>();
        //Boucler sur l'ensemble des éléments du tableau, afin de comparer le numéro du niveau au numéro du dernier niveau débloqué
        foreach (Button btn in btns) // btn = le bouton actuel & btns = l’ensemble des boutons à parcourir
        {
            //accéder à l'enfant du bouton puis accéder à son composant TEXT pour récupérer la valeur de ce dernier
            int level = int.Parse(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);

            //vérifier si le niveau a été débloqué en comparant sa valeur à la valeur du dernier niveau débloqué puis de rendre le bouton cliquable s'il doit l'être
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
