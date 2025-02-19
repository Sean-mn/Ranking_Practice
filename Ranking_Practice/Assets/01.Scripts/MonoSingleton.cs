using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance 
    {
        get
        {
            if ( _instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if ( _instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    _instance = obj.GetComponent<T>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}