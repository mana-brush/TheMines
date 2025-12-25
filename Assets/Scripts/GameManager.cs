using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera; 
    [SerializeField] private Camera bossCamera;

    private void Start()
    {
        GameState.ActiveCamera = mainCamera;
        bossCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
    
    public GameState GameState { get; set; } = new ();
    public void SwitchCamera()
    {
        bossCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        GameState.ActiveCamera = bossCamera;
    }
}

public class GameState
{
    public Camera ActiveCamera { get; set; }
    
    public bool OpenedChest { get; set; }

    public bool TriggeredGate { get; set; }

}
