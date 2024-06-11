using UnityEngine;

public class CartHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Cart health: " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyCart();
        }
    }

    private void DestroyCart()
    {
        // Handle cart destruction (e.g., play animation, remove from scene)
        Debug.Log("Cart destroyed!");
        Destroy(gameObject);
    }
}
