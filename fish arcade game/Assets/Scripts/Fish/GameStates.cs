using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{
    Fishing,
    Boating,
};

public class GameStates : MonoBehaviour
{
    [SerializeField] private static GameState[] currentState = new GameState[2];

    public void OnInteract(InputAction.CallbackContext context)
    {
        SwitchFishState(0); 
    }

    public static void SwitchFishState(int player)
    {
        Debug.Log("switching state to Fishing P1");
        currentState[player] = GameState.Fishing;
        BoatMovement.toggleMovement?.Invoke(false, player);
        Catch.StartFishing?.Invoke(player);
    }

    public static void SwitchBoatState(int player)
    {
        Debug.Log("Player " + (player + 1) + " switching state to Boating");

        currentState[player] = GameState.Boating;
        BoatMovement.toggleMovement?.Invoke(true, player);

    }
}
