using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{
    public Image yourImage;
    public KeyCode key;
    bool active = false;
    GameObject note;
    public float Degat;
    public float Chauge;
    public TMP_Text Multiplicateur_One;
    //public GameObject noteGlow;

    void Start()
    {
        ScoreManager.ChaugeCommune = 1f;

        Multiplicateur_One.text = ScoreManager.Multiplication_Player_One_Commun.ToString() + " multiplicateur";
            if (yourImage == null)
            {
                ChangeFillAmount(1f);

                yourImage = GetComponent<Image>();
            }
        
    }

    void ChangeFillAmount(float fillValue)
    {
        // Assurez-vous que l'objet Image est disponible
        if (yourImage != null)
        {
            // Changez le fillAmount avec la valeur spécifiée
            yourImage.fillAmount = fillValue;
        }
        else
        {
            Debug.LogError("Image component is not assigned or found!");
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(key) && active)
        {
            //note.SetActive(false);
            //noteGlow.SetActive(true);
            Destroy(note);
            ScoreManager.Multiplication_Player_One_Commun++;
            Multiplicateur_One.text = ScoreManager.Multiplication_Player_One_Commun.ToString() + " multiplicateur";
            ScoreManager.instance.AddPointsPlayerOne();
        }
        else if (Input.GetKeyDown(key) && !active)
        {
            ScoreManager.Multiplication_Player_One_Commun = 0;
            ScoreManager.ChaugeCommune -= Degat;
            if(ScoreManager.ChaugeCommune <= 0)
            {
                SceneManager.LoadScene("Victoire_Gauche");
                ScoreManager.ChaugeCommune = 0;
            }
            ChangeFillAmount(ScoreManager.ChaugeCommune);
            Multiplicateur_One.text = ScoreManager.Multiplication_Player_One_Commun.ToString() + " multiplicateur";
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}