using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {

        bool isPlayer = other.gameObject.name == "Player";

        if (!isPlayer)
        {
            return;
        }
        
        if (!gameManager.GameState.OpenedChest)
        {
            Debug.Log("Player passed gate.");
            gameManager.GameState.TriggeredGate = true;
            gameManager.GameState.OpenedChest = true;
        } else if (gameManager.GameState.OpenedChest)
        {
            gameManager.SwitchCamera();
            Debug.Log("Player passed gate, after opening chest. Switch Camera, Boss time.");
        }
    }
}
