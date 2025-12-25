using UnityEngine;

public class Note : MonoBehaviour
{
    public float hitTime;
    public Vector3 spawnPos;
    public Vector3 targetPos;
    public float speed = 1f;

    public bool IsJudged { get; private set; }

    void Update()
    {
        float t = hitTime - TimeProvider.Now;

        transform.position =
            targetPos + (spawnPos - targetPos) * t * speed;

        if (t < -0.15f && !IsJudged)
        {
            IsJudged = true;
            Debug.Log("Miss");
            Destroy(gameObject);
        }
    }

    public float GetTimeDiff()
    {
        return Mathf.Abs(hitTime - TimeProvider.Now);
    }

    public void Judge()
    {
        IsJudged = true;
        Destroy(gameObject);
    }
}