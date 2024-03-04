﻿using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Публичные поля для хранения ссылок на Transform верхней части трубы.
    public Transform top;
    public Transform bottom;
    //устанавливает скорость движения труб
    public float speed = 5f;

    //переменная для хранения координаты x левого края экрана.
    private float leftEdge;

    private void Start()
    {   //Установка значения переменной leftEdge равным x-координате нулевой точки (левого нижнего угла экрана), преобразованной в мировые координаты, минус 1.
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
        // Изменение позиции объекта влево с учетом скорости и времени.
        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }

}