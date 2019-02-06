using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageToast : MonoBehaviour {


    private static MessageToast _main;
    public static MessageToast main
    {
        get
        {
            if (!_main)
                _main = HUD.main.GetComponentInChildren<MessageToast>(true);

            return _main;
        }
    }

    public float duration = 5;
    float t;
    public static void Show(string str)
    {
        main.GetComponentInChildren<Text>(true).text = str;

        main.t = main.duration;
        main.gameObject.SetActive(true);
    }

    void Update()
    {
        t -= Time.unscaledDeltaTime;
        if (t <= 0)
        {
            t = 0;
            gameObject.SetActive(false);
        }
    }
}
