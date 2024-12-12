using System.Collections;
using UnityEngine;

public class ObstacleShuriken : ObjectTag, IObstacle
{
    [SerializeField] private PlayerMovement playerMovement;

    private int delayStan = 2;
    private bool isTrigger = true;
    private float repelForce = 225f;
    private int rotateForce = 550;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotateForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Rigidbody2D rb = col.GetComponent<Rigidbody2D>();

        if (col.transform.TryGetComponent(out PlayerTrigger player))
        {
            if (isTrigger)
            {
                Vector2 direction = (col.transform.position - transform.position).normalized;
                rb.AddForce(direction * repelForce, ForceMode2D.Impulse);

                playerMovement.ApplyStan(delayStan);

                isTrigger = false;
                StartCoroutine(ResetTrigger());
            }
        }
    }

    private IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(delayStan);
        isTrigger = true;
    }
}
