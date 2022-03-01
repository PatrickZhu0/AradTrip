using System;
using Network;
using Protocol;

namespace _Settings
{
	// Token: 0x02001A1C RID: 6684
	public class CDKManager : Singleton<CDKManager>
	{
		// Token: 0x060106B6 RID: 67254 RVA: 0x0049EA57 File Offset: 0x0049CE57
		public override void Init()
		{
		}

		// Token: 0x060106B7 RID: 67255 RVA: 0x0049EA59 File Offset: 0x0049CE59
		public override void UnInit()
		{
		}

		// Token: 0x060106B8 RID: 67256 RVA: 0x0049EA5C File Offset: 0x0049CE5C
		private CDKData NetData2LocalData(SceneCdkRes data)
		{
			return new CDKData
			{
				CDKReturnCode = data.code
			};
		}

		// Token: 0x060106B9 RID: 67257 RVA: 0x0049EA7C File Offset: 0x0049CE7C
		public void SendCDKcode(string cdkCode)
		{
			SceneCdkReq sceneCdkReq = new SceneCdkReq();
			sceneCdkReq.cdk = cdkCode;
			NetManager.Instance().SendCommand<SceneCdkReq>(ServerType.GATE_SERVER, sceneCdkReq);
		}
	}
}
