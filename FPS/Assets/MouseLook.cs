using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
       public enum RotationAxes // Обозначаем структуру данных
       {
           MouseXAndY = 0, //Элементы структуры
           MouseX = 1,
           MouseY = 2
       }

       public RotationAxes axes = RotationAxes.MouseXAndY; // Обозначаем переменную структуры (данная переменная будет отображаться в Inspector)

       public float sensitivityHor = 9.0f; // Переменная скорости по горизонтали

       void Update () {

           if(axes == RotationAxes.MouseX){ // если мы выберем MouseX в инспекторе

            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); //Метод GetAxis - выдает нам число (1, 0 или -1 в зависимости от направления движения), класс Input - обрабатывает сигнал с устройства ввода (в данном случае мышь), мы поворачиваемся вокруг оси Y в плоскости X.

           } else if(axes == RotationAxes.MouseY){ // если мы выберем MouseY в инспекторе
        
           } else { // если мы выберем MouseXAndY в инспекторе
           
        }
    }
}
