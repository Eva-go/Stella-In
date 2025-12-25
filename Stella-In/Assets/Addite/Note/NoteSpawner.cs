using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Vector3 spawnPos;
    public Vector3 targetPos;

    public float spawnInterval = 1f;
    public float leadTime = 2f;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = TimeProvider.Now + spawnInterval;
    }

    void Update()
    {
        if (TimeProvider.Now >= nextSpawnTime)
        {
            SpawnNote();
            nextSpawnTime += spawnInterval;
        }
    }

    void SpawnNote()
    {
        float hitTime = TimeProvider.Now + leadTime;

        GameObject obj = Instantiate(notePrefab);
        Note note = obj.GetComponent<Note>();

        note.hitTime = hitTime;
        note.spawnPos = spawnPos;
        note.targetPos = targetPos;
    }
}