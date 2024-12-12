using DG.Tweening;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private Sprite defaultPlayer;
    [SerializeField] private Sprite rightPlayer;
    [SerializeField] private Sprite leftPlayer;
    [SerializeField] private Sprite upPlayer;
    [SerializeField] private Sprite downPlayer;

    private SpriteRenderer spriteRenderer;
    private bool isMoving;

    private GameInput gameInput;

    public Vector3 rotationRight = new Vector3(0f, 0f, 30f);
    public Vector3 rotationLeft = new Vector3(0f, 0f, -30f);
    public Vector3 rotationDefault = new Vector3(0f, 0f, 0f);
    public float duration = 0.5f;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameInput = new GameInput();

        gameInput.Gameplay.MoveRight.performed += context => RightMove();
        gameInput.Gameplay.MoveLeft.performed += context => LeftMove();
        gameInput.Gameplay.MoveUp.performed += context => UpMove();
        gameInput.Gameplay.MoveDown.performed += context => DownMove();

        gameInput.Gameplay.MoveRight.performed += context => StartMoving(rightPlayer);
        gameInput.Gameplay.MoveLeft.performed += context => StartMoving(leftPlayer);
        gameInput.Gameplay.MoveUp.performed += context => StartMoving(upPlayer);
        gameInput.Gameplay.MoveDown.performed += context => StartMoving(downPlayer);

        gameInput.Gameplay.MoveRight.canceled += context => StopMoving();
        gameInput.Gameplay.MoveLeft.canceled += context => StopMoving();
        gameInput.Gameplay.MoveUp.canceled += context => StopMoving();
        gameInput.Gameplay.MoveDown.canceled += context => StopMoving();
    }
    
    private void RightMove()
    {
        spriteRenderer.sprite = rightPlayer;

        transform.DORotate(rotationLeft, duration);
    }
    private void LeftMove()
    {
        spriteRenderer.sprite = leftPlayer;

        transform.DORotate(rotationRight, duration);
    }
    private void UpMove()
    {
        spriteRenderer.sprite = upPlayer;
    }
    private void DownMove()
    {
        spriteRenderer.sprite = downPlayer;
    }

    private void StartMoving(Sprite directionSprite)
    {
        isMoving = true;
        spriteRenderer.sprite = directionSprite;
    }

    private void StopMoving()
    {
        isMoving = false;

        if (!gameInput.Gameplay.MoveRight.IsPressed() &&
            !gameInput.Gameplay.MoveLeft.IsPressed() &&
            !gameInput.Gameplay.MoveUp.IsPressed() &&
            !gameInput.Gameplay.MoveDown.IsPressed())
        {
            spriteRenderer.sprite = defaultPlayer;
            transform.DORotate(rotationDefault, duration);
        }
    }
}
