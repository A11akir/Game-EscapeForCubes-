using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWalk : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0.2f, -0.2f, 0f);
    private float followSpeed = 20f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 1f / followSpeed);

            transform.rotation = target.rotation;
        }
    }
}
