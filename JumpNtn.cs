using UnityEngine;
using UnityEngine.EventSystems;

public class JumpNtn : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{

   public void OnPointerDown(PointerEventData data)
    {
        if (PlayerJump.instan != null)
        {
           
            PlayerJump.instan.Setpower(true);
        }
       
    }

   public void OnPointerUp(PointerEventData data)
    {
        gamemgr.inst._jumpAudio.Play();
      // LevelManeger.levelinst._jumpAudios.Play();
        if (PlayerJump.instan != null)
        {
           
            PlayerJump.instan.Setpower(false);
            PlayerJump.instan.forcex = 2;
            PlayerJump.instan.forcey = 1.5f;
        }
       
    }
}
