using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageToast : MonoBehaviour {


    private static MessageToast _main;
    public static MessageToast main
    {
        get
        {
            if (!_main)
                _main = HUD.main.GetComponentInChildren<MessageToast>();

            return _main;
        }
    }
}
