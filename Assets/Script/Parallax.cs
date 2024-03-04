﻿using UnityEngine;

public class Parallax : MonoBehaviour
{
    //определяет скорость анимации параллакса
    public float animationSpeed = 1f;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        // Это создает эффект параллакса, где фон двигается с разной скоростью относительно других элементов сцены.
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }

}