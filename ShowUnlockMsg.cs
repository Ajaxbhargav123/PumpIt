using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnlockMsg : MonoBehaviour {
    public static ShowUnlockMsg UnlockMsgInst;
    public  GameObject UnlockMsg;

    private void Awake()
    {
        if (UnlockMsgInst == null)
        {
            UnlockMsgInst = this;
            UnlockMsg.SetActive(false);
        }
        
    }
    public void IsUnlockMsg(bool Isshow)
    {
        UnlockMsg.SetActive(Isshow);

        Destroy(UnlockMsg, 2f);

    }
}
