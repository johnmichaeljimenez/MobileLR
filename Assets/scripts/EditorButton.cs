using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorButton : MonoBehaviour {

	public static Button current;

	public LineEditor.LineEditMode toolType;

	void Start()
	{
		GetComponent<Button>().SetOnClickListener(()=>{
			LineEditor.main.SetEditMode(toolType);
		});
	}

	public static void SetCurrent(Button e)
	{
		if (!current && !e)
			return;

		if (current)
		{
			current.GetComponent<Image>().color = new Color(1, 1, 1);
		}

		current = e;
		current.GetComponent<Image>().color = new Color(1,1,1,0.8f);

		bool ok = PlaybackManager.isPlaying != PlaybackManager.PlayStates.Playing;
		current.interactable = ok;
	}

}
