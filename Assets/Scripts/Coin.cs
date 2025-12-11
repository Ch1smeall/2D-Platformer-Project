using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{

    public AudioClip coinClip;
    public int coinsToGive = 1;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.coins += coinsToGive;
                coinText.text = player.coins.ToString();
                Destroy(gameObject);
            }
        }
    }
}
