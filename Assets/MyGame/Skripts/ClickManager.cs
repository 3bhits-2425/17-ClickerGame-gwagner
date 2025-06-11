using UnityEngine;
using TMPro;

public class ClickerGameManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;
    private const string ScoreKey = "score"; // key name for PlayerPrefs

    void Start()
    {
        UpdateScoreText();
    }

    public void OnClickButton()
    {
        score++;
        UpdateScoreText();
    }

    public void OnSaveButton()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save(); // optional, aber empfohlen
        Debug.Log("Score saved: " + score);
    }

    public void OnLoadButton()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            score = PlayerPrefs.GetInt(ScoreKey);
            UpdateScoreText();
            Debug.Log("Score loaded: " + score);
        }
        else
        {
            Debug.Log("No saved score found.");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
