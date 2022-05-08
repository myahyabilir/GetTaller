using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform follow;
    public Vector3 offset;

    void Update ()
    {
        Vector3 positionWithOffset = follow.position + offset;
        Vector3 desiredPos = Vector3.Lerp(transform.position, positionWithOffset, 15 * Time.deltaTime);
        transform.position = desiredPos;
    }

}