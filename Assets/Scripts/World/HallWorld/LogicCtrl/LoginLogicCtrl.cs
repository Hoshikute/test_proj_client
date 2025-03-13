/*--------------------------------------------------------------------------------------
* Title: 业务逻辑脚本自动生成工具
* Date:2025/3/11 23:29:32
* Description:业务逻辑层,主要负责游戏的业务逻辑处理
* Modify:
* 注意:以下文件为自动生成，强制再次生成将会覆盖
----------------------------------------------------------------------------------------*/
using UnityEngine;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using System;
using UnityEditor;

namespace ZMGC.Hall
{
	public class LoginLogicCtrl : ILogicBehaviour
	{
		LoginMsgMgr msgLayer;
		public void OnCreate()
		{
			msgLayer = HallWorld.GetExitsMsgMgr<LoginMsgMgr>();
		}

		public void OnDestroy()
		{

		}

		public void GetToken(string account, string passward)
		{

		}

		public void RegistAccount(string account, string passward, Action<string> callback)
		{
			NetworkMgr.Instance.Connect("127.0.0.1:20000", NetworkProtocolType.KCP, async () =>
			{
				RegistAccountResponse response = await msgLayer.SendRegistAccount(account, passward);
				if (response.ErrorCode != 0)
				{
					ToastManager.ShowToast($"注册失败{response.ErrorCode}");
					callback?.Invoke("regist_fail");
				}
				{
					ToastManager.ShowToast("注册成功");
					NetworkMgr.Instance.DisConnected();
					callback?.Invoke("regist_succ");
				}
			},
			() =>
			{
				ToastManager.ShowToast("网络连接失败");
				callback?.Invoke("network_fail");
			});
		}


	}
}
