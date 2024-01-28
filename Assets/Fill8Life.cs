using UnityEngine;
using UnityEngine.UI;

public class YourScript : MonoBehaviour
{
    public Image yourImage;

    void Start()
    {
        if (yourImage == null)
        {
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
}
