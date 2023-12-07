using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : HiroMonoBehavior
{
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int maxLevel = 99;

    public int CurrentLevel => currentLevel;
    public int MaxLevel => maxLevel;

    public virtual void LevelUp() {
        currentLevel += 1;

        LimitLevel();
    }

    public virtual void LevelSet(int newLevel) {
        currentLevel = newLevel;

        LimitLevel();
    }   

    protected virtual void LimitLevel() {
        if(currentLevel > maxLevel) currentLevel = maxLevel;

        if(currentLevel < 1) currentLevel = 1;
    }
}
