using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ImageURLTest : MonoBehaviour { 
    
    public Image image;
    public string TextureURL = "https://miro.medium.com/v2/resize:fit:1200/1*3kPOI1_HGuE0fPWBj_jnog.png"; 
    void Start() { 
        StartCoroutine(DownloadImage(TextureURL)); 
    } 
    IEnumerator DownloadImage(string MediaUrl) { 
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl); 
        yield return request.SendWebRequest(); 
        if (request.isNetworkError || request.isHttpError) Debug.Log(request.error); 
        else {
            Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D; Sprite webSprite = SpriteFromTexture2D(webTexture); 
            image.sprite = webSprite; 
        } 
    } 
    Sprite SpriteFromTexture2D(Texture2D texture) {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f); 
    } 
}
