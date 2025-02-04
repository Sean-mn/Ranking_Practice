using UnityEngine;
using UnityEngine.UI;

public class GetInputfieldResult : MonoBehaviour
{
    public InputField playerNameInput;
    private string playerName = null;

    private void Start()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
        if (playerName.Length > 0 && Input.GetKeyDown(KeyCode.Return))
        {

        }
    }

    public void InputName()
    {
        playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        
    }
}
