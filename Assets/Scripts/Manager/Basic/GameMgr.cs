using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;

    public void FixedUpdate()
    {
        float time = Time.fixedDeltaTime;
        levelMgr.TimeFixedGoLevel(time);
    }
}
