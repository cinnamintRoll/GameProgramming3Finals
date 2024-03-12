using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventManager : MonoBehaviour
{
    private static EnemyEventManager instance;

    public static EnemyEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyEventManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(EnemyEventManager).Name;
                    instance = obj.AddComponent<EnemyEventManager>();
                }
            }
            return instance;
        }
    }

    public static event Action OnEnemyDeath;

    public void TriggerEnemydeath()
    {
        OnEnemyDeath?.Invoke();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
        }
    }
}

