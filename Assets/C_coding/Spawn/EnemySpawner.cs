using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform[] spawnPoints; // Массив точек спавна врагов
    public float minSpawnInterval = 1f; // Минимальный интервал спавна врагов
    public float maxSpawnInterval = 3f; // Максимальный интервал спавна врагов
    public float moveSpeed = 5f; // Скорость движения врагов
    public int damageAmount = 1; // Количество отнимаемых жизней при столкновении с врагом

    private GameObject player; // Ссылка на игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Поиск игрока по тегу "Player"
        StartSpawningEnemies(); // Начало спавна врагов
    }

    private void StartSpawningEnemies()
    {
        // Запуск сопрограммы для спавна врагов
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Рандомный выбор точки спавна
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Создание врага на выбранной точке спавна
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Направление движения врага к игроку
            Vector3 direction = (player.transform.position - enemy.transform.position).normalized;

            // Задание направления движения врагу
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.SetMovementDirection(direction, moveSpeed, damageAmount);

            // Рандомный интервал между спавном врагов
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Ожидание до следующего спавна
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
