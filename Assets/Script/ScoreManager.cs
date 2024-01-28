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
    public Canvas Perfect;
    public GameObject PrefabGoodPointPlayerOne;
    public GameObject PrefabGoodPointPlayerTwo;
    public GameObject PrefabPerfectPlayerOne;
    public GameObject PrefabPerfectPlayerTwo;
    public Transform player1Transform, player2Transform;



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

        Vector2 playerPos = new Vector2(player1Transform.position.x, player1Transform.position.y);
        Vector2 canvasPos = Camera.main.WorldToScreenPoint(playerPos);

        if (Multiplication_Player_One_Commun > 1)
        {
            GameObject gO = GameObject.Instantiate(PrefabPerfectPlayerOne, Canvas.transform, false);
            gO.transform.localPosition = /*new Vector3(0, 0, 0);*/ canvasPos + Random.insideUnitCircle * 125;
            gO.transform.DOLocalMoveY(20, 0.8f);
            gO.GetComponent<Text>().DOFade(0, 0.8f);
            GameObject.Destroy(gO, 0.8f);
        }

        GameObject Go = GameObject.Instantiate(PrefabGoodPointPlayerOne, Canvas.transform, false);
        Go.transform.localPosition = /*new Vector3(0, 0, 0);*/ canvasPos + Random.insideUnitCircle * 125;
        Go.transform.DOLocalMoveY(20, 0.8f);
        Go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(Go, 0.8f);
        ScoreTextOne.text = scorePlayerOne.ToString() + "Score";
        GameObject go = GameObject.Instantiate(PrefabHitPointPlayerOne, Perfect.transform, false);
        go.transform.localPosition = /*new Vector3(0, 0, 0);*/ canvasPos + Random.insideUnitCircle * 25;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);
       

    }

    public void AddPointsPlayerTwo()
    {
        scorePlayerOne += 1 * Multiplication_Player_One_Commun;


        if (Multiplication_Player_One_Commun > 1)
        {
            GameObject gO = GameObject.Instantiate(PrefabPerfectPlayerTwo, Canvas.transform, false);
            gO.transform.localPosition = /*new Vector3(0, 0, 0);*/ Random.insideUnitCircle * 125;
            gO.transform.DOLocalMoveY(20, 0.8f);
            gO.GetComponent<Text>().DOFade(0, 0.8f);
            GameObject.Destroy(gO, 0.8f);
        }

        GameObject Go = GameObject.Instantiate(PrefabGoodPointPlayerTwo, Canvas.transform, false);
        Go.transform.localPosition = /*new Vector3(0, 0, 0);*/ Random.insideUnitCircle * 125;
        Go.transform.DOLocalMoveY(20, 0.8f);
        Go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(Go, 0.8f);
        ScoreTextOne.text = scorePlayerOne.ToString() + "Score";
        GameObject go = GameObject.Instantiate(PrefabHitPointPlayerTwo, Perfect.transform, false);
        go.transform.localPosition = /*new Vector3(0, 0, 0);*/ Random.insideUnitCircle * 25;
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
