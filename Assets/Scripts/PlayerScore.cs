using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Total Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }
}
