using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    public int score;

    public string[] bestNames = new string[5];
    public int[] bestScores = new int[5];

    public void SetScore(int curScore, string curName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", curName);
        PlayerPrefs.SetInt("CurrentPlayerScore", curScore);

        for (int i = 0; i < 5; i++)
        {
            bestScores[i] = PlayerPrefs.GetInt(i + "BestScore", 0);
            bestNames[i] = PlayerPrefs.GetString(i + "BestName", " ");
        }

        for (int i = 0; i < 5; i++)
        {
            if (curScore > bestScores[i])
            {
                for (int j = 4; j > i; j--)
                {
                    bestScores[j] = bestScores[j - 1];
                    bestNames[j] = bestNames[j - 1];
                }

                bestScores[i] = curScore;
                bestNames[i] = curName;
                break;
            }
        }

        for (int i = 0; i < 5; i++)
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

            for (int i = 0; i < 5; i++)
            {
                bestScores[i] = PlayerPrefs.GetInt(i + "BestScore", 0);
                bestNames[i] = PlayerPrefs.GetString(i + "BestName", " ");
            }
        }
    }
}