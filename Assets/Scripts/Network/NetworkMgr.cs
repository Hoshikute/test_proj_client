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
using Fantasy.Network.Interface;

public class NetworkMgr : Singleton<NetworkMgr>
{
	private Session mSession;
	private Scene mScene;
	private int mHertbeatInterval = 5000;

	public async FTask InitSettings()
	{
		await Fantasy.Platform.Unity.Entry.Initialize(GetType().Assembly);
		mScene = await Scene.Create(SceneRuntimeType.MainThread);
	}

	public Session Connect(string ipPoint, NetworkProtocolType netType, Action success = null, Action fail = null, Action disConnected = null)
	{
		mSession = mScene.Connect(ipPoint, netType, () =>
		{
			OnConnectSuccess();
			success?.Invoke();
		}, () => { OnConnectFail(); fail?.Invoke(); }, () => { OnDisConnected(); disConnected?.Invoke(); }, false);
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
		DisConnected();
	}

	public async FTask<T> SendCallMsg<T>(IRequest req,long routeId = 0)
	{
		T response = (T)await mSession.Call(req, routeId);
		return response;
	}

	public void DisConnected()
	{
		mSession.GetComponent<SessionHeartbeatComponent>().Stop();
		mSession.RemoveComponent<SessionHeartbeatComponent>();
		mSession.Dispose();
	}

}
