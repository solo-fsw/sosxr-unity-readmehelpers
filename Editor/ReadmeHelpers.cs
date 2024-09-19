using System.IO;
using UnityEditor;
using UnityEngine;


public static class ReadmeHelpers
{
    public static string FullPath
    {
        get
        {
            var fullPath = Application.dataPath;

            return fullPath;
        }
    }


    /// <summary>
    ///     Creates a README.md file in the Assets folder.
    ///     It grabs a file called README_template.md from a Resources folder.
    /// </summary>
    [MenuItem("Assets/Create/SOSXR/Create README.md file in Assets folder", priority = 50)]
    [MenuItem("SOSXR/Create README.md file in Assets folder", priority = 100)]
    private static void CreateReadmeAtRoot()
    {
        var folderDirectory = Path.GetFullPath(Application.dataPath + "/Assets/..");

        var template = Resources.Load<TextAsset>("README_template"); // From Resources folder

        if (template != null)
        {
            var templateContent = template.text;

            using var sw = File.CreateText(folderDirectory + "/" + "README.md");

            sw.WriteLine("# " + GetProjectName());
            sw.WriteLine(templateContent);
        }
        else
        {
            Debug.LogError("Template file not found in Resources.");
        }

        AssetDatabase.Refresh();
    }


    public static string GetProjectName()
    {
        var split = FullPath.Split('/');

        var projectName = split[^2];

        return projectName;
    }
}