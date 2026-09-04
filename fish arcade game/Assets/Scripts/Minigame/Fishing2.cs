using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing2 : MonoBehaviour
{
    [SerializeField] Slider fishSlider;
    [SerializeField] float reelSpeed = 50;
    float fishAction;
    bool stopFishing = true;

    private void Awake()
    {
        Catch.StartFishing += StartFishing;
    }


    void Update()
    {
        if (stopFishing) return;

        if (Input.GetKey(KeyCode.N))
        {
            fishAction = 1f;
        }
        else if (Input.GetKey(KeyCode.M))
        {
            fishAction = -1f;
        }
        else
        {
            fishAction = 0;
        }

        switch (fishAction)
        {
            case 1:
                fishSlider.value += reelSpeed * Time.deltaTime;
                break;

            case -1:
                fishSlider.value -= reelSpeed * Time.deltaTime;
                break;
        }
    }

    void StartFishing(bool isPlayer1)
    {
        if (isPlayer1) return;
        stopFishing = false;
    }
}
