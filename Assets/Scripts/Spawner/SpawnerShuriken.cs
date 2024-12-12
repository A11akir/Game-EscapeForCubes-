using UnityEngine;

public class SpawnerShuriken : MonoBehaviour
{
    private Vector2 startPoint;
    private Vector2 endPoint;

    private int leftSide = 20;
    private int rightSide = -20;
    private int currentSide;

    private float progress = 0f;
    private float movementSpeed = 0.5f;
    private float arcHeight = 2f;

    private bool isMoving = false;

    private void OnEnable()
    {
        InitializeShuriken();
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveShuriken();
        }
    }

    private void InitializeShuriken()
    {
        currentSide = Random.value > 0.5f ? leftSide : rightSide;

        startPoint = new Vector2(currentSide, Random.Range(9f, -9f));
        endPoint = new Vector2(-currentSide, Random.Range(9f, -9f));

        transform.position = startPoint;

        progress = 0f;

        isMoving = true;
    }

    private void MoveShuriken()
    {
        if (progress < 1f)
        {
            progress += Time.deltaTime * movementSpeed;

            Vector2 linearPosition = Vector2.Lerp(startPoint, endPoint, progress);

            float heightOffset = Mathf.Sin(progress * Mathf.PI) * arcHeight;
            Vector2 arcPosition = new Vector2(linearPosition.x, linearPosition.y + heightOffset);

            transform.position = arcPosition;
        }
        else
        {
            Invoke("Inactive", 3);
        }
    }

    private void Inactive()
    {
        gameObject.SetActive(false);
    }
}
