using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform[] spawnPoints; // ������ ����� ������ ������
    public float minSpawnInterval = 1f; // ����������� �������� ������ ������
    public float maxSpawnInterval = 3f; // ������������ �������� ������ ������
    public float moveSpeed = 5f; // �������� �������� ������
    public int damageAmount = 1; // ���������� ���������� ������ ��� ������������ � ������

    private GameObject player; // ������ �� ������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // ����� ������ �� ���� "Player"
        StartSpawningEnemies(); // ������ ������ ������
    }

    private void StartSpawningEnemies()
    {
        // ������ ����������� ��� ������ ������
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ��������� ����� ����� ������
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // �������� ����� �� ��������� ����� ������
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // ����������� �������� ����� � ������
            Vector3 direction = (player.transform.position - enemy.transform.position).normalized;

            // ������� ����������� �������� �����
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.SetMovementDirection(direction, moveSpeed, damageAmount);

            // ��������� �������� ����� ������� ������
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // �������� �� ���������� ������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
