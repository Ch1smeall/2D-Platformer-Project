using UnityEngine;

public class Coin : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.coins += 1;
                SoundManager.Instance.PlaySFX("COIN", 0.4f);
            }
            Destroy(gameObject);
        }
    }
}
