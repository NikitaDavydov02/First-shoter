using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public static class TestPostBuild {
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuildObject)
    {
        Debug.Log("build location: " + pathToBuildObject);
    }
}
