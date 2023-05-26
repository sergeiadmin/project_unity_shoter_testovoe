using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ �������
    public int damage = 10; // ���� ������
    public int maxAmmo = 10; // ������������ ���������� �������� � ������
    public float reloadTime = 1f; // ����� �����������

    private bool canShoot = true; // ����� �� ����������� ��������

    public void Shoot()
    {
        if (!canShoot)
        {
            return;
        }

        // �������� �������
        GameObject bullet = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // ��������� ����� �������
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetDamage(damage);

        // ������ �����������
        canShoot = false;
        Invoke("ResetShoot", reloadTime);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }
}
