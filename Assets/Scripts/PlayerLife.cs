using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private float damage; // Add a field for damage


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            ReduceHealth(); // Call a method to reduce health
            if (GetComponent<Health>().currentHealth <= 0)  
            {
                Die();
            }
            
        }
    }

    public void ReduceHealth()
    {
        Health playerHealth = GetComponent<Health>(); // Assuming Health script is on the same GameObject
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    
    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
