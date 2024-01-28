using UnityEngine;
using Spine.Unity;
using JetBrains.Annotations;
using Unity.Collections;
using System.Collections;

public class StopStartSpineAnimation : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    public GameObject ImageUne;
    public GameObject ImageDeux;
    public GameObject ImageTrois;
    private MeshRenderer meshRenderer;
    public float timer;

    void Start()
    {
        // Assurez-vous que le GameObject a un composant SkeletonAnimation attaché
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        if (skeletonAnimation == null)
        {
            Debug.LogError("SkeletonAnimation component not found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            meshRenderer.enabled = false;
            ImageUne.SetActive(true);
            ImageDeux.SetActive(false);
            ImageTrois.SetActive(false);
            StartCoroutine(F1());
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            meshRenderer.enabled = false;
            ImageUne.SetActive(false);
            ImageDeux.SetActive(true);
            ImageTrois.SetActive(false);
            StartCoroutine(F1());
        }
           
        if (Input.GetKeyDown(KeyCode.F3))
        {
            meshRenderer.enabled = false;
            ImageUne.SetActive(false);
            ImageDeux.SetActive(false);
            ImageTrois.SetActive(true);
            StartCoroutine(F1());

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            meshRenderer.enabled = true;
            ImageUne.SetActive(false);
            ImageDeux.SetActive(false);
            ImageTrois.SetActive(false);
        }




    }

    IEnumerator F1()
    {

        yield return new WaitForSeconds(timer);
        meshRenderer.enabled = true;
        ImageUne.SetActive(false);
        ImageDeux.SetActive(false);
        ImageTrois.SetActive(false);


    }
    

}
