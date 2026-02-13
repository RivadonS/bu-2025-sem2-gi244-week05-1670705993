using UnityEngine;

public class GameState : MonoBehaviour
{
    public int hitCount = 0;
    void OnTriggerEnter(Collider other)
    {
        hitCount++;

        if (hitCount >= 5)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
