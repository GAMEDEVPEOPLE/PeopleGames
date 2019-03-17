using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour {


    [SerializeField] private MemoryCard originalCard;//ссылка для карты в сцене
    [SerializeField] private Sprite[] images;//массив ссылок на ресурсы-спрайты

    void Start()
    {
        int id = Random.Range(0, images.Length);
        originalCard.SetCard(id, images[id]);//вызов открытого метода в MemoryCard
    }


    void Update() 
    {

    }

}
