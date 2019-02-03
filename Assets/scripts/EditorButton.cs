using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorButton : MonoBehaviour {

	public static Button current;

	public LineEditor.LineEditMode toolType;

	public Shadow shadow;

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
			current.GetComponent<EditorButton>().shadow.enabled = false;
		}

		current = e;
		current.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f);

		bool ok = PlaybackManager.isPlaying != PlaybackManager.PlayStates.Playing;
		current.interactable = ok;
		current.GetComponent<EditorButton>().shadow.enabled = ok;
	}

}
