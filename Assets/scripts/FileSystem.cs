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

		l = JsonUtility.FromJson<LineContents>(File.ReadAllText(fullPath)).lines;

		return l;
	}

	public static bool SaveFile(string fileName)
	{
		string fullPath = directory + fileName + fileExtension;

		string str = "{}";
		if (LineWorld.main.lines.Count > 0)
		{
			LineContents lc = new LineContents();
			lc.lines = LineWorld.main.lines;

			str = JsonUtility.ToJson(lc);
		}

		File.WriteAllText(fullPath, str);
		return true;
	}

	public static List<LineFile> GetFiles()
	{
		List<LineFile> l = new List<LineFile>();
		foreach (string i in Directory.GetFiles(directory))
		{
			LineFile n = new LineFile();
			n.fullPath = i;
			n.fileName = Path.GetFileNameWithoutExtension(i);

			l.Add(n);
		}

		return l;
	}
}

public struct LineFile
{
	public string fileName, fullPath;
}

[System.Serializable]
public struct LineContents
{
	public List<Line> lines;
}