using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject {

    public int level;

    public enum DifficultyTier{
        Easy,
        Normal,
        Hard,
        Insane
    }

    public void LevelNext(){
        level += 1;
    }

    public void LevelDecrese(){
        level = Mathf.Max(1,level - 1);
    }

    public DifficultyTier GetDifficultyTier(){
        if(level < 7){
            return DifficultyTier.Easy;
        }else if(level < 20){
            return DifficultyTier.Normal;
        }else if(level < 50){
            return DifficultyTier.Hard;
        }else{
            return DifficultyTier.Insane;
        }
    }

    public int GetPlatformCount(){
        DifficultyTier tier = GetDifficultyTier();
        switch(tier){
            case DifficultyTier.Easy:
                return 14;
            case DifficultyTier.Normal:
                return 20;
            case DifficultyTier.Hard:
                return 24;
            case DifficultyTier.Insane:
            default:
                return 28;
        }
    }

    public float GetObstacleChance(){
        DifficultyTier tier = GetDifficultyTier();
        switch(tier){
            case DifficultyTier.Easy:
                return 0.15f;
            case DifficultyTier.Normal:
                return 0.3f;
            case DifficultyTier.Hard:
                return 0.45f;
            case DifficultyTier.Insane:
            default:
                return 0.6f;
        }
    }

    public float GetRotateSpeed(float baseSpeed){
        DifficultyTier tier = GetDifficultyTier();
        float multiplier = 1f;
        switch(tier){
            case DifficultyTier.Easy:
                multiplier = 0.9f;
                break;
            case DifficultyTier.Normal:
                multiplier = 1.0f;
                break;
            case DifficultyTier.Hard:
                multiplier = 1.15f;
                break;
            case DifficultyTier.Insane:
                multiplier = 1.3f;
                break;
        }
        return baseSpeed * multiplier;
    }

    public float GetJumpForce(float baseForce){
        DifficultyTier tier = GetDifficultyTier();
        float multiplier = 1f;
        switch(tier){
            case DifficultyTier.Easy:
                multiplier = 0.9f;
                break;
            case DifficultyTier.Normal:
                multiplier = 1.0f;
                break;
            case DifficultyTier.Hard:
                multiplier = 1.1f;
                break;
            case DifficultyTier.Insane:
                multiplier = 1.2f;
                break;
        }
        return baseForce * multiplier;
    }
}
