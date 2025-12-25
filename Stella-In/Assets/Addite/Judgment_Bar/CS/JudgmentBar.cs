using UnityEngine;

public class JudgmentBar : MonoBehaviour
{
    //판정 바 제작
    public float Bar_speed = 5f;
    public float leftLimit = -6f;
    public float rightLimit = 6f;

    private int direction = 1;

   
    void Update()
    {
        transform.Translate(Vector3.right * Bar_speed * direction * Time.deltaTime);

        if (transform.position.x >= rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            direction = 1;
        }
    }
}
