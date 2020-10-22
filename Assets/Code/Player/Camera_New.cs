using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_New : MonoBehaviour
{
    // Inspired partly by unity answers and camera clamp by Alexander
    public PlayerControls thePlayer;

    public Vector3 offset;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    private float yDistance;
    public float smoothSpeed = 0.125f;

    public float xMin;
    public float xMax;

    private void Start()
    {

        thePlayer = FindObjectOfType<PlayerControls>();
        lastPlayerPosition = thePlayer.transform.position;
    }
    private void Update()
    {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
        yDistance = thePlayer.transform.position.y - lastPlayerPosition.y;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + distanceToMove, xMin, xMax),
            (transform.position.y + yDistance),
            transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;
    }
    void FixedUpdate()
    {
        Vector3 desiredPostion = lastPlayerPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
