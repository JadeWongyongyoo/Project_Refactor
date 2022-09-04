using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private int coinCount;
    public TMPro.TMP_Text coinText;
    Move_character character;
    public AudioClip coinSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            coinCount++;
            coinText.text = coinCount.ToString();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Hp"))
        {
            character.TargetHeal();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("energy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            Destroy(other.gameObject);
        }
    }
    private void Start()
    {
        character = GetComponent<Move_character>(); 
    }
    public void IncreaseCoin(int numberOfCoin)
    {
        coinCount = coinCount + numberOfCoin;
        coinText.text = coinCount.ToString();
    }
}
