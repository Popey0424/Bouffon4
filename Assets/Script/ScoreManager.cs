using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text ScoreTextOne;
    public TMP_Text ScoreTextTwo;
    public GameObject InitialKing;
    public GameObject LeftKing;
    public GameObject RightKing;
    public GameObject PrefabHitPointPlayerOne;
    public GameObject PrefabHitPointPlayerTwo;
    public Canvas Canvas;


    
    public static int Multiplication_Player_One_Commun = 0;
    public static int Multiplication_Player_Two_Commun = 0;
    public static int test_static = 0;
    //public int Multiplication_Player_Two;
    //public GameObject PlayerOne_Script;
    //public GameObject PlayerTwo_Script;


    public static float ChaugeCommune;
    public static float ChaugeCommune2;
    int scorePlayerOne = 0;
    int scorePlayerTwo = 0;




    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreTextOne.text = scorePlayerOne.ToString() + "Score";
        ScoreTextTwo.text = scorePlayerTwo.ToString() + "Score";
    }

    // Update is called once per frame+
    void Update()
    {
        if (scorePlayerOne > scorePlayerTwo)
        {
            KingLookLeft();
        }
        else if (scorePlayerOne < scorePlayerTwo)
        {
            KingLookRight();
        }
        else if (scorePlayerOne == scorePlayerTwo)
        {
            KingLookFront();
        }
    }

    public void AddPointsPlayerOne()
    {
        scorePlayerOne += 1 * Multiplication_Player_One_Commun;
        ScoreTextOne.text = scorePlayerOne.ToString() + "Score";
        GameObject go = GameObject.Instantiate(PrefabHitPointPlayerOne, Canvas.transform, false);
        go.transform.localPosition = /*new Vector3(0, 0, 0);*/ UnityEngine.Random.insideUnitCircle * 100;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);
       

    }

    public void AddPointsPlayerTwo()
    {
        scorePlayerTwo += 1 * Multiplication_Player_Two_Commun;
        ScoreTextTwo.text = scorePlayerTwo.ToString() + "Score";
        GameObject go = GameObject.Instantiate(PrefabHitPointPlayerTwo, Canvas.transform, false);
        go.transform.localPosition = /*new Vector3(0, 0, 0);*/ UnityEngine.Random.insideUnitCircle * 100;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);

    }

    public void KingLookLeft()
    {
        InitialKing.SetActive(false);
        RightKing.SetActive(false);
        LeftKing.SetActive(true);
    }

    public void KingLookRight()
    {
        InitialKing.SetActive(false);
        RightKing.SetActive(true);
        LeftKing.SetActive(false);
    }

    public void KingLookFront()
    {
        InitialKing.SetActive(true);
        RightKing.SetActive(false);
        LeftKing.SetActive(false);
    }
}
