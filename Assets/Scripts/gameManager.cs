using UnityEngine;

public class gameManager : MonoBehaviour
{
    public int score;
    public void increaseScore()
    {
        score++;
    }
    public void gameOver()
    {
        Debug.Log("Game Over");
    }
}
