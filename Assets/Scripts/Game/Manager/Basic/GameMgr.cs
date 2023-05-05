using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoSingleton<GameMgr>
{
    public CameraFollow cameraFollow;
    public Camera UICamera;
    public LevelMgr levelMgr;
    public UIMgr uiMgr;
    public SoundMgr soundMgr;
    public DataMgr dataMgr;

    public bool isSkillReady = false;
    public bool isTimeStopMon = false;

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
        if (isTimeStopMon)
        {
            return;
        }
        levelMgr.TimeFixedGoLevel(time);
    }

    public void Update()
    {
        if (isSkillReady)
        {
            isTimeStopMon = true;
        }
        else
        {
            isTimeStopMon = false;
        }
    }
}
