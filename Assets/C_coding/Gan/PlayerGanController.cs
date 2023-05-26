using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGanController : MonoBehaviour
{
    public GameObject weaponPrefab1; // Префаб оружия 1
    public GameObject weaponPrefab2; // Префаб оружия 2
    public Transform weaponSpawnPoint; // Точка, откуда будут появляться снаряды
    public Text ammoText; // Текстовое поле для отображения информации о снарядах и перезарядке
    public AudioClip shootSound; // Звук выстрела

    private GameObject currentWeapon; // Текущее активное оружие
    private Weapon currentWeaponScript; // Скрипт текущего оружия
    private int currentAmmo; // Количество снарядов у текущего оружия
    private bool isReloading; // Флаг перезарядки

    private void Start()
    {
        // Инициализация начального оружия
        SwitchWeapon(1);
    }

    private void Update()
    {
        // Стрельба при нажатии ЛКМ
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Смена оружия при нажатии 1 или 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }

        // Перезарядка при нажатии R
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (currentAmmo <= 0 || isReloading)
        {
            return;
        }

        // Создание снаряда
        GameObject bullet = Instantiate(currentWeaponScript.projectilePrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);

        // Нанесение урона снаряду
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(currentWeaponScript.damage);

        // Уменьшение количества снарядов
        currentAmmo--;

        // Обновление информации о снарядах
        UpdateAmmoText();

        // Проигрывание звука выстрела
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    private void SwitchWeapon(int weaponIndex)
    {
        // Удаление предыдущего оружия
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // Создание и активация нового оружия
        if (weaponIndex == 1)
        {
            currentWeapon = Instantiate(weaponPrefab1, weaponSpawnPoint);
        }
        else if (weaponIndex == 2)
        {
            currentWeapon = Instantiate(weaponPrefab2, weaponSpawnPoint);
        }

        // Получение скрипта текущего оружия
        currentWeaponScript = currentWeapon.GetComponent<Weapon>();

        // Установка начального количества снаряд
        currentAmmo = currentWeaponScript.maxAmmo;

        // Обновление информации о снарядах
        UpdateAmmoText();
    }

    private void Reload()
    {
        if (isReloading || currentAmmo == currentWeaponScript.maxAmmo)
        {
            return;
        }

        // Запуск перезарядки
        isReloading = true;

        // Интервал перезарядки
        float reloadTime = currentWeaponScript.reloadTime;

        // Запуск сопрограммы для отсчета времени перезарядки
        StartCoroutine(ReloadCoroutine(reloadTime));
    }

    private System.Collections.IEnumerator ReloadCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);

        // Завершение перезарядки
        currentAmmo = currentWeaponScript.maxAmmo;
        isReloading = false;

        // Обновление информации о снарядах
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        // Обновление текста с информацией о снарядах и перезарядке
        ammoText.text = "Боекомплект: " + currentAmmo + " / " + currentWeaponScript.maxAmmo;

        if (isReloading)
        {
            ammoText.text += " (Reloading)";
        }
    }
}
