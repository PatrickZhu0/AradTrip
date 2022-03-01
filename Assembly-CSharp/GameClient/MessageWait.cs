using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FDB RID: 4059
	public class MessageWait<T1, T2> where T1 : IProtocolStream, IGetMsgID where T2 : IProtocolStream, IGetMsgID
	{
		// Token: 0x06009B38 RID: 39736 RVA: 0x001E0888 File Offset: 0x001DEC88
		public MessageWait(ServerType serverType, T1 req, T2 res, float timeout = 20f)
		{
			this._durTime = Time.time;
			this._serverType = serverType;
			this._timeOut = timeout;
			this.mRes = res;
			this._handle = new Action<MsgDATA>(this._OnMessageReceived);
			this.mReq = new Queue<T1>();
			NetProcess.AddMsgHandler(this.mRes.GetMsgID(), this._handle);
			int num = NetManager.Instance().SendCommand<T1>(serverType, req);
			this.mReq.Enqueue(req);
		}

		// Token: 0x06009B39 RID: 39737 RVA: 0x001E0910 File Offset: 0x001DED10
		public void DeInit()
		{
			NetProcess.RemoveMsgHandler(this.mRes.GetMsgID(), this._handle);
			this._handle = null;
			this.mReq.Clear();
			this.mRes = default(T2);
			this.mReq = null;
			this.comparor = null;
		}

		// Token: 0x06009B3A RID: 39738 RVA: 0x001E0968 File Offset: 0x001DED68
		public void PushRequestQueue(T1 req)
		{
			this.mReq.Enqueue(req);
		}

		// Token: 0x06009B3B RID: 39739 RVA: 0x001E0978 File Offset: 0x001DED78
		public bool IsWaitting()
		{
			if (this.mReq.Count <= 0)
			{
				return false;
			}
			float time = Time.time;
			float num = time - this._durTime;
			if (num > this._timeOut)
			{
				T1 cmd = this.mReq.Peek();
				this._durTime = time;
				int num2 = NetManager.Instance().SendCommand<T1>(this._serverType, cmd);
			}
			return true;
		}

		// Token: 0x06009B3C RID: 39740 RVA: 0x001E09DC File Offset: 0x001DEDDC
		private void _OnMessageReceived(MsgDATA data)
		{
			this.mRes.decode(data.bytes);
			T1 req = this.mReq.Peek();
			if (this.comparor != null && this.comparor(req, this.mRes))
			{
				this.mReq.Dequeue();
			}
		}

		// Token: 0x040054B8 RID: 21688
		private Queue<T1> mReq;

		// Token: 0x040054B9 RID: 21689
		private T2 mRes;

		// Token: 0x040054BA RID: 21690
		private Action<MsgDATA> _handle;

		// Token: 0x040054BB RID: 21691
		private float _durTime;

		// Token: 0x040054BC RID: 21692
		private float _timeOut;

		// Token: 0x040054BD RID: 21693
		private ServerType _serverType;

		// Token: 0x040054BE RID: 21694
		public MessageWait<T1, T2>.Comparor comparor;

		// Token: 0x02000FDC RID: 4060
		// (Invoke) Token: 0x06009B3E RID: 39742
		public delegate bool Comparor(T1 req, T2 res);
	}
}
