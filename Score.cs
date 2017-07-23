using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public static Score ScoreInst;

    private Text txt;
    public int sco;
	void Awake ()
    {
        txt = GameObject.Find("countscore").GetComponent<Text>();
        Instances();

    }
    void Instances()
    {
        if (ScoreInst == null)
        {
            ScoreInst = this;
        }
    }
    public void IncrementScoer()
    {
        sco++;
        txt.text = "" + sco;
        if (sco > 0 && sco != 0 && sco < 2)
        {
            gamemgr.inst.Yes(true);
           
        }

        if (sco == 10 && sco < 11)
        {
            gamemgr.inst.Awesome(true);
        }

      

    }
    public  int GetScore()
    {
        return this.sco;
    }
}
