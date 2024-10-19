using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }

    private Vector3 targetPosition;
    public Vector3 lastEnemyPosition;

    public float speed = 10f;
    public bool CanAttack;

    private Rigidbody enemyRB;




    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        targetPosition = transform.position;

    }


    void Update()
    {
        if (!CanAttack)
        {


            if (Vector3.Distance(transform.position, targetPosition) < 1f)
            {
                targetPosition = new Vector3(GetRoamingPosition().x, 2.5f, GetRoamingPosition().z);
            }
            transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
        ChasePlayer();
        lastEnemyPosition = transform.position;
    }

    private void ChasePlayer()
    {
        Vector3 playerYFixed = new Vector3(Player.Instance.transform.position.x, 2.5f, Player.Instance.transform.position.z);

        CanAttack = Player.Instance.isEnemyArea;
        if (CanAttack)
        {

            transform.position = Vector3.MoveTowards(this.transform.position, playerYFixed, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, playerYFixed) < 6f)
            {
                DestroyEnemy();

                SpawnManager.Instance.SpawnDropMaterial(lastEnemyPosition);
            }

        }
    }

    private Vector3 GetRoamingPosition()
    {
        // return startingPosition + GetRandomDirection() * Random.Range(10f, 20f);
        return new Vector3(Random.Range(18f, -18f), 2.5f, Random.Range(-10f, -40f));
    }

    public Vector3 GetRandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    private void DestroyEnemy()
    {
        SpawnManager.Instance.EnemyKilled();
        Destroy(this.gameObject);
    }

}