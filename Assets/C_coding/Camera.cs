using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Настройки камеры слежения")]
    public Transform player;
    public float followSpeed = 2f;
    public float minDistance = 1f;
    public float minY = 0f;
    public float maxY = 5f;
    public LayerMask obstacleLayer;

    private Vector3 targetPosition;

    void Update()
    {
        Vector3 fireflyPosition = transform.position;
        Vector3 playerPosition = player.position;
        float distanceBetweenObjects = Vector3.Distance(fireflyPosition, playerPosition);

        if (distanceBetweenObjects > minDistance)
        {
            float targetY = Mathf.Clamp(playerPosition.y, minY, maxY);
            targetPosition = new Vector3(playerPosition.x, targetY, playerPosition.z);
            transform.position = Vector3.MoveTowards(fireflyPosition, targetPosition, followSpeed * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Raycast(fireflyPosition, targetPosition - fireflyPosition, out hit, distanceBetweenObjects, obstacleLayer))
            {
                transform.position = hit.point;
            }
        }
    }
}
