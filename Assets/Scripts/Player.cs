using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movespeed = 30.0f;

    public bool isEnemyArea;
    private int materialsCarryingAmount;
    private Vector3 lastMoveDir;

    private int totalWood;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalWood = 0;
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {


        bool canMove = Physics.SphereCast(transform.position, 2f, lastMoveDir, out RaycastHit hit, 1f);
        if (canMove)
        {
            if (hit.transform.TryGetComponent(out MatSpawner matSpawner))
            {
                totalWood += WoodSpawner.Instance.GetWood();
                WindowResourceText.Instance.UpdateWoodText(totalWood);
                matSpawner.Interact();
            }
            if (hit.transform.TryGetComponent(out Material material))
            {
                materialsCarryingAmount++;
                material.Interact();

                GameMaterials.AddResource(materialsCarryingAmount);
                Debug.Log("Total mats :" + GameMaterials.GetMaterialAmount());
                materialsCarryingAmount = 0;
            }

        }
    }

    private void Update()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.y, 0, inputVector.x);

        if (moveDir != Vector3.zero)
        {
            lastMoveDir = moveDir;
        }

        bool canMove = Physics.SphereCast(transform.position, 2f, lastMoveDir, out RaycastHit hit, 1f);

        if (!canMove)
        {
            transform.position += moveDir * Time.deltaTime * movespeed;
        }


        if (transform.position.z < 0)
        {
            isEnemyArea = true;
        }
        else
        {
            isEnemyArea = false;
        }

    }

    public bool GetCanAttack()
    {
        return isEnemyArea;
    }

    public int GetTotalWood()
    {

        return totalWood;
    }
}
