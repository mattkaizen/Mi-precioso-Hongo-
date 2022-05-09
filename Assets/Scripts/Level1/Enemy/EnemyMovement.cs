using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Puntos a patrullar, A = Izquierda")]
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    [SerializeField] float minDistanceToPoint;

    [Space]
    [Header("Velocidad de Movimiento")]
    [SerializeField] float enemySpeed;

    [Space]
    [Header("Para que lado arranca")]
    [SerializeField] bool goToLeft;

    private Rigidbody2D enemyRb;

    private bool isReachedPosA;
    private bool isReachedPosB;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        InicialDirection();
    }

    private void Update()
    {
        TrackPosition();
    }

    private void FixedUpdate()
    {
        Patrol();
    }
    void Patrol()
    {
        if(isReachedPosA)
        {
            MoveToPosition(Vector2.right);
        }
        else if (isReachedPosB)
        {
            MoveToPosition(Vector2.left);
        }
    }


    void MoveToPosition(Vector2 targetPos)
    {
        enemyRb.MovePosition(enemyRb.position + (targetPos * enemySpeed * Time.deltaTime));
    }

    void TrackPosition()
    {
        if(Vector2.Distance(enemyRb.position, pointA) < minDistanceToPoint)
        {
            isReachedPosA = true;
            isReachedPosB = false;
        }

        else if(Vector2.Distance(enemyRb.position, pointB) < minDistanceToPoint )
        {
            isReachedPosB = true;
            isReachedPosA = false;
        }
    }

    void InicialDirection()
    {
        if(goToLeft)
        {
            isReachedPosB = true;
            isReachedPosA = false;
        }
        else
        {
            isReachedPosA = true;
            isReachedPosB = false;
        }
    }
}