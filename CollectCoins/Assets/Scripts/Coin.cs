using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource CoinAudiosource;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(100 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.numberOfCoins += 1;
            CoinAudiosource.Play();
            gameObject.SetActive(false);
        }
    }
}
