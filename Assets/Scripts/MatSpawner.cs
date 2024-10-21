using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatSpawner : MonoBehaviour
{
    public event EventHandler OnInteractSpawner;

    public enum spawnerState
    {
        Damaged,
        Fixed,
    }

    private Renderer renderer;
    public spawnerState state;
    private void Awake()
    {
        state = spawnerState.Damaged;
    }
    private void Start()
    {
        // Get the Renderer component attached to this GameObject
        renderer = GetComponent<Renderer>();
    }
    public void Interact()
    {
        if (GameMaterials.GetMaterialAmount() >= 3 && state != spawnerState.Fixed)
        {
            GameMaterials.DeductResource(3);
            Debug.Log("Spawner Fixed");
            ChangeColorToGreen();
            state = spawnerState.Fixed;
            Debug.Log(state);
        }

        else
        {
            Debug.Log("MatSpawnerDamaged");
            Debug.Log(state);
        }

        OnInteractSpawner?.Invoke(this, EventArgs.Empty);
    }

    private void ChangeColorToGreen()
    {
        // Change the material color to green
        renderer.material.color = Color.green;
    }
}
