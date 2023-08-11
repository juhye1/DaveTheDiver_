using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDir = "Assets/StreamingAssets";
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDir);
        }

        BuildPipeline.BuildAssetBundles(assetBundleDir, BuildAssetBundleOptions.None,
            EditorUserBuildSettings.activeBuildTarget);
    }
}
