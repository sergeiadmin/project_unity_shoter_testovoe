using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1; // ������������ ��������

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage; // �������� ���������� ���� �� �������� ��������

        
            Die(); // ���� �������� ����� ������ ��� ����� 0, �������� ����� ������
        
    }

    public void Die()
    {
        // ����� ����� �������� �������������� ������, ������� ����� ����������� ��� ������ �������
       // gameObject.SetActive(false);
    }
}
