using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageData : MonoBehaviour
{
    public List<ImageInfo> images;
    public Sprite selectedImg;
    public GameObject imagePopup;

    [Serializable]
    public class ImageInfo{
        public Sprite clip;
        public int id;
    }

    // Start is called before the first frame update
    void Start()
    {
        Events.ShowImgPopup += ShowImage;
    }

    private void OnDestroy() {
        Events.ShowImgPopup -= ShowImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage(int id) {
        ImageData.ImageInfo imgInfo = images.Find(x => x.id == id);
        if (imgInfo != null) 
            selectedImg = imgInfo.clip;        
        imagePopup.SetActive(true);
    }
}
