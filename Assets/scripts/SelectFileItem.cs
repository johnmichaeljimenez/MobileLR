using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFileItem : MonoBehaviour {

	public static SelectFileItem currentSelected;

	public LineFile myFile;

	public void Set(LineFile l)
	{
		myFile = l;
		GetComponentInChildren<Text>().text = l.fileName;

		GetComponentInChildren<Button>().SetOnClickListener(()=>{

		});
	}

	public static void Select(SelectFileItem i)
	{
		SelectFilePanel.main.deleteButton.gameObject.SetActive(i);
		SelectFilePanel.main.selectButton.gameObject.SetActive(i);

		if (!currentSelected && !i)
		{		
			return;
		}

		if (currentSelected)
		{
			currentSelected.GetComponent<Image>().color = new Color(1,1,1,1);
		}

		currentSelected = i;
		currentSelected.GetComponent<Image>().color = new Color(1,1,1,0.8f);
	}

}
