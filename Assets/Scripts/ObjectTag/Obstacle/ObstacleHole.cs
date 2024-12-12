using System.Collections;
using UnityEngine;

public class ObstacleHole : ObjectTag, IObstacle
{
    [SerializeField] private int expCount = 1;

    [SerializeField] public float delayHole = 2f;
    [SerializeField] float maxAttractionRadius = 10f;
    [SerializeField] float maxAttractionForce = 15f;
    [SerializeField] float minAttractionForce = 1f;
    [SerializeField] float rotationForce = 15f;

    private bool delayReady = false;

    private void Awake()
    {
        objectTagEnum = ObjectTagEnum.ObstacleHole;
    }

    private void OnEnable()
    {
        this.StartCoroutine(HoleDelay());
    }

    private void OnDisable()
    {
        this.StopCoroutine(HoleDelay());
    }

    private void Update()
    {
        if (delayReady == true)
        {
            BlackHole();
        }
    }

    private IEnumerator HoleDelay()
    {
        yield return new WaitForSeconds(delayHole);

        delayReady = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.transform.TryGetComponent(out IObstacle objectTag) && !col.transform.TryGetComponent(out PlayerTrigger player))
        {
            col.gameObject.SetActive(false);
        }
    }

    private void BlackHole()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, maxAttractionRadius);

        foreach (Collider2D colider in objectsInRange)
        {
            if (!colider.transform.TryGetComponent(out IObstacle objectTag) && !colider.transform.TryGetComponent(out PlayerTrigger player)
                && !colider.transform.TryGetComponent(out IWall wall))
            {

                float distance = Vector2.Distance(transform.position, colider.transform.position);
                if (distance > 0f)
                {
                    float attractionForce = Mathf.Lerp(maxAttractionForce, minAttractionForce, distance / maxAttractionRadius);

                    Vector2 direction = (transform.position - colider.transform.position).normalized;

                    colider.attachedRigidbody?.AddForce(direction * attractionForce);

                    colider.transform.Rotate(Vector3.forward, 20 * Time.deltaTime);

                }
            }
            
        }      
    }  

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxAttractionRadius);
    }
}
