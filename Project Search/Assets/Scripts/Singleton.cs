using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake ()
    {
        if(_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad ( gameObject );
        }
        else
        {
            Destroy(gameObject);
        }

    }
}