using UnityEngine;
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
    [SerializeField] private GameState currentStateP1;
    [SerializeField] private GameState currentStateP2;

    private Fishing1 p1;
    private Fishing2 p2;

    private bool _FishingP1;
    private bool _FishingP2;

    private void Start()
    {
        Debug.Log("working");

        _FishingP1 = true;
        _FishingP2 = true;
    }
    void Update()
    {
        /// PLAYER 1

        ///BOATING & FISHING
        if (Input.GetKeyDown(KeyCode.G))
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
            }
        }

        /// PLAYER 2

        ///BOATING & FISHING
        if (Input.GetKeyDown(KeyCode.H))
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
            }




            /*switch (currentState)
            {
                case GameState.Fishing:
                    if (!p1.didStart)
                    {

                    }
                break;
                case GameState.Boating:
                break;
            }*/
        }

    }
}
