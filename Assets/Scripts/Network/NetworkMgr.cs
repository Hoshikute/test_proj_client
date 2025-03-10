using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fantasy;
using ZM.ZMAsset;
using Sirenix.OdinInspector.Editor.Drawers;
using Fantasy.Async;

public class NetworkMgr:Singleton<NetworkMgr>
{
    public static NetworkMgr instance;
    public static NetworkMgr Instance{
        get{
            if(instance == null){
                instance = new NetworkMgr();
            }
            return instance;
        }
    }

    private Scene mScene;

    public async FTask<Scene> Init()
    {
        return mScene = await Fantasy.Entry.Scene.LoadScene("Main");
    }
}
