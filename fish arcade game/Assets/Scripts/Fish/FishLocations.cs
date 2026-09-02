using UnityEngine;

public class FishLocations : MonoBehaviour
{
  public enum State
    {
        Fishing,
        Boating,
    }

    private State state;

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Fishing:
                break;

            case State.Boating:
                break;
        }
    }
}
