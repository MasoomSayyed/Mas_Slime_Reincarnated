using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowResourceText : MonoBehaviour
{
    public static WindowResourceText Instance;
    public TextMeshProUGUI woodText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWoodText(int totalWood)
    {
        woodText.text = totalWood.ToString();
    }
}
