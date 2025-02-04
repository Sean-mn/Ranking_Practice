using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInputfieldResult : MonoBehaviour
{
    public InputField playerNameInput;
    [SerializeField] private string playerName = null;

    private void Start()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    public void InputName()
    {
        if (playerNameInput.text.Length > 0)
        {
            playerName = playerNameInput.text;
            DataManager.Instance.SetScore(DataManager.Instance.score, playerName);

            SceneManager.LoadScene("Ranking");
        }
    }
}