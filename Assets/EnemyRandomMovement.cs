using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float changeDirectionTime = 2.0f;

    private Vector2 moveDirection;
    private float timer;

    void Start()
    {
        MoveDirection();
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer > changeDirectionTime)
        {
            MoveDirection();
            timer = 0f;
        }
    }

    private void MoveDirection()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
