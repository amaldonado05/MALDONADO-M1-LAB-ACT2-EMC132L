using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Enemy Prefabs")]
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;

    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        Debug.Log("Score updated: " + score);
    }

    public void RespawnEnemy(Enemy enemy, float delay)
    {
        if (enemy == null) return;

        GameObject prefabToSpawn = GetPrefabFromPoints(enemy.points);
        Vector3 respawnPosition = enemy.spawnPosition; 
        StartCoroutine(RespawnEnemyRoutine(prefabToSpawn, delay, respawnPosition));
    }

    private IEnumerator RespawnEnemyRoutine(GameObject enemyPrefab, float delay, Vector3 position)
    {
        yield return new WaitForSeconds(delay);

        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, position, Quaternion.identity);
            Debug.Log(enemyPrefab.name + " respawned at original position!");
        }
    }

    private GameObject GetPrefabFromPoints(int points)
    {
        switch (points)
        {
            case 1: return enemy1Prefab;
            case 3: return enemy2Prefab;
            case 5: return enemy3Prefab;
            case 10: return enemy4Prefab;
            default: return enemy1Prefab;
        }
    }
}
