using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadGallery : MonoBehaviour
{
    public RawImage img;

    private void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/Image"))
        {
            var temp = File.ReadAllBytes(Application.persistentDataPath + "/Image" + "/Profile.jpg");
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(temp);
            img.texture = tex;
        }
    }

    public void OnclickImageLoad()
    {
        NativeGallery.GetImageFromGallery((file) =>
        {
            FileInfo selected = new FileInfo(file);

            //�뷮 ����(50MB)
            if(selected.Length > 50_000_000)
            {
                return;
            }


            //�ҷ�����
            if (!string.IsNullOrEmpty(file))
            {
                StartCoroutine(LoadImage(file));
            }

        });
    }

    IEnumerator LoadImage(string path)
    {

        byte[] fileData = File.ReadAllBytes(path);
        //string fileName = Path.GetFileName(path).Split('.')[0];
        string fileName = "Profile";
        string savePath = Application.persistentDataPath + "/Image";
        
        if(!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        File.WriteAllBytes(savePath + fileName + ".jpg", fileData);

        var temp = File.ReadAllBytes(savePath + fileName + ".jpg");

        Texture2D tex = new Texture2D(0, 0);
        tex.LoadImage(temp);
        img.texture = tex;
        img.SetNativeSize();//���� ũ��� ��������
        ImageSizeSetting(img, 1000, 1000);

        yield return null;
    }

    void ImageSizeSetting(RawImage img, float x, float y)
    {
        var imgX = img.rectTransform.sizeDelta.x;
        var imgY = img.rectTransform.sizeDelta.y;

        
        if(x / y > imgX / imgY)
        {
            //�̹����� ���� ���̰� �� ��ٸ�
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgX * (y / imgY));
        }
        else
        {
            //�̹����� ���� ���̰� �� ��ٸ�
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, imgY * (x / imgX));
        }
    }
}
