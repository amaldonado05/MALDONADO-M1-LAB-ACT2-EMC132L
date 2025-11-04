using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 3f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && GameManager.instance != null)
            {
                GameManager.instance.AddScore(enemy.points);
                GameManager.instance.RespawnEnemy(enemy, 0.5f);
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
