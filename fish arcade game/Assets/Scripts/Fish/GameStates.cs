using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    Fishing,
    Boating
};

public class GameStates : MonoBehaviour
{

    private GameState currentState;
    private Fishing1 p1;
    private Fishing2 p2;

    private void Start()
    {
        Debug.Log("working");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)){
            Debug.Log("switching state");

            if (currentState == GameState.Fishing)
            {
                currentState = GameState.Boating;


            }
        }
        else
        {
            currentState = GameState.Fishing;
        }
        switch (currentState)
        {
            case GameState.Fishing:
                if (!p1.didStart)
                {
                    p1.
                }
            break;
            case GameState.Boating:
            break;
        }
    }

}
