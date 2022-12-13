using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private AudioClip coinSound;
    private int count = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log($"Coin collected: {count}");
            count++;

            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
