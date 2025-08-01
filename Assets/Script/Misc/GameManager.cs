using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;
    [SerializeField] GameObject scoreText;

    int enemiesLeft = 0;
    public int score = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";
    const string SCORE_STRING = "Score: ";

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            youWinText.SetActive(true);
        }
    }
    public void AdjustScore(int score)
    {
        this.score += score;
        scoreText.GetComponent<TMP_Text>().text = SCORE_STRING + this.score.ToString();}

    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
