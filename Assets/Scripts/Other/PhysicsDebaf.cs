using UnityEngine;

public class PhysicsDebaf : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject phone;

    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite debafSprite;


    private SpriteRenderer spriteRenderer;

    private float forceGravity = 2f;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = phone.GetComponent<SpriteRenderer>();

    }
    public void PhysicsDebafOn()
    {
        rigidbody2D.gravityScale = forceGravity;
        spriteRenderer.sprite = debafSprite;
    }

    public void PhysicsDebafOff()
    {
        rigidbody2D.gravityScale = 0;
        spriteRenderer.sprite = defaultSprite;
    }

}
