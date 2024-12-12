using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IContollable
{
    private int speed = 4;
    private bool isStunned = false;
    public int Speed
    {
        get => speed;
        set
        {
            speed = (value >= 0) ? value : 0;
        }
    }
    public Vector3 Move(Vector3 direction)
    {
        return transform.position += direction;
    }

    public void ApplyStan(float delay)
    {
        if (isStunned) return;

        StartCoroutine(StanCoroutine(delay));
    }

    private IEnumerator StanCoroutine(float delay)
    {
        isStunned = true;
        int originalSpeed = Speed;
        Speed = 0;

        yield return new WaitForSeconds(delay);

        Speed = originalSpeed;
        isStunned = false;
    }
}
