using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 1;
    [HideInInspector] public Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = transform.position;
    }
}
