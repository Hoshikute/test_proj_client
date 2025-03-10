using System.Collections;
using ZMUIFrameWork;
using System.Collections.Generic;
using UnityEngine;
using ZM.ZMAsset;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ZMAsset.InitFrameWork();
        UIModule.Instance.Initialize();
        UIModule.Instance.PopUpWindow<LoginWindow>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
