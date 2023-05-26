using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // �������� �������
    public int damage = 10; // ���� �������

    

    private void Start()
    {
        // ������ ��������� �������� �������� �������
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // �������� ��������� Health � �������, � ������� ���������� ������
        Health health = other.GetComponent<Health>();

        // ���� � ������� ���� ��������� Health, ������� ��� ����
        if (health != null)
        {
            health.TakeDamage(damage);
        }

        // ���������� ������ ����� ������������
       // Destroy(gameObject);
    }

    public void SetDamage(int damageValue)
    {
        damage = damageValue;
    }
}
