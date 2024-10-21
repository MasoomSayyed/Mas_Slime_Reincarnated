using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodSpawnerUI : MonoBehaviour
{
    public TextMeshProUGUI woodSpawnedText;

    private void Update()
    {
        woodSpawnedText.text = WoodSpawner.Instance.GetWood().ToString();
    }
}
