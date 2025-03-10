using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fantasy;
using ZM.ZMAsset;
using Sirenix.OdinInspector.Editor.Drawers;
using Fantasy.Async;
using Fantasy.Network;

public class NetworkMgr:Singleton<NetworkMgr>
{
    private Session mSession;
    private Scene mScene;

    public async FTask InitSettings()
    {
        await Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
        mScene = await Scene.Create(SceneRuntimeType.MainThread);
    }

    public Session Connect()
    {
        mSession = mScene.Connect("127.0.0.1:2000",NetworkProtocolType.KCP,
            OnConnectSuccess,OnConnectFail,OnDisConnected,true);
        return mSession;
    }

    public void OnConnectSuccess()
    {

    }

    public void OnConnectFail()
    {

    }

    public void OnDisConnected()
    {

    }
}
