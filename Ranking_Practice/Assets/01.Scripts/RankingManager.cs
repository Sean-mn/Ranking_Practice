using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public Text[] nameTxts;
    public Text[] scoreTxts;

    public Button restartBtn;

    private void Start()
    {
        for (int i = 0; i < 5;  i++)
        {
            nameTxts[i].text = DataManager.Instance.bestNames[i];
            scoreTxts[i].text = DataManager.Instance.bestScores[i].ToString();
        }

        restartBtn.onClick.AddListener(GoMain);
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}