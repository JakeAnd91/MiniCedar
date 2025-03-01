using UnityEngine;

namespace MyGame.Flower
{
    public class Flower : MonoBehaviour
    {
        public bool isCollected = false;

        // Flash effect for the flower when collected
        public void Flash()
        {
            // Example of a flash effect (changing color for a short time)
            GetComponent<SpriteRenderer>().color = Color.yellow;
            Invoke("ResetColor", 0.5f);
        }

        private void ResetColor()
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
