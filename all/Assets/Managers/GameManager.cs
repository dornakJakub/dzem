using UnityEngine;
using System;
using System.Collections.Generic;
using ui;
using card_logic;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Game data
    public int score;
    int customerNumber;
    public int currentMilestone = 0;
    public int[] milestones = { 100, 200, 300 };     //todo milestones
    // public List<int> foodsOnHand = new List<int> { 0, 1 };     //todo  
    // public List<int> foodsOnCounter = new List<int> { 0, 1 };     //todo  
    // public List<int> kitchenAnimals = new List<int> { 0, 1 };     //todo  
    
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        // Initialize game state
        score = 0;
        currentMilestone = 0;
    }

    // Game state methods
    public void DayStart()
    {
        score = 0;
        customerNumber = UnityEngine.Random.Range(1, currentMilestone + 2);

    }
    
    public void CustomerServiced()
    {
        customerNumber -= 1;
        if (customerNumber == 0)
        {
            DayEnd();
        }
    }
    public void DayEnd()
    {
        //notification and daco daco
    }
    
    
    // Score methods
    public void AddScore(int points)
    {
        score += points;
        ProgressBar.Instance.SetCurrent(points);

        if (score >= milestones[currentMilestone])
        {
            CardLibrary.Instance.UnlockMilestone(currentMilestone);
            currentMilestone = currentMilestone + 1;
        }
        //SetCurrent(score);
    }
    

    
}