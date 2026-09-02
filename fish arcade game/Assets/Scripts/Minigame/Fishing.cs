using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [SerializeField] Slider fishSlider;
    [SerializeField] float reelSpeed;
    InputAction interactAction;
    InputAction fishAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        fishAction = InputSystem.actions.FindAction("Fish");
    }

    void Update()
    {
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
}
