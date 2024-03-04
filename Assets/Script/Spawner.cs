﻿using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    // устанавливающее скорость появления объектов (время между спаунами).
    public float spawnRate = 1f;
    //устанавливающее минимальную высоту, на которой будут появляться объекты.
    public float minHeight = -1f;
    // устанавливающее максимальную высоту, на которой будут появляться объекты.
    public float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);

        //Смещение позиции созданного объекта по вертикали (Vector3.up) на случайное значение между minHeight и maxHeight.
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}