using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour {

    public const int gridRows = 2;//значения, количество ячеей в сетки и их расстояние друг от друга
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    private int _score = 0;
    public TextMesh scoreLabel;


    [SerializeField] private MemoryCard originalCard;//ссылка для карты в сцене
    [SerializeField] private Sprite[] images;//массив ссылок на ресурсы-спрайты

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    public bool canReveal
    {
        get { return _secondRevealed == null; } //Функция чтения, которая возвращает значения false, если 2-я карта уже открыта
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        { //сохранение карт в переменные
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;

            StartCoroutine(CheckMatch()); //Вызывает сопрограмму, после двух карт

            Debug.Log("Match? " + (_firstRevealed.id == _secondRevealed.id)); //сравнение 2-х карт
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++; // Увеличиваем счет на единицу, если идентификаторы открытых карт совпадают.
            Debug.Log("Score: " + _score);
            scoreLabel.text = "Score:" + _score;//отображаем текст.
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal(); // Закрытие несовпадающих карт.
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null; // Очистка переменных вне зависимости от того, было ли совпадение.
        _secondRevealed = null;
    }

    void Start()
    {
        Vector3 startPos = originalCard.transform.position;//Положение первой карты, остальные от этой точки
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 }; //объявляем параметры индентификторов 4-х спрайтов
        numbers = ShuffleArray(numbers); // Вызов функции, перемешивающей элементы массива.

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            { // вложенные циклы, задающие как столбцы, так и строки
                MemoryCard card; // Ссылка на контейнер для исходной карты или ее копий.
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int index = j * gridCols + i;
                int id = numbers[index]; // Получаем идентификаторы из перемешанного 
                card.SetCard(id, images[id]);//вызов открытого метода в MemoryCard
                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);//в 2d смещаемся только по x  и y
            }

        }
    }

    private int[] ShuffleArray(int[] numbers)
    { // Реализация алгоритма тасования Кнута.
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }



    void Update() 
    {

    }

}
