using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoSingleton<GameMgr>
{
    public CameraFollow cameraFollow;
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;
    public DataMgr dataMgr;


    public override void Init()
    {
        base.Init();
        //Init Data
        dataMgr = new DataMgr();
        dataMgr.Init();
        //Init Input
        InitInput();
        //Init View
        levelMgr.Init();
        uiMgr.Init();
        cameraFollow.Init(levelMgr.character.tfCharacter);
    }

    public void OnEnable()
    {
        EnableInput();
    }

    public void OnDisable()
    {
        DisableInput();
    }

    public void FixedUpdate()
    {
        float time = Time.fixedDeltaTime;
        levelMgr.TimeFixedGoLevel(time);
    }

    public void Update()
    {
        float time = Time.deltaTime;
        levelMgr.TimeGoLevel(time);
    }
}
