using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    public float speed = 3.0f;//значение скорости движения и расстояния

    public float obstacleRange = 5.0f;

    private bool _alive;//логическая переменная для слежения
    // Use this for initialization
    void Start()
    {
        _alive = true; //делаем жизнь в начале истинной
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);//непрерывно движемся вперед в каждом кадре
            Ray ray = new Ray(transform.position, transform.forward);//луч в том же положении и направлении, что и персонаж
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {//бросаем луч с описанной окружностью
                GameObject hitObject = hit.transform.gameObject;
                 if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);//Поворот с наполовину случайным значение
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {//открывает метод,который из вне позволяет воздействовать на переменную
        _alive = alive;
    }
}
