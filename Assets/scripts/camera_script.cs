using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 10f;

    void LateUpdate()
    {
        Vector3 camPos = transform.position;

        // only follow X
        camPos.x = Mathf.Lerp(camPos.x, player.position.x, followSpeed * Time.deltaTime);

        transform.position = camPos;

    }
}