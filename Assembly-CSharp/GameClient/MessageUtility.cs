using System;
using System.Collections;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FDD RID: 4061
	public class MessageUtility
	{
		// Token: 0x06009B42 RID: 39746 RVA: 0x001E0A44 File Offset: 0x001DEE44
		public static IEnumerator Wait<T0, T1>(ServerType serverType, MessageEvents msgEvents, T0 req, T1 res, bool isShowWaitFrame = false, float timeout = 20f) where T0 : IProtocolStream, IGetMsgID where T1 : IProtocolStream, IGetMsgID
		{
			if (msgEvents == null)
			{
				yield break;
			}
			if (req != null)
			{
				NetManager.Instance().SendCommand<T0>(serverType, req);
			}
			if (res != null)
			{
				msgEvents.AddMessage(res.GetMsgID(), true);
				yield return new WaitNetMessage(msgEvents, timeout, isShowWaitFrame);
				if (!msgEvents.IsAllMessageReceived())
				{
					yield break;
				}
				MsgDATA data = msgEvents.GetMessageData(res.GetMsgID());
				res.decode(data.bytes);
			}
			yield break;
		}

		// Token: 0x06009B43 RID: 39747 RVA: 0x001E0A84 File Offset: 0x001DEE84
		public static IEnumerator WaitWithResend<T0, T1>(ServerType serverType, MessageEvents msgEvents, T0 req, T1 res, bool isShowWaitFrame = true, float timeout = 3.5f, CanSendCallBack callback = null) where T0 : IProtocolStream, IGetMsgID where T1 : IProtocolStream, IGetMsgID
		{
			if (msgEvents == null)
			{
				yield break;
			}
			int sendRet = -1;
			if (req != null)
			{
				sendRet = NetManager.Instance().SendCommand<T0>(serverType, req);
			}
			if (res != null)
			{
				msgEvents.AddMessage(res.GetMsgID(), true);
				WaitNetMessage waitNet = new WaitNetMessage(msgEvents, -1f, isShowWaitFrame);
				Coroutine waitCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(waitNet);
				int waitCount = 0;
				int resendCount = 0;
				float tmpTimeout = (timeout >= 0f) ? timeout : 3.5f;
				while (!msgEvents.IsAllMessageReceived())
				{
					if (tmpTimeout > 0f)
					{
						tmpTimeout -= Time.unscaledDeltaTime;
						yield return Yielders.EndOfFrame;
					}
					else
					{
						tmpTimeout = ((timeout >= 0f) ? timeout : 3.5f);
						waitCount++;
						if (waitCount >= 1)
						{
							waitCount = 0;
							resendCount++;
							if (resendCount > 2 && timeout > 0f)
							{
								break;
							}
							if (req != null && sendRet == -1 && (callback == null || callback()))
							{
								sendRet = NetManager.Instance().SendCommand<T0>(serverType, req);
							}
						}
					}
				}
				if (waitNet != null)
				{
					waitNet.OnRemove();
				}
				if (waitCo != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(waitCo);
				}
				if (msgEvents.IsAllMessageReceived())
				{
					MsgDATA messageData = msgEvents.GetMessageData(res.GetMsgID());
					res.decode(messageData.bytes);
				}
			}
			yield break;
		}

		// Token: 0x040054BF RID: 21695
		private const int kWaitCount = 1;

		// Token: 0x040054C0 RID: 21696
		private const int kResendCount = 2;

		// Token: 0x040054C1 RID: 21697
		private const float kResendTimeout = 3.5f;
	}
}
