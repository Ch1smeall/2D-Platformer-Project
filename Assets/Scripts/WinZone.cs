using UnityEngine;

public class WinZone : MonoBehaviour
{
    public WinUIController winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the thing that touched this is the Player
        if (collision.CompareTag("Player"))
        {
            if (winUI != null)
            {
                winUI.ShowWinScreen();
            }
        }
    }
}
