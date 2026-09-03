using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Fish> fishListP1 = new List<Fish>();
    [SerializeField] private List<Fish> fishListP2 = new List<Fish>();
    public int scoreP1 = 0;
    public int scoreP2 = 0;
    [SerializeField] private TMP_Text scoreDisplayP1;
    [SerializeField] private TMP_Text scoreDisplayP2;
    public static UnityAction<Fish> collectFishActionP1;
    public static UnityAction<Fish> collectFishActionP2;
    [SerializeField] private Fish fih;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        collectFishActionP1 += CollectFishP1;
        collectFishActionP2 += CollectFishP2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            collectFishActionP1.Invoke(fih);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            collectFishActionP2.Invoke(fih);
        }
    }

    public void CollectFishP1(Fish fish)
    {
        fishListP1.Add(fish);
        scoreP1 += fish.points;
        scoreDisplayP1.text = "P1 score: " + scoreP1;
    }

    public void CollectFishP2(Fish fish)
    {
        fishListP2.Add(fish);
        scoreP2 += fish.points;
        scoreDisplayP2.text = "P2 score: " + scoreP2;
    }
}
