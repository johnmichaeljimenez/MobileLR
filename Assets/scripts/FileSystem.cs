using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileSystem : MonoBehaviour {

    private static FileSystem _main;
    public static FileSystem main
    {
        get
        {
            if (!_main)
                _main = GameObject.FindObjectOfType<FileSystem>();

            return _main;
        }
    }

	const string fileExtension = ".mlr";
	static string directory
	{
		get
		{
			return Application.persistentDataPath + "/";
		}
	}

	public static List<Line> OpenFile(string fileName)
	{
		List<Line> l = new List<Line>();

		string fullPath = directory + fileName + fileExtension;

		return l;
	}
}
