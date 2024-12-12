using DG.Tweening;
using UnityEngine;

public class PlayerSpriteRobot : MonoBehaviour
{
    private GameInput gameInput;

    public Vector3 rotationRight = new Vector3(0f, 0f, -90f);
    public Vector3 rotationLeft = new Vector3(0f, 0f, 90f);
    public Vector3 rotationDown = new Vector3(0f, 0f, 180f);
    public Vector3 rotationDefault = new Vector3(0f, 0f, 0f);
    public float duration = 0.5f;
    public float duration180 = 0.75f;

    private void OnEnable()
    {
        gameInput.Enable();
    }
    private void OnDisable()
    {
        gameInput.Disable();
    }

    private void Awake()
    {
        gameInput = new GameInput();

        gameInput.Gameplay.MoveRight.started += _ => UpdateMovement();
        gameInput.Gameplay.MoveLeft.started += _ => UpdateMovement();
        gameInput.Gameplay.MoveUp.started += _ => UpdateMovement();
        gameInput.Gameplay.MoveDown.started += _ => UpdateMovement();

        gameInput.Gameplay.MoveRight.canceled += _ => UpdateMovement();
        gameInput.Gameplay.MoveLeft.canceled += _ => UpdateMovement();
        gameInput.Gameplay.MoveUp.canceled += _ => UpdateMovement();
        gameInput.Gameplay.MoveDown.canceled += _ => UpdateMovement();
    }

    private void UpdateMovement()
    {
        bool isUpPressed = gameInput.Gameplay.MoveUp.IsPressed();
        bool isDownPressed = gameInput.Gameplay.MoveDown.IsPressed();
        bool isLeftPressed = gameInput.Gameplay.MoveLeft.IsPressed();
        bool isRightPressed = gameInput.Gameplay.MoveRight.IsPressed();

        if (isUpPressed)
        {
            UpMove();
        }
        else if (isDownPressed)
        {
            if (isLeftPressed)
            {
                LeftMove();
            }
            else if (isRightPressed)
            {
                RightMove();
            }
            else
            {
                DownMove();
            }
        }
        else if (isLeftPressed)
        {
            LeftMove();
        }
        else if (isRightPressed)
        {
            RightMove();
        }
        else
        {
            StopMoving();
        }
    }

    private void RightMove()
    {
        transform.DORotate(rotationRight, duration);
    }

    private void LeftMove()
    {
        transform.DORotate(rotationLeft, duration);
    }

    private void UpMove()
    {
        transform.DORotate(rotationDefault, duration);
    }

    private void DownMove()
    {
        transform.DORotate(rotationDown, duration180);
    }

    private void StopMoving()
    {
        if (!gameInput.Gameplay.MoveRight.IsPressed() &&
            !gameInput.Gameplay.MoveLeft.IsPressed() &&
            !gameInput.Gameplay.MoveUp.IsPressed() &&
            !gameInput.Gameplay.MoveDown.IsPressed())
        {
            transform.DORotate(rotationDefault, duration);
        }
    }
}
