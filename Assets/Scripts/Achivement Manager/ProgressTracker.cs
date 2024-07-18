using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTracker : MonoBehaviour
{
    private int puzzlesCompleted = 0;

    void Start()
    {
        puzzlesCompleted = 0;
    }

    public void CompletePuzzle()
    {
        puzzlesCompleted++;
        CheckAchievements();
    }

    void CheckAchievements()
    {
        if (puzzlesCompleted >= 1)
        {
            AchievementsManager.instance.UnlockAchievement("Getting Started!");
        }
        if (puzzlesCompleted >= 10)
        {
            AchievementsManager.instance.UnlockAchievement("You've come this far!");
        }
        if (puzzlesCompleted >= 16)
        {
            AchievementsManager.instance.UnlockAchievement("Sweet 16");
        }
        if (puzzlesCompleted >= 20)
        {
            AchievementsManager.instance.UnlockAchievement("Do you get Deja Vu?");
        }
        if (puzzlesCompleted >= 25)
        {
            AchievementsManager.instance.UnlockAchievement("Are we done yet?");
        }
        if (puzzlesCompleted >= 30)
        {
            AchievementsManager.instance.UnlockAchievement("Thank you! Bye!");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to simulate completing a puzzle
            {
                CompletePuzzle();
            }
        }

    }
}
