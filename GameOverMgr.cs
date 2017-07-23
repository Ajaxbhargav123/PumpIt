using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMgr : MonoBehaviour {

    public static GameOverMgr insttan;

    private GameObject gameoverpanel;
    private Animator anis;
    private Button btnback, btnrestart;
    private GameObject scoertxt;
    private Text score;

    void Awake()
    {
        MakeInst();
        InitilizeVariable();
    }
    void MakeInst()
    {
        if (insttan == null)
        {
            insttan = this;
        }
    }
    void InitilizeVariable()
    {
        gameoverpanel = GameObject.Find("holder");
        anis = gameoverpanel.GetComponent<Animator>();
        scoertxt = GameObject.Find("countscore");
        btnback = GameObject.Find("restart").GetComponent<Button>();
       btnrestart = GameObject.Find("back").GetComponent<Button>();

        score = GameObject.Find("score").GetComponent<Text>();

        btnrestart.onClick.AddListener(() => PlayAgain());
        btnback.onClick.AddListener(() => GoToMenu());

        gameoverpanel.SetActive(false);
    }
  public void ShowPanel()
    {
        scoertxt.SetActive(false);
        gameoverpanel.SetActive(true);
        score.text = "Score\n" + "" + Score.ScoreInst.GetScore();
        anis.Play("ui");
    }
    public void PlayAgain()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
    public void GoToMenu()
    {
        Application.LoadLevel("UI");
    }
    void Update () {
	
	}
}
