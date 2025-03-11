using System.Collections;
using Fantasy.Network;
using ZMUIFrameWork;
using System.Collections.Generic;
using UnityEngine;
using ZM.ZMAsset;
using System.Threading.Tasks;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        ZMAsset.InitFrameWork();
        await NetworkMgr.Instance.InitSettings();
        NetworkMgr.Instance.Connect("127.0.0.1:20000",NetworkProtocolType.KCP,()=>{
            WorldManager.CreateWorld<HallWorld>();
        });
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        WorldManager.Update();
    }
}
