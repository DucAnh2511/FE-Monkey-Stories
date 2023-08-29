using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour
{

    private Camera cam;
    private void Awake()
    {
        cam = FindAnyObjectByType<Camera>();
    }
    void Start()
    {
        GameObject myGO;
        GameObject myText;
        Canvas myCanvas;
        TextMeshPro text;
        RectTransform rectText,rectCanvas,rectImg;
        GameObject myBackground;
        RawImage img;

        // Canvas
        List<Type> types;
        types = new List<Type>();
        types.Add(typeof(Canvas));
        
        myGO = new GameObject("Canvas", types.ToArray());       

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.planeDistance = 5;
        rectCanvas = myCanvas.GetComponent<RectTransform>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myCanvas.rootCanvas.renderMode |= RenderMode.ScreenSpaceCamera;
        myCanvas.rootCanvas.worldCamera = cam;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "ContentText";

        text = myText.AddComponent<TextMeshPro>();
        text.text = "Welcome!";
        text.color = Color.black;
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 550;

        // Text position
        rectText = text.GetComponent<RectTransform>();
        //Need data positon
        rectText.localPosition = new Vector3(0, 490, 0);
        rectText.localScale = Vector3.one;
        rectText.sizeDelta = new Vector2(1500, 200);

        // Image

        myBackground = new GameObject();
       
        myBackground.name = "Background";
        myBackground.transform.parent = myGO.transform;
        myBackground.AddComponent<RawImage>();

        
        //them img
        GameObject anhmoi;
        anhmoi = new GameObject("BG2");
        anhmoi.AddComponent<Image>();
        anhmoi.transform.parent = myGO.transform;
        Image tmp;
        tmp = anhmoi.GetComponent<Image>();
        String imgPath2 = "Assets/Images/Page2.png";
        tmp.sprite = Resources.Load<Sprite>(imgPath2);



        img = myBackground.GetComponent<RawImage>();
        rectImg = myBackground.GetComponent<RectTransform>();

        Screen screen = new Screen();
        Debug.Log(rectImg.sizeDelta);
        rectImg.sizeDelta = new Vector2(rectCanvas.rect.width,rectCanvas.rect.height);
        rectImg.localScale = Vector3.one;

        //Get image url path
        string imagePath = "Assets/Images/Page1.png"; // Thay đổi đường dẫn tới hình ảnh của bạn
        Texture2D tex = new Texture2D(Screen.width, Screen.height); // Tạo một Texture2D mới
        byte[] imgData = System.IO.File.ReadAllBytes(imagePath); // Đọc dữ liệu hình ảnh từ đường dẫn
        bool success = tex.LoadImage(imgData); // Tải hình ảnh vào texture

        if (success)
        {
            img.texture = tex; // Gán texture vào RawImage
        }
        else
        {
            Debug.LogError("Failed to load image");
        }

    }
}
