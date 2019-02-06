using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFilePanel : MonoBehaviour {

    private static SelectFilePanel _main;
    public static SelectFilePanel main
    {
        get
        {
            if (!_main)
                _main = HUD.main.GetComponentInChildren<SelectFilePanel>(true);

            return _main;
        }
    }

    public static SelectionType selectionType;

    public Button selectButton, deleteButton;
    public Button closeButton;
    public GameObject fileItemPrefab;
    public Transform fileItemContainer;

    public static void Load()
    {
        SelectFileItem.currentSelected = null;
        Show(SelectionType.Load);
    }

    public void LoadSelected()
    {
        if (!SelectFileItem.currentSelected)
            return;

        LineWorld.main.lines = FileSystem.OpenFile(SelectFileItem.currentSelected.myFile.fileName);
        gameObject.SetActive(false);
        LineWorld.main.DrawLines();
    }

    public static void Delete()
    {
        if (!SelectFileItem.currentSelected)
            return;

        
    }
    
    public static void Save()
    {
        FileSystem.SaveFile("test");

        //TODO: create a new filename saving system
        // Show(SelectionType.Save);
    }

    public static void Show(SelectionType s)
    {
        SelectFileItem.Select(null);

        for (int i = main.fileItemContainer.childCount - 1; i >= 0 ; i--)
        {
            Destroy(main.fileItemContainer.GetChild(i).gameObject);
        }

        foreach (LineFile i in FileSystem.GetFiles())
        {
            GameObject g = Instantiate(main.fileItemPrefab);
            g.transform.SetParent(main.fileItemContainer, false);

            SelectFileItem f = g.GetComponent<SelectFileItem>();
            f.Set(i);
        }

        main.selectButton.SetOnClickListener(()=>{
            main.LoadSelected();
        });

        main.deleteButton.SetOnClickListener(()=>{

        });
        
        main.closeButton.SetOnClickListener(()=>{
            main.gameObject.SetActive(false);
        });
        main.gameObject.SetActive(true);
    }

    public enum SelectionType
    {
        Load, Save
    }
}
