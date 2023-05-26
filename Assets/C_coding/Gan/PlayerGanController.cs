using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGanController : MonoBehaviour
{
    public GameObject weaponPrefab1; // ������ ������ 1
    public GameObject weaponPrefab2; // ������ ������ 2
    public Transform weaponSpawnPoint; // �����, ������ ����� ���������� �������
    public Text ammoText; // ��������� ���� ��� ����������� ���������� � �������� � �����������
    public AudioClip shootSound; // ���� ��������

    private GameObject currentWeapon; // ������� �������� ������
    private Weapon currentWeaponScript; // ������ �������� ������
    private int currentAmmo; // ���������� �������� � �������� ������
    private bool isReloading; // ���� �����������

    private void Start()
    {
        // ������������� ���������� ������
        SwitchWeapon(1);
    }

    private void Update()
    {
        // �������� ��� ������� ���
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // ����� ������ ��� ������� 1 ��� 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }

        // ����������� ��� ������� R
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

        // �������� �������
        GameObject bullet = Instantiate(currentWeaponScript.projectilePrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);

        // ��������� ����� �������
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(currentWeaponScript.damage);

        // ���������� ���������� ��������
        currentAmmo--;

        // ���������� ���������� � ��������
        UpdateAmmoText();

        // ������������ ����� ��������
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    private void SwitchWeapon(int weaponIndex)
    {
        // �������� ����������� ������
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // �������� � ��������� ������ ������
        if (weaponIndex == 1)
        {
            currentWeapon = Instantiate(weaponPrefab1, weaponSpawnPoint);
        }
        else if (weaponIndex == 2)
        {
            currentWeapon = Instantiate(weaponPrefab2, weaponSpawnPoint);
        }

        // ��������� ������� �������� ������
        currentWeaponScript = currentWeapon.GetComponent<Weapon>();

        // ��������� ���������� ���������� ������
        currentAmmo = currentWeaponScript.maxAmmo;

        // ���������� ���������� � ��������
        UpdateAmmoText();
    }

    private void Reload()
    {
        if (isReloading || currentAmmo == currentWeaponScript.maxAmmo)
        {
            return;
        }

        // ������ �����������
        isReloading = true;

        // �������� �����������
        float reloadTime = currentWeaponScript.reloadTime;

        // ������ ����������� ��� ������� ������� �����������
        StartCoroutine(ReloadCoroutine(reloadTime));
    }

    private System.Collections.IEnumerator ReloadCoroutine(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);

        // ���������� �����������
        currentAmmo = currentWeaponScript.maxAmmo;
        isReloading = false;

        // ���������� ���������� � ��������
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        // ���������� ������ � ����������� � �������� � �����������
        ammoText.text = "�����������: " + currentAmmo + " / " + currentWeaponScript.maxAmmo;

        if (isReloading)
        {
            ammoText.text += " (Reloading)";
        }
    }
}
