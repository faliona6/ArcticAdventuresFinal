using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int gems = 0;
    public GemCount gemCount;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
     //   gemCount.gems = GlobalControl.Instance.gems;
    }

    public void saveGems()
    {
   //     GlobalControl.Instance.gems = gemCount.gems;
    }
}