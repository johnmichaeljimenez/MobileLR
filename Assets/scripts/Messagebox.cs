using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Messagebox : MonoBehaviour {

    private static Messagebox _main;
    public static Messagebox main
    {
        get
        {
            if (!_main)
                _main = HUD.main.GetComponentInChildren<Messagebox>(true);

            return _main;
        }
    }

	public Text messageText;
	public Button okButton, cancelButton;

	public static void Show(string msg, UnityAction okAction)
	{
		main.messageText.text = msg;
		main.okButton.onClick.RemoveAllListeners();

		if (okAction != null)
		{
			main.okButton.onClick.AddListener(okAction);
		}

		main.okButton.onClick.AddListener(()=>{
			main.gameObject.SetActive(false);
		});
		main.cancelButton.SetOnClickListener(()=>{
			main.gameObject.SetActive(false);
		});

		main.gameObject.SetActive(true);
	}

}
