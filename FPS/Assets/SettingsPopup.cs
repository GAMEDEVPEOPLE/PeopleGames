using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);//активируем этот объект, чтобы открыть окно
    }
    public void Close()
    {
        gameObject.SetActive(false);//диактивируем объект, чтобы закрыть окно
    }

}
