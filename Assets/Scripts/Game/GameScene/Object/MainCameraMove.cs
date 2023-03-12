using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    public Transform targetPos;
    public float high = 3;
    public float followSpeed = 5;
    public float rotateSpeed = 5;
    public float lookAtRad = 30;
    public float toTargetDis = 10;

    private Vector3 highPos;
    private Vector3 followPos;
    private Vector3 dir;

    void Update()
    {
        highPos = targetPos.position + high * targetPos.up;
        dir = Quaternion.AngleAxis(lookAtRad, targetPos.right) * -targetPos.forward ;
        followPos = highPos + dir * toTargetDis;

        transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime * followSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-dir), Time.deltaTime * rotateSpeed);
    }
}
