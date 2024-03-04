using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

//массив куда будем записывать изменения спрайтов
   public Sprite[] sprites;
    public float gravity = -9.81f;
    public float strength = 5f;

   private SpriteRenderer spriteRenderer;
   private Vector3 direction;
   private int spriteIndex;

   //метод вызывается при первом активировании объекта на сцене. 
      private void Awake()
    {
        //отвечает за получение ссылки на компонент SpriteRenderer текущего объекта
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //который вызывается один раз при запуске сцены, перед тем, как начнется выполнение Update()
      private void Start()
    {
        //AnimateSprite() будет вызываться с интервалом в 0.15 секунды начиная с момента старта сцены.
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }


     // задаем изменения  
     private void Update()
     {
          //при нажатии на пробел или на левую кнопку мыши сработает гравитацияБ
          if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
       {
            //устанавливаем направление навверх умноженное на силу 
            direction = Vector3.up * strength;
        }
        // Применяется гравитация к объекту путем изменения его вертикальной компоненты.
        direction.y += gravity * Time.deltaTime;

        // Обновляется позиция объекта в пространстве, учитывая направление и текущую скорость.
        transform.position += direction * Time.deltaTime;


     }


     private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

  private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.tag == "Obstacle") {
        FindObjectOfType<GameManager>().GameOver();
    } else if (other.gameObject.tag == "Scoring") {
        FindObjectOfType<GameManager>().IncreaseScore();
    }
}
}
