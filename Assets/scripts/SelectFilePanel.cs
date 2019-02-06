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
                _main = HUD.main.GetComponentInChildren<SelectFilePanel>();

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
        Show(SelectionType.Load);
    }
    
    public static void Save()
    {
        Show(SelectionType.Save);
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
