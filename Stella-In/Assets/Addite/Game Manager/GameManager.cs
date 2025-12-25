using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        TimeProvider.Tick(Time.deltaTime);
    }
}
