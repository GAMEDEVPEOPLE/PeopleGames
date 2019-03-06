using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    Animator m_animator;//создаем экземпляр класса Animator

    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();//присваиваем экземпляру класса компонент Animator (который находится в кубе)

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {//при нажатии на клавишу мыши
            m_animator.SetBool("Go", true); //параметр Go меняется на true

        }
    }
}
