using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float rotationSpeed = 50f; // Скорость вращения

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // 
    }
}
