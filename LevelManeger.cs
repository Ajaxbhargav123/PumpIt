using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class LevelManeger : MonoBehaviour
{
    public static LevelManeger levelInst;

    public Button[] btn;

    public string nextlevel = "nextlevel";
    public int reached = 2;
    public bool AlreadyReached;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
      
     for(int i = 0; i < btn.Length; i++)
        {
            if (i+1 > levelReached)
            {
                btn[i].interactable = false;
            }
           
        }
    }
    public void Awake()
    {
        if (levelInst == null)
        {
            levelInst = this;

        }
    }

    public void FixedUpdate()
    {
        if (Score.ScoreInst.sco == 35)
        {
           
            PlayerPrefs.SetInt("levelReached", reached);
           
                ShowUnlockMsg.UnlockMsgInst.IsUnlockMsg(true);
   
        }
       
    }


}