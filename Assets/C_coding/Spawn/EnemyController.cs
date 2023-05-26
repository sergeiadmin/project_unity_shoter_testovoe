using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 movementDirection; // Направление движения врага
    private float moveSpeed; // Скорость движения врага
    private int damageAmount; // Количество отнимаемых жизней при столкновении с врагом
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
        // Получение компонента Health из gameObject
        health = Main_Player.GetComponent<Health>();
        //gameObject.SetActive(true);

    }

    public void Update()
    {
        
     
        
        // Движение врага в заданном направлении
        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    
    }



}
