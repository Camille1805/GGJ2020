using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levels;
    private int currentLevel = 1;
    public int loadedLevel = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loadedLevel < currentLevel)
        {
            LoadLevel();
            loadedLevel++;
        }

    }

    private void LoadLevel()
    {
        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }
        levels[currentLevel - 1].SetActive(true);
    }

    public int NextLevel()
    {
        return currentLevel;
    }
}
