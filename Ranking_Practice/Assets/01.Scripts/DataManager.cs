using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public int score;

    public const int RankLength = 5;

    public string[] bestNames = new string[RankLength];
    public int[] bestScores = new int[RankLength];

    private void Start()
    {
        LoadScore();
    }

    public void SetScore(int currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);

        for (int i = 0; i < RankLength; i++)
        {
            if (currentScore > bestScores[i])
            {
                for (int j = RankLength - 1; j > i; j--)
                {
                    bestScores[j] = bestScores[j - 1];
                    bestNames[j] = bestNames[j - 1];
                }

                bestScores[i] = currentScore;
                bestNames[i] = currentName;
                break;
            }
        }

        SaveScore();
    }

    private void LoadScore()
    {
        for (int i = 0; i < 5; i++)
        {
            bestScores[i] = PlayerPrefs.GetInt($"BestScore{i}", 0);
            bestNames[i] = PlayerPrefs.GetString($"BestName{i}", "?");
        }
    }

    private void SaveScore()
    {
        for (int i = 0; i < RankLength; i++)
        {
            PlayerPrefs.SetInt($"BestScore{i}", bestScores[i]);
            PlayerPrefs.SetString($"BestName{i}", bestNames[i]);
        }
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
            LoadScore();
        }
    }
}