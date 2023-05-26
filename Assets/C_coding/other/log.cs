using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public Text deathCountText;

    public Text HPText;

    public GameObject show;

    private int deathCount = 0;

    public int playerHealth = 3;
    private bool isPlayerDead = false;

    public string projectileTag = "Projectile";
    public string enemyTag;
    public string playerTag;


    public void poctor()
    {
        // �������� ������ ������� �������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ����� � ��������� ��������
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void exit()
    {
        Application.Quit();
    }

    private void Start()
    {
        HPText.text = "���� �����!";
        playerHealth = 3;
        show.SetActive(false);
    }
    private void Update()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject projectile in projectiles)
        {
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(projectile.transform.position, enemy.transform.position);

                if (distanceToEnemy < 4f)
                {
                    projectile.SetActive(false);
                        enemy.SetActive(false);
                    deathCount++;
                    deathCountText.text = "��������� �����������: " + deathCount.ToString();
                }


                
                    float distanceToPlayer = Vector3.Distance(enemy.transform.position, transform.position);

                    if (distanceToPlayer < 3f)
                    {
                        enemy.SetActive(false);
                        playerHealth = playerHealth - 1;
                        
                        if (playerHealth == 0)
                        {
                            gameObject.SetActive(false);
                            //Debug.Log("Player died");
                            HPText.text = "����� �����������!";

                        show.SetActive(true);
                    }
                       
                    }
                
            }
        }
    }
}
