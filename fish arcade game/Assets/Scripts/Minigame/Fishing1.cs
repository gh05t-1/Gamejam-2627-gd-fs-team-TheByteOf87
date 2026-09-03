using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing1 : MonoBehaviour
{
    [SerializeField] Slider fishSlider;
    [SerializeField] float reelSpeed = 50;
    InputAction interactAction;
    InputAction fishAction;
    bool stopFishing = true;

    private void Awake()
    {
        Catch.StartFishing += StartFishing;
        Catch.StopFishing += StopFishing;
    }

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact1");
        fishAction = InputSystem.actions.FindAction("Fish1");
    }

    void Update()
    {
        if (stopFishing) return;

        var fishValue = fishAction.ReadValue<float>();

        switch (fishValue)
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
        if (!isPlayer1) return;
        stopFishing = false;
    }

    void StopFishing(bool isPlayer1)
    {
        if (!isPlayer1) return;
        stopFishing = true;
    }
}
