using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Скорость снаряда
    public int damage = 10; // Урон снаряда

    

    private void Start()
    {
        // Задаем начальную скорость движения снаряда
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Получаем компонент Health у объекта, с которым столкнулся снаряд
        Health health = other.GetComponent<Health>();

        // Если у объекта есть компонент Health, наносим ему урон
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // Уничтожаем снаряд после столкновения
       // Destroy(gameObject);
    }

    public void SetDamage(int damageValue)
    {
        damage = damageValue;
    }
}
