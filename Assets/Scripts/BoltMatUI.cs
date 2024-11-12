using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoltMatUI : MonoBehaviour
{
    public TextMeshProUGUI boltMaterialText;

    private void Update()
    {
        boltMaterialText.text = GameMaterials.GetMaterialAmount().ToString();
    }
}
