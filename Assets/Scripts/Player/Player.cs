using UnityEngine;

public class Player : MonoBehaviour
{
    private Timer timer;

    void Start()
    {
        // Find the Timer in the scene
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            // Increment gem count
            if (timer != null)
            {
                timer.CollectGem();
            }

            // Destroy the gem object
            Destroy(other.gameObject);
        }
    }
}
