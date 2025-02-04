using UnityEngine;

public class GetScore : MonoBehaviour
{
    public void ScoreUp()
    {
        DataManager.Instance.score += 100;
    }
}
