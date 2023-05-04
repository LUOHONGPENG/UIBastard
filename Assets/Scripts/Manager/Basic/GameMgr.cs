using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoSingleton<GameMgr>
{
    public CameraFollow cameraFollow;
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;

    public void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        levelMgr.Init();
        cameraFollow.Init(levelMgr.character.tfCharacter);
    }

    public void FixedUpdate()
    {
        float time = Time.fixedDeltaTime;
        levelMgr.TimeFixedGoLevel(time);
    }
}
