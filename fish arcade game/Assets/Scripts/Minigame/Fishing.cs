
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    [SerializeField] Slider fishSlider;
    [SerializeField] float reelSpeed = 50;
    float fishVector;

    public void OnFish(InputAction.CallbackContext context)
    {
        fishVector = context.ReadValue<float>();
    }

    private void Update()
    {
        fishSlider.value += fishVector * reelSpeed * Time.deltaTime;
    }
}
