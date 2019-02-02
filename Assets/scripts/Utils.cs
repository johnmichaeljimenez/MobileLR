using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class Utils {

	public static void SetOnClickListener(this Button b, UnityAction a)
	{
		b.onClick.RemoveAllListeners();
		b.onClick.AddListener(a);
	}

}
