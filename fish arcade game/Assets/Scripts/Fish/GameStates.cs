using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    FishingP1,
    BoatingP1,
    FishingP2,
    BoatingP2
};

public class GameStates : MonoBehaviour
{
    [SerializeField] private static GameState currentStateP1;
    [SerializeField] private static GameState currentStateP2;

    private Fishing1 p1;
    private Fishing2 p2;

    public static bool _FishingP1;
    public static bool _FishingP2;

    private void Start()
    {

        Debug.Log("working");

        _FishingP1 = false;
        _FishingP2 = false;
    }
    void Update()
    {
        /// PLAYER 1

        ///BOATING & FISHING
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeStateP1();
        }

        /// PLAYER 2

        ///BOATING & FISHING
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeStateP2();
        }
    }

    public static void ChangeStateP1()
    {
        if (_FishingP1)
        {
            Debug.Log("switching state to Boating P1");

            currentStateP1 = GameState.BoatingP1;

            _FishingP1 = false;

            BoatP1Movement.toggleMovementP1?.Invoke(true);

        }
        else
        {
            Debug.Log("switching state to Fishing P1");

            currentStateP1 = GameState.FishingP1;

            _FishingP1 = true;

            BoatP1Movement.toggleMovementP1?.Invoke(false);

            Catch.StartFishing?.Invoke(true);
        }
    }

    public static void ChangeStateP2()
    {
        if (_FishingP2)
        {
            Debug.Log("switching state to Boating P2");

            currentStateP2 = GameState.BoatingP2;

            _FishingP2 = false;

            BoatP2Movement.toggleMovementP2?.Invoke(true);

        }
        else
        {
            Debug.Log("switching state to Fishing P2");

            currentStateP2 = GameState.FishingP2;

            _FishingP2 = true;

            BoatP2Movement.toggleMovementP2?.Invoke(false);

            Catch.StartFishing?.Invoke(false);
        }
    }
}
