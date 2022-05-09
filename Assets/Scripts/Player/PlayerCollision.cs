using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] int playerHealth;

    private CapsuleCollider2D playerBoxColl;


    private void Awake()
    {
        playerBoxColl = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Perdio Vida");
            SubstractHealth();
        }
    }

    void SubstractHealth()
    {
        --playerHealth;
    }
}