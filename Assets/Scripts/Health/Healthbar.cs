// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI; // Add this line

// public class Healthbar : MonoBehaviour
// {
//     [SerializeField] private Health playerHealth;
//     [SerializeField] private Image totalhealthBar;
//     [SerializeField] private Image currentHealthBar; // Fixed the variable name

//     private void Start()
//     {
//         totalhealthBar.fillAmount = playerHealth.currentHealth / 10f; // Make sure to use 10f for float division.
//     }

//     private void Update()
//     {
//         currentHealthBar.fillAmount = playerHealth.currentHealth / 10f; // Make sure to use 10f for float division.
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        // Find the player GameObject and get the Health component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Health playerHealth = player.GetComponent<Health>();

        // Check if playerHealth is not null
        if (playerHealth != null)
        {
            totalhealthBar.fillAmount = playerHealth.currentHealth / 10f;
        }
        else
        {
            Debug.LogError("Player Health component not found.");
        }
    }

    private void Update()
    {
        // You can keep this code if you want the health bar to update continuously.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Health playerHealth = player.GetComponent<Health>();

        if (playerHealth != null)
        {
            currentHealthBar.fillAmount = playerHealth.currentHealth / 10f;
        }
    }
}
