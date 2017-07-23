using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
   public void Play()
    {
        Application.LoadLevel("UI");
    }
    public void Playss()
    {
        Application.LoadLevel("MAIN 1");
    }

    public void selector()
    {
        Application.LoadLevel("Selector");
    }
    public void Plays()
    {
        Application.LoadLevel("MAIN");
    }
    public void Back()
    {
        Application.LoadLevel("UI");
    }
    public void L1()
    {
        Application.LoadLevel("Level-1");
    }
    public void L2()
    {
        Application.LoadLevel("Level-2");
    }
    public void Exit()
    {
        Application.Quit();
    }

}
