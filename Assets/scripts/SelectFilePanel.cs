using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFilePanel : MonoBehaviour {

    private static SelectFilePanel _main;
    public static SelectFilePanel main
    {
        get
        {
            if (!_main)
                _main = HUD.main.GetComponentInChildren<SelectFilePanel>();

            return _main;
        }
    }
}
