using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Catch : MonoBehaviour
{
    public static UnityAction<bool> StartFishing;
    [SerializeField] Slider fishingSlider;
    [SerializeField] Slider targetSlider;
    [SerializeField] RawImage targetImage;
    [SerializeField] Texture2D[] targetImages = new Texture2D[5];
    [SerializeField] Vector2 targetSpeeds = new Vector2(20f, 50f); // The minimmum and maximum speed of the target
    [SerializeField] Vector2 targetSwitchTiming = new Vector2(0.1f, 1f);
    [SerializeField] int target;
    [SerializeField] bool isPlayer1;
    [SerializeField] float fishHealth = 3f;
    [SerializeField] FishRandomizer fishRandomizer;
    float[] catchSizes = {25, 20, 16, 12, 8};
    float moveSpeed;
    bool stopFishing = true;

    private void Awake()
    {
        StartFishing += FishFish;
    }

    private void Start()
    {
        targetSlider.value = Random.Range(targetSlider.minValue + catchSizes[target] / 2, targetSlider.maxValue - catchSizes[target] / 2);
        
        targetImage.texture = targetImages[target];

        StartCoroutine(MoveRandomizer());
    }

    private void Update()
    {
        if (stopFishing) return;

        // Start catching fish if hook within target bounds
        if (fishingSlider.value < targetSlider.value + catchSizes[target] / 2 &&
            fishingSlider.value > targetSlider.value - catchSizes[target] / 2)
            fishHealth -= Time.deltaTime;

        if (fishHealth <= 0) CatchFish();

        // Goofy code to keep the target image within bounds
        if (targetSlider.value + moveSpeed * Time.deltaTime > targetSlider.maxValue - catchSizes[target] / 2)
            return;
        else if (targetSlider.value + moveSpeed * Time.deltaTime < targetSlider.minValue + catchSizes[target] / 2)
            return;

        targetSlider.value += moveSpeed * Time.deltaTime;
    }

    private void FishFish(bool player)
    {
        fishingSlider.gameObject.SetActive(true);
        targetSlider.gameObject.SetActive(true);
        stopFishing = false;
    }

    private void CatchFish()
    {
        if (isPlayer1)
            Inventory.collectFishActionP1.Invoke(fishRandomizer.GetRandomFish());
        else
            Inventory.collectFishActionP2.Invoke(fishRandomizer.GetRandomFish());

        fishingSlider.gameObject.SetActive(false);
        targetSlider.gameObject.SetActive(false);
        stopFishing = true;
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
