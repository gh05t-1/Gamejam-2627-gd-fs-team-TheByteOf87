using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing1 : MonoBehaviour
{
    [SerializeField] Slider fishSlider;
    [SerializeField] float reelSpeed = 50;
    InputAction interactAction;
    InputAction fishAction;

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact1");
        fishAction = InputSystem.actions.FindAction("Fish1");
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
