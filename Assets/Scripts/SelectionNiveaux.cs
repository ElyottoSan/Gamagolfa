using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionNiveaux : MonoBehaviour
{
    Button[] btns;

    void Start()
    {
        int lastLevel = PlayerPrefs.GetInt("DernierNiveau");
        btns = GameObject.FindObjectsOfType<Button>();
        foreach (Button btn in btns)
        {
            int level = int.Parse(btn.transform.GetChild(0).gameObject.GetComponent<Text>().text);

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
