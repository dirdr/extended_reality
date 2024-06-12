using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IHittable
{
    [SerializeField] private string targetTag;
    public float attackRange = 2f; // Distance at which the enemy will attack
    public float moveSpeed = 2f; // Speed at which the enemy moves towards the target
    public float attackCooldown = 2f; // Time between attacks
    public int attackDamage = 10;
    public int points = 100;

    [SerializeField] private Transform target;
    private float lastAttackTime;

    private void Start()
    {
        lastAttackTime = -attackCooldown;
        FindTarget(); // Find the target when the enemy spawns
    }

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            if (target == null)
                return; // Exit if the target is still not found
        }
        MoveTowardsTarget();

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            AttackTarget();
        }
    }

    private void FindTarget()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    private void MoveTowardsTarget()
    {
        // Calculate the direction to the target
        Vector3 direction = (target.position - transform.position).normalized;
        // Move the enemy towards the target
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Optionally, make the enemy face the target
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    private void AttackTarget()
    {
        // Attack logic (e.g., reduce health of the cart)
        CartHealth cartHealth = target.GetComponent<CartHealth>();
        if (cartHealth != null)
        {
            cartHealth.TakeDamage(attackDamage);
        }

        lastAttackTime = Time.time;
    }

    public void GetHit()
    {
        // Logic when the enemy gets hit
        Destroy(gameObject);
        AddPoints(points);
    }

    private void AddPoints(int points)
    {
        if (PlayerScore.Instance != null)
        {
            PlayerScore.Instance.AddPoints(points);
        }
        else
        {
            Debug.LogError("PlayerScore instance not found!");
        }
    }
}
