using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerBehavior : BaseBehavior
{
    public float moveSpeed = 5.0f; // Скорость перемещения объекта
    Vector3 moveDirection;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private PlayerSetBehavior setter;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        setter = GetComponent<PlayerSetBehavior>();
    }
    public override void Update()
    {
        SetAnimation();
        Move();
        CheckRoatation();
    }

    private void CheckRoatation()
    {
        if (moveDirection.x < 0) sr.flipX = true;
        else if (moveDirection.x > 0) sr.flipX = false;
    }

	private void Move()
	{
        // Получаем ввод от клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем вектор перемещения
        moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);

        // Нормализуем вектор, чтобы движение было равномерным при движении по диагонали
        moveDirection.Normalize();

        // Перемещаем объект
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void SetAnimation()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                setter.Behavior = PlayerSetBehavior.Behaviors.WalkSide;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                setter.Behavior = PlayerSetBehavior.Behaviors.WalkUp;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                setter.Behavior = PlayerSetBehavior.Behaviors.WalkDown;
            }
        }
        else
        {
			if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkSide)
			{
                setter.Behavior = PlayerSetBehavior.Behaviors.IdleSide;
            }
            if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkUp)
            {
                setter.Behavior = PlayerSetBehavior.Behaviors.IdleUp;
            }
            if (setter.Behavior == PlayerSetBehavior.Behaviors.WalkDown)
            {
                setter.Behavior = PlayerSetBehavior.Behaviors.IdleDown;
            }
        }
         
    }


}

