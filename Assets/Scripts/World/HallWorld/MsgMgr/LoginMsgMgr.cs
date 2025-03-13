/*--------------------------------------------------------------------------------------
* Title: 网络消息层脚本自动生成工具
* Date:2025/3/11 23:29:51
* Description:网络消息层,主要负责游戏网络消息的收发
* Modify:
* 注意:以下文件为自动生成，强制再次生成将会覆盖
----------------------------------------------------------------------------------------*/
using System.Threading.Tasks;
using Fantasy;
using Fantasy.Async;

namespace ZMGC.Hall
{
	public  class LoginMsgMgr : IMsgBehaviour
	{
	
		 public  void OnCreate()
		 {
		
		 }
		
		 public  void OnDestroy()
		 {
		
		 }

		 public async FTask<RegistAccountResponse> SendRegistAccount(string account,string passward)
		 {
			RegistAccountRequest request = new RegistAccountRequest();
			request.account = account;
			request.passward = passward;
			RegistAccountResponse response = await NetworkMgr.Instance.SendCallMsg<RegistAccountResponse>(request);
			return response;
		}
	
	}
}
