using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    //
    // This script will simply instantiate the Prefab when the game starts.
    private void Awake()
    {
        
    }
    void Start()
    {
        GameObject myPrefab;
        GameObject canvas = GameObject.Find("Canvas");
        //// Instantiate at position (0, 0, 0) and zero rotation.
        ////Take Prefab by path
        myPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Image.prefab");
        GameObject bg = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        bg.name = "Background";
        bg.transform.SetParent(canvas.transform);

        RectTransform rectA = bg.GetComponent<RectTransform>();
        rectA.offsetMin = Vector2.zero;
        rectA.offsetMax = Vector2.zero;
        rectA.localScale = Vector3.one;
        rectA.localPosition = Vector3.zero;

        //Get TextContent from AssetBundles
        GameObject myText = new GameObject("ContentText");




        //var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles\\imagebundle"));
        //if (myLoadedAssetBundle == null)
        //{
        //    Debug.Log("Failed to load AssetBundle!");
        //    return;
        //}

        //var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("MyObject");
        //Debug.Log(prefab);
        //Instantiate(prefab);

        //myLoadedAssetBundle.Unload(false);

    }
}