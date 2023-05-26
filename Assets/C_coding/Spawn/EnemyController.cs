using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 movementDirection; // ����������� �������� �����
    private float moveSpeed; // �������� �������� �����
    private int damageAmount; // ���������� ���������� ������ ��� ������������ � ������
    public GameObject Main_Player;
    public GameObject EnemyObject;

    private Health health;
    private EnemyController EnemyController1;

    private bool isDestroyed = false;
    public void SetMovementDirection(Vector3 direction, float speed, int damage)
    {
        movementDirection = direction;
        moveSpeed = speed;
        damageAmount = damage;
    }

    public void Start()
    {
        // ��������� ���������� Health �� gameObject
        health = Main_Player.GetComponent<Health>();
        //gameObject.SetActive(true);

    }

    public void Update()
    {
        
     
        
        // �������� ����� � �������� �����������
        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    
    }



}
