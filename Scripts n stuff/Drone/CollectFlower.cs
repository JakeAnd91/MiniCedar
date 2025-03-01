using UnityEngine;
using System.Collections;  // Ensure this is included
using MyGame.Flower;

public class Bee : MonoBehaviour
{
    private bool hasFlower = false;
    private Flower currentFlower = null;
    private static int flowersCollected = 0;  // Counter for flowers collected

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flower") && !hasFlower)
        {
            currentFlower = other.GetComponent<Flower>();
            if (currentFlower != null && !currentFlower.isCollected)
            {
                currentFlower.Flash();  // Flash the flower to indicate it's been collected
                StartCoroutine(CollectFlowerWithDelay());  // Start the coroutine
            }
        }

        if (other.CompareTag("Hive") && hasFlower)
        {
            DepositFlower();  // Deposit the collected flower into the hive
        }
    }

    private IEnumerator CollectFlowerWithDelay() // Correct IEnumerator method definition
    {
        yield return new WaitForSeconds(3f);  // Wait for 3 seconds before the bee collects the flower

        hasFlower = true;  // Mark that the bee is carrying a flower
        currentFlower.isCollected = true;  // Mark the flower as collected
        Destroy(currentFlower.gameObject);  // Destroy the flower object when collected

        flowersCollected++;  // Increment the flower counter
        Debug.Log("Flowers Collected: " + flowersCollected);  // Log the current count of collected flowers

        // Inform the GameManager about the flower collection
        GameManager.Instance.CollectFlower();  // Update the game manager with the new flower collection
    }

    private void DepositFlower()
    {
        hasFlower = false;
        // Here you can call GameManager's method later to check if all flowers are collected
        // GameManager.Instance.CheckLevelCompletion();  
        Debug.Log("Flower deposited. Ready for next flower collection.");

        // If all flowers have been collected, move to the next level
        if (flowersCollected >= GameManager.Instance.GetTotalFlowers())
        {
            GameManager.Instance.NextLevel();
        }
    }
}
