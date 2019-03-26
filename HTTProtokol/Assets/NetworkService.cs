using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkService : MonoBehaviour {

    public float time = 10f; /*Число например 10 сек */

    [SerializeField] private GameObject plane;

    [SerializeField] private GameObject cube;

    private IEnumerator Loaded()
    {
        Debug.Log("Прошло 10 сек!");
        WWW www = new WWW("https://avatars.mds.yandex.net/get-pdb/33827/dec5de85-45e8-4874-ac6a-c8206b95aee0/s1200?webp=false");
        yield return www;
        Texture2D texture = www.texture;

        plane.GetComponent<Renderer>().material.mainTexture = texture;
        cube.GetComponent<Renderer>().material.mainTexture = texture;
    }

    private IEnumerator Start()
    {
        print("Downloading from the web");//выводим сообщеие о начале загрузки
       WWW www = new WWW("https://avatars.mds.yandex.net/get-pdb/805781/bdbb5c1d-8dad-40cf-88bd-6934ad39ca39/s1200");
        yield return www;
        Texture2D texture = www.texture;

        plane.GetComponent<Renderer>().material.mainTexture = texture;//присваиваем компоненту загруженную текстуру
        cube.GetComponent<Renderer>().material.mainTexture = texture;
    }

    void Update()
    {
        if (time > 0)
        {
            time = time - Time.deltaTime;

            if (time < 0)
            {
                StartCoroutine("Loaded");
            }
        }
    }
}
