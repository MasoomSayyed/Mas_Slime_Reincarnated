using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMaterials
{
    public static event EventHandler OnMaterialAmountChanged;

    private static int materialAmount;

    public static void AddResource(int matAmount)
    {
        materialAmount += matAmount;
        OnMaterialAmountChanged?.Invoke(null, EventArgs.Empty);
    }

    public static void DeductResource(int matAmount)
    {
        materialAmount -= matAmount;
        OnMaterialAmountChanged?.Invoke(null, EventArgs.Empty);
    }

    public static int GetMaterialAmount()
    {

        return materialAmount;
    }
}
