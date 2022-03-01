using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using GameClient;
using Xxtea;

namespace Network
{
	// Token: 0x020001C5 RID: 453
	internal class NetProcess
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0004A8E0 File Offset: 0x00048CE0
		public EventRouter<uint> msgHandler
		{
			get
			{
				return this.msgRouter;
			}
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x0004A8E8 File Offset: 0x00048CE8
		public static EventRouter<uint> sMsgHandler
		{
			get
			{
				return NetProcess.instance.msgHandler;
			}
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x0004A8F4 File Offset: 0x00048CF4
		public void Clear()
		{
			this.recvMaxSequence = 0U;
			NetProcess.instance.msgRouter.ClearAllEvents();
			NetProcess.instance.msgQueue.Clear();
			MonoSingleton<NetManager>.instance.RegisterBaseHandler();
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x0004A925 File Offset: 0x00048D25
		public static void AddMsgHandler(uint msgID, Action<MsgDATA> handler)
		{
			NetProcess.RemoveMsgHandler(msgID, handler);
			NetProcess.sMsgHandler.AddEventHandler<MsgDATA>(msgID, handler);
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x0004A93A File Offset: 0x00048D3A
		public static void RemoveMsgHandler(uint msgID, Action<MsgDATA> handler)
		{
			NetProcess.sMsgHandler.RemoveEventHandler<MsgDATA>(msgID, handler);
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x0004A948 File Offset: 0x00048D48
		public static NetProcess Instance()
		{
			if (NetProcess.instance == null)
			{
				NetProcess.instance = new NetProcess();
			}
			return NetProcess.instance;
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x0004A963 File Offset: 0x00048D63
		public void Init()
		{
			this.mAnimInterval = 0f;
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x0004A970 File Offset: 0x00048D70
		public void PushQueue(MsgDATA data)
		{
			this.msgQueueMutex.WaitOne();
			if (Global.Settings.isDebug)
			{
				MonoSingleton<NetManager>.instance.RecordReceivedMsg(data);
			}
			this.msgQueue.Enqueue(data);
			this.msgQueueMutex.ReleaseMutex();
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x0004A9B0 File Offset: 0x00048DB0
		public MsgDATA PopQueue()
		{
			this.msgQueueMutex.WaitOne();
			if (this.msgQueue.Count == 0)
			{
				this.msgQueueMutex.ReleaseMutex();
				return null;
			}
			MsgDATA result = this.msgQueue.Dequeue();
			this.msgQueueMutex.ReleaseMutex();
			return result;
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x0004A9FE File Offset: 0x00048DFE
		public void Tick(uint deltaInMillSecs)
		{
			this.msgProcessTimeAcc += deltaInMillSecs;
			this.msgTimerTimeAcc += deltaInMillSecs;
			if (NetManager.Instance().Show)
			{
			}
			this.MsgProcess();
			this.msgProcessTimeAcc = 0U;
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x0004AA38 File Offset: 0x00048E38
		protected void MsgProcess()
		{
			for (;;)
			{
				MsgDATA msgDATA = this.PopQueue();
				if (msgDATA == null)
				{
					break;
				}
				try
				{
					this.Process(msgDATA);
				}
				catch (Exception ex)
				{
					Logger.LogError("MsgProcess Exception:" + ex.ToString());
				}
			}
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x0004AA94 File Offset: 0x00048E94
		protected void Process(MsgDATA msg)
		{
			if (msg == null || msg.bytes == null)
			{
				return;
			}
			if (msg.serverType != ServerType.RELAY_SERVER)
			{
			}
			if (msg.serverType == ServerType.GATE_SERVER && msg.sequence > this.recvMaxSequence)
			{
				this.recvMaxSequence = msg.sequence;
			}
			if (msg.id == 506806U || msg.id == 500303U)
			{
				byte[] array = new byte[16];
				for (int i = 0; i < 4; i++)
				{
					int num = IPAddress.HostToNetworkOrder((int)msg.sequence);
					for (int j = 0; j < 4; j++)
					{
						byte b = (byte)(num & 255);
						array[j] = ((b != 0) ? b : byte.MaxValue);
						num >>= 8;
					}
				}
				if (ClientApplication.isEncryptProtocol)
				{
					msg.bytes = XXTEA.Decrypt(msg.bytes, array);
				}
				if (msg.bytes == null || msg.bytes.Length < 16)
				{
					Logger.LogErrorFormat("recv invalid dungeon start response, invalid length.", new object[0]);
					return;
				}
				bool flag = false;
				for (int k = msg.bytes.Length - 16; k < msg.bytes.Length; k++)
				{
					if (msg.bytes[k] != 0)
					{
						flag = true;
					}
				}
				if (flag && msg.id == 506806U)
				{
					byte[] array2 = new byte[msg.bytes.Length - 16];
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = msg.bytes[l];
					}
					byte[] md = DungeonUtility.GetMD5(array2);
					for (int m = 0; m < 16; m++)
					{
						int num2 = msg.bytes.Length - 16 + m;
						byte b2 = msg.bytes[num2];
						if (b2 != md[m])
						{
							Logger.LogErrorFormat("recv invalid dungeon start response, invalid md5.", new object[0]);
							return;
						}
					}
				}
			}
			this.msgRouter.BroadCastEvent<MsgDATA>(msg.id, msg);
		}

		// Token: 0x04000A12 RID: 2578
		private static NetProcess instance;

		// Token: 0x04000A13 RID: 2579
		protected float mAnimInterval;

		// Token: 0x04000A14 RID: 2580
		protected uint msgProcessTimeAcc;

		// Token: 0x04000A15 RID: 2581
		protected uint msgTimerTimeAcc;

		// Token: 0x04000A16 RID: 2582
		protected Queue<MsgDATA> msgQueue = new Queue<MsgDATA>();

		// Token: 0x04000A17 RID: 2583
		public uint recvMaxSequence;

		// Token: 0x04000A18 RID: 2584
		private Mutex msgQueueMutex = new Mutex();

		// Token: 0x04000A19 RID: 2585
		protected EventRouter<uint> msgRouter = new EventRouter<uint>();
	}
}
