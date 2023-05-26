using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public int damage = 10; // Урон оружия
    public int maxAmmo = 10; // Максимальное количество снарядов в обойме
    public float reloadTime = 1f; // Время перезарядки

    private bool canShoot = true; // Можно ли производить выстрелы

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        // Создание снаряда
        GameObject bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Установка урона снаряда
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(damage);

        // Запуск перезарядки
        canShoot = false;
        Invoke("ResetShoot", reloadTime);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
