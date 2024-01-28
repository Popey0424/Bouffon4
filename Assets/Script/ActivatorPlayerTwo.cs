using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ActivatorPlayerTwo : MonoBehaviour
{
    public Image yourImage;
    public float Degat;
    public float Time_FeedBack;
    public KeyCode key;
    bool active = false;
    GameObject note;
    public TMP_Text Multiplicateur_Two;
    void Start()
    {
        ScoreManager.ChaugeCommune2 = 1f;
        Multiplicateur_Two.text = ScoreManager.Multiplication_Player_Two_Commun.ToString() + "multiplicateur";
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
        if(ScoreManager.ChaugeCommune2 <= 0)
        {
            SceneManager.LoadScene("Victoire_Droite");
        }

        if (Input.GetKeyDown(key) && active)
        {
            Destroy(note);
            ScoreManager.Multiplication_Player_Two_Commun++;
            Multiplicateur_Two.text = ScoreManager.Multiplication_Player_Two_Commun.ToString() + " multiplicateur";
            ScoreManager.instance.AddPointsPlayerTwo();
        }
    

        else if (Input.GetKeyDown(key) && active != true)
        {
            ScoreManager.Multiplication_Player_Two_Commun = 0;
            ScoreManager.ChaugeCommune2 -= Degat;
            if (ScoreManager.ChaugeCommune2 <= 0)
            {
                ScoreManager.ChaugeCommune2 = 0;
                
            }
            ChangeFillAmount(ScoreManager.ChaugeCommune2);
            Multiplicateur_Two.text = ScoreManager.Multiplication_Player_Two_Commun.ToString() + " multiplicateur";
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
