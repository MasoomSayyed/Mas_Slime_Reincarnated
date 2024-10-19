using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MatSpawner
{
    public static WoodSpawner Instance;

    private int wood;

    private void Awake()
    {
        Instance = this;
        OnInteractSpawner += WoodSpawner_OnInteractSpawner;
    }
    public int GetWood()
    {
        return wood;
    }
    private void WoodSpawner_OnInteractSpawner(object sender, System.EventArgs e)
    {
        if (state == spawnerState.Fixed)
        {
            Debug.Log("wood collected");
            wood = 0;
        }
    }

    private void spawnWood()
    {
        if (state == spawnerState.Fixed)
        {
            wood++;
            Debug.Log(wood);
        }
    }

    private void OnEnable()
    {
        InvokeRepeating("spawnWood", 0, 1);
    }


}
