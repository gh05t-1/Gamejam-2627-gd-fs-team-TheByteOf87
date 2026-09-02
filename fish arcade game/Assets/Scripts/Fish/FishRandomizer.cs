using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FishRandomizer : MonoBehaviour
{
    //private Fish fish;
    public List<Fish> fishList = new List<Fish>();
    private Fish chosenFish;


    [SerializeField] private Image FishIcon;
    [SerializeField] private TextMeshProUGUI fishStats;

    private void Start()
    {
        FishIcon.enabled = false;
    }
    private void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.E))
        {
            chosenFish = fishList[Random.Range(0, fishList.Count)];
            FishIcon.enabled = true;
            FishIcon.sprite = chosenFish.icon;
            fishStats.text = "Fish; " + chosenFish.fishName + " Length: " + chosenFish.fishLenght + " Points " + chosenFish.points;
        }
        
        
    }

}
