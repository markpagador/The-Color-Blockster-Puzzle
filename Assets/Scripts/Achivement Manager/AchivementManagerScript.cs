using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;

    public List<Achievement> achievementsList;
    [System.Serializable]
    public class Achievement
    {
        public string title;
        public string description;
        public bool isUnlocked;
        public int points;

        public Achievement(string title, string description, int points)
        {
            this.title = title;
            this.description = description;
            this.isUnlocked = false;
            this.points = points;
        }

        public void Unlock()
        {
            isUnlocked = true;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeAchievements();
    }

    void InitializeAchievements()
    {
        achievementsList = new List<Achievement>
        {
            new Achievement("Getting Started", "Complete Level 1", 1),
            new Achievement("You've come this far?", "Complete Level 10", 10),
            new Achievement("Sweet 16", "Complete Level 16", 16),
            new Achievement("Do you get Deja Vu?", "Complete Level 20", 20),
            new Achievement("Are we done yet?", "Complete Level 25", 25),
            new Achievement("Thank you! Bye! Pagador Signing Off", "Complete Level 30", 30)
        };
    }

    public void UnlockAchievement(string title)
    {
        Achievement achievement = achievementsList.Find(a => a.title == title);
        if (achievement != null && !achievement.isUnlocked)
        {
            achievement.Unlock();
            Debug.Log($"Achievement Unlocked: {achievement.title}");
            // Optionally, add UI notification logic here
        }
    }

    public bool IsAchievementUnlocked(string title)
    {
        Achievement achievement = achievementsList.Find(a => a.title == title);
        return achievement != null && achievement.isUnlocked;
    }

}

