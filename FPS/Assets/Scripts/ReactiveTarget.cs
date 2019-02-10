using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit()
    {//метод, вызванный сценарием стрельбы
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {//проверяем, есть ли сценарий WanderingAI
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }


    private IEnumerator Die()
    {//Опрокидываем врага, ждем 1,5 секунды и уничтожаем его
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);//объект может уничтожить сам себя
    }

}
