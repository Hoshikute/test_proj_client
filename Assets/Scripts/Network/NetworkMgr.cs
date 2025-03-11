using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fantasy;
using ZM.ZMAsset;
using Sirenix.OdinInspector.Editor.Drawers;
using Fantasy.Async;
using Fantasy.Network;
using UnityEngine.Events;
using System;

public class NetworkMgr:Singleton<NetworkMgr>
{
    private Session mSession;
    private Scene mScene;
    private int mHertbeatInterval = 5000;

    public async FTask InitSettings()
    {
        await Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
        mScene = await Scene.Create(SceneRuntimeType.MainThread);
    }

    public Session Connect(string ipPoint, NetworkProtocolType netType, Action success = null, Action fail=null, Action disConnected=null)
    {
        mSession = mScene.Connect("127.0.0.1:20000",NetworkProtocolType.KCP,()=>{OnConnectSuccess();
         success?.Invoke();},()=>{OnConnectFail();fail?.Invoke();},()=>{OnDisConnected();disConnected?.Invoke();},false);
        return mSession;
    }

    public void OnConnectSuccess()
    {
        Debug.Log("连接成功");
        mSession.AddComponent<SessionHeartbeatComponent>().Start(mHertbeatInterval);
    }

    public void OnConnectFail()
    {
        Debug.Log("连接失败");
    }

    public void OnDisConnected()
    {
        Debug.Log("断开连接");
        mSession.GetComponent<SessionHeartbeatComponent>().Stop();
        mSession.RemoveComponent<SessionHeartbeatComponent>();
        mSession.Dispose();
    }
}
