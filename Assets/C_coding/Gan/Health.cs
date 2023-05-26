using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1; // Максимальное здоровье

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage; // Вычитаем полученный урон из текущего здоровья

        
            Die(); // Если здоровье стало меньше или равно 0, вызываем метод смерти
        
    }

    public void Die()
    {
        // Здесь можно добавить дополнительную логику, которая будет выполняться при смерти объекта
       // gameObject.SetActive(false);
    }
}
