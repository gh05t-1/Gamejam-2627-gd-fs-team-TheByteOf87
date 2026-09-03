using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{
    [SerializeField] Slider fishingSlider;
    [SerializeField] Slider targetSlider;
    [SerializeField] RawImage targetImage;
    [SerializeField] Texture2D[] targetImages = new Texture2D[5];
    [SerializeField] Vector2 targetSpeeds = new Vector2(20f, 50f); // The minimmum and maximum speed of the target
    [SerializeField] Vector2 targetSwitchTiming = new Vector2(0.1f, 1f);
    [SerializeField] int target;
    [SerializeField] float fishHealth = 3f;
    float[] catchSizes = {25, 20, 16, 12, 8};
    float moveSpeed;


    private void Start()
    {
        targetSlider.value = Random.Range(targetSlider.minValue, targetSlider.maxValue);
        
        targetImage.texture = targetImages[target];

        StartCoroutine(MoveRandomizer());
    }

    private void Update()
    {
        if (fishingSlider.value < targetSlider.value + catchSizes[target] / 2 &&
            fishingSlider.value > targetSlider.value - catchSizes[target] / 2)
            fishHealth -= Time.deltaTime;

        if (fishHealth <= 0)
        {
            // Catch the fish
        }

        if (targetSlider.value + moveSpeed * Time.deltaTime > targetSlider.maxValue - catchSizes[target] / 2)
            return;
        else if (targetSlider.value + moveSpeed * Time.deltaTime < targetSlider.minValue + catchSizes[target] / 2)
            return;

        targetSlider.value += moveSpeed * Time.deltaTime;
    }

    IEnumerator MoveRandomizer()
    {
        while (true)
        {
            moveSpeed = Random.Range(targetSpeeds.x, targetSpeeds.y);

            if (Random.Range(0, 2) == 0)
                moveSpeed = -moveSpeed;

            yield return new WaitForSeconds(Random.Range(targetSwitchTiming.x, targetSwitchTiming.y));
        }
    }
}
