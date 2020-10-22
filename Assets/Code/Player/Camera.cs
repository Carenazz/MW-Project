using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float min;
    public float max;


    private void Awake()
    {

    }
    private void Update()
    {
        // Clamping Inspired by Alexander Zotov
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, min, max),
            transform.position.y,
            transform.position.z);

    }
    void FixedUpdate()
    {
        // Camera smoothing Inspired by Brackeys

        Vector3 desiredPostion = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
