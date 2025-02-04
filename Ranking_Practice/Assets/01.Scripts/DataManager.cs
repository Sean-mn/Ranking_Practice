using UnityEditor.TerrainTools;
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

    public void SetScore(int curScore, string curName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", curName);
        PlayerPrefs.SetInt("CurrentPlayerScore", curScore);

        for (int i = 0; i < RankLength; i++)
        {
            if (curScore > bestScores[i])
            {
                for (int j = RankLength - 1; j > i; j--)
                {
                    bestScores[j] = bestScores[j - 1];
                    bestNames[j] = bestNames[j - 1];
                }

                bestScores[i] = curScore;
                bestNames[i] = curName;
                break;
            }
        }

        SaveScore();
    }

    private void LoadScore()
    {
        for (int i = 0; i < RankLength; i++)
        {
            bestScores[i] = PlayerPrefs.GetInt(i + "BestScore", 000);
            bestNames[i] = PlayerPrefs.GetString(i + "BestName", "?");
        }
    }

    private void SaveScore()
    {
        for (int i = 0; i < RankLength; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScores[i]);
            PlayerPrefs.SetString(i + "BestName", bestNames[i]);
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