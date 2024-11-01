using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraSwitch : MonoBehaviour
{
    // Tüm kameraları saklayacağımız bir liste oluşturuyoruz
    public List<Camera> cameras = new List<Camera>();

    void Start()
    {
        // Sahnedeki tüm kameraları bul ve isimlerine göre sıralayarak listeye ekle
        cameras = FindObjectsOfType<Camera>().OrderBy(cam => cam.name).ToList();

        // İlk kamerayı etkinleştir, diğerlerini devre dışı bırak
        for (int i = 0; i < cameras.Count; i++)
        {
            cameras[i].gameObject.SetActive(i == 0);
        }
    }

    void Update()
    {
        // 1 ile 9 arasındaki tuşlara basıldığını kontrol ediyoruz
        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                SwitchCamera(i - 1);
            }
        }
    }

    void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameras.Count)
        {
            // Tüm kameraları devre dışı bırakıyoruz
            foreach (var cam in cameras)
            {
                cam.gameObject.SetActive(false);
            }
            // İlgili kamerayı aktif hale getiriyoruz
            cameras[index].gameObject.SetActive(true);
        }
    }
}
