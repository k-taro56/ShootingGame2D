using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float changeDirectionTime = 2.0f;

    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        ChasePlayer();
    }

    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
