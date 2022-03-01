using System;
using System.Timers;
using Protocol;

namespace Network
{
	// Token: 0x020001D0 RID: 464
	public class NetworkSocket
	{
		// Token: 0x06000ECC RID: 3788 RVA: 0x0004BAB8 File Offset: 0x00049EB8
		public NetworkSocket(ServerType type)
		{
			this.serverType = type;
			this.netWorkBase = new NetWorkBase(type);
			this.inBuffer = new NetInputBuffer();
			this.outBuffer = new NetOutputBuffer(this.netWorkBase);
			this.timer = new Timer((double)(NetworkSocket.TIME_OUT_SECONDS * 1000));
			this.timer.Elapsed += this.OnTimeOut;
			this.timeoutCB = null;
			this.msgRealLength = 9999999;
			this.msgReceiveLength = 0;
			this.newMsg = true;
			NetworkSocket.msgSendLength = 0;
			NetworkSocket.timeOutMilliseconds = NetworkSocket.TIME_OUT_SECONDS * 1000;
			this.isInited = true;
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000ECD RID: 3789 RVA: 0x0004BB97 File Offset: 0x00049F97
		// (set) Token: 0x06000ECE RID: 3790 RVA: 0x0004BB9F File Offset: 0x00049F9F
		public bool canSend
		{
			get
			{
				return this.mCanSend;
			}
			set
			{
				if (this.mCanSend != value)
				{
				}
				this.mCanSend = value;
			}
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x0004BBB4 File Offset: 0x00049FB4
		private string GetSocketName()
		{
			return this.serverIP + this.serverPort;
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x0004BBCC File Offset: 0x00049FCC
		public bool IsConnected()
		{
			return this.netWorkBase.IsNetworkOK();
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x0004BBDC File Offset: 0x00049FDC
		public bool ConnectToServer(string addr, int port, int maxtimeOut = 10000)
		{
			if (!this.isInited)
			{
				return false;
			}
			this.Disconnect();
			this.serverIP = addr;
			this.serverPort = port;
			if (!this.netWorkBase.Connect(this.serverIP, this.serverPort, maxtimeOut, null))
			{
				return false;
			}
			this.inBuffer.CleanUp();
			this.outBuffer.CleanUp();
			this.netWorkBase.Receive(this.inBuffer.GetRawBuffer(), this.inBuffer.GetCurrentOffset(), this.inBuffer.GetCurrentSize(), new NetWorkReceiveCallback(this.ReceiveCallback));
			return true;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x0004BC79 File Offset: 0x0004A079
		public void StartRecv()
		{
			this.netWorkBase.Receive(this.inBuffer.GetRawBuffer(), this.inBuffer.GetCurrentOffset(), this.inBuffer.GetCurrentSize(), new NetWorkReceiveCallback(this.ReceiveCallback));
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x0004BCB4 File Offset: 0x0004A0B4
		public bool ReSendData(uint sequence)
		{
			int num = this.packetBuffer.FetchPacket(sequence, NetworkSocket.cmdBuffer);
			if (num > 0)
			{
				int num2 = this.outBuffer.Write(ref NetworkSocket.cmdBuffer, num);
				if (num2 != num)
				{
					return false;
				}
			}
			else if (num < 0)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x0004BD04 File Offset: 0x0004A104
		public void ClearReSendData()
		{
			this.packetBuffer.Clear();
			this.canSend = true;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x0004BD18 File Offset: 0x0004A118
		public void ResetResend()
		{
			this.canSend = true;
		}

		// Token: 0x06000ED6 RID: 3798 RVA: 0x0004BD24 File Offset: 0x0004A124
		public void ConnectToServerAsync(string addr, int port, int maxtimeOut, ConnectCallback cb, int tryCount = 0)
		{
			if (this.netWorkBase.GetCurrentStatus() == NetWorkBase.NETMANAGER_STATUS.CONNECTING)
			{
				return;
			}
			if (!this.isInited)
			{
				return;
			}
			if (this.netWorkBase.IsNetworkOK())
			{
				this.Disconnect();
			}
			this.serverIP = addr;
			this.serverPort = port;
			this.lastRecvTime = Environment.TickCount;
			this.netWorkBase.ConnectAsync(this.serverIP, this.serverPort, maxtimeOut, delegate(bool isDone, string errInfo)
			{
				if (isDone)
				{
					this.inBuffer.CleanUp();
					this.outBuffer.CleanUp();
					this.netWorkBase.Receive(this.inBuffer.GetRawBuffer(), this.inBuffer.GetCurrentOffset(), this.inBuffer.GetCurrentSize(), new NetWorkReceiveCallback(this.ReceiveCallback));
					this.lastRecvTime = Environment.TickCount;
					cb(true);
				}
				else if (tryCount > 0)
				{
					this.ConnectToServerAsync(addr, port, maxtimeOut, cb, tryCount - 1);
				}
				else
				{
					cb(false);
				}
			});
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x0004BDE4 File Offset: 0x0004A1E4
		public int SendCommand<CommandType>(CommandType cmd) where CommandType : IProtocolStream, IGetMsgID
		{
			if (Global.Settings.isDebug)
			{
				string text = string.Format("Send msg {0} {1}", Singleton<ProtocolHelper>.instance.GetName(cmd.GetMsgID()), cmd.GetMsgID());
			}
			int msgLen = 0;
			cmd.encode(NetworkSocket.cmdBuffer, ref msgLen);
			return this.SendData(cmd.GetMsgID(), cmd.GetSequence(), NetworkSocket.cmdBuffer, msgLen, 0, null);
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x0004BE74 File Offset: 0x0004A274
		public int SendData(uint msgId, uint sequence, byte[] msgBytes, int msgLen, int timeOutSeconds, PushNetErrorCallback timeOutCallback = null)
		{
			if (sequence > 0U && msgId != 300306U)
			{
				this.packetBuffer.WritePacket(msgId, sequence, msgBytes, (ushort)msgLen);
				if (!this.canSend)
				{
					return -1;
				}
			}
			if (this.netWorkBase.GetCurrentStatus() != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
			{
				NetManager.Instance().PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
				return -1;
			}
			if (!this.isInited)
			{
				return -2;
			}
			if (msgBytes == null)
			{
				msgLen = 0;
			}
			this.timeoutCB = timeOutCallback;
			int tail = this.outBuffer.m_Tail;
			this.outBuffer.WriteUShort((ushort)msgLen);
			this.outBuffer.WriteUint(msgId);
			this.outBuffer.WriteUint(sequence);
			if (sequence <= 0U || msgId == 506811U)
			{
			}
			if (msgLen <= 0 || this.outBuffer.Write(ref msgBytes, msgLen) != msgLen)
			{
			}
			int tail2 = this.outBuffer.m_Tail;
			return msgLen + 10;
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0004BF6B File Offset: 0x0004A36B
		public void Disconnect()
		{
			if (!this.isInited)
			{
				return;
			}
			this.inBuffer.CleanUp();
			this.outBuffer.CleanUp();
			this.netWorkBase.ShutDown();
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x0004BF9C File Offset: 0x0004A39C
		public void Tick()
		{
			if (!this.isInited)
			{
				return;
			}
			if (this.IsConnected() && Environment.TickCount - this.lastRecvTime >= 60000)
			{
				this.Disconnect();
				NetManager.Instance().PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
				return;
			}
			if (NetManager.Instance().Show)
			{
			}
			try
			{
				if (this.outBuffer.Length() != 0)
				{
					this.outBuffer.Flush();
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x0004C03C File Offset: 0x0004A43C
		private void OnTimeOut(object source, ElapsedEventArgs e)
		{
			if (!this.isInited)
			{
				return;
			}
			if (this.timeoutCB != null)
			{
				this.timeoutCB(1, "Request " + this.lastRequestID + " is not responsed.");
			}
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0004C07C File Offset: 0x0004A47C
		protected int ProcessCommand()
		{
			ushort num = 0;
			int num2 = 0;
			while (this.inBuffer.GetPackLength() + 10 <= this.inBuffer.Length())
			{
				if (this.timer.Enabled)
				{
					this.timer.Stop();
				}
				this.inBuffer.ReadUShort(ref num);
				uint num3 = 0U;
				this.inBuffer.ReadUint(ref num3);
				uint sequence = 0U;
				this.inBuffer.ReadUint(ref sequence);
				num2 += 10;
				num2 += (int)num;
				if (num > 0)
				{
					byte[] array = new byte[(int)num];
					this.inBuffer.Read(ref array, (int)num);
					MsgDATA msgDATA = new MsgDATA((int)num);
					msgDATA.serverType = this.serverType;
					msgDATA.id = (num3 & 2147483647U);
					msgDATA.sequence = sequence;
					if (((ulong)num3 & 18446744071562067968UL) != 0UL)
					{
						msgDATA.bytes = CompressHelper.Uncompress(array, array.Length);
					}
					else
					{
						msgDATA.bytes = array;
					}
					NetProcess.Instance().PushQueue(msgDATA);
				}
				else
				{
					MsgDATA msgDATA2 = new MsgDATA(0);
					msgDATA2.serverType = this.serverType;
					msgDATA2.id = num3;
					msgDATA2.sequence = sequence;
					NetProcess.Instance().PushQueue(msgDATA2);
				}
				this.lastRecvTime = Environment.TickCount;
			}
			return num2;
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x0004C1CC File Offset: 0x0004A5CC
		protected void ConnAsyncCallback(bool isDone, string errInfo)
		{
			if (isDone)
			{
				this.inBuffer.CleanUp();
				this.outBuffer.CleanUp();
				this.netWorkBase.Receive(this.inBuffer.GetRawBuffer(), this.inBuffer.GetCurrentOffset(), this.inBuffer.GetCurrentSize(), new NetWorkReceiveCallback(this.ReceiveCallback));
			}
			else
			{
				this.Disconnect();
			}
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0004C238 File Offset: 0x0004A638
		protected void ReceiveCallback(bool isDone, int bytesRead, string errInfo)
		{
			if (bytesRead > 0)
			{
				this.inBuffer.m_Tail += bytesRead;
				this.msgReceiveLength += bytesRead;
				if (this.newMsg && this.msgReceiveLength >= 10)
				{
					this.msgRealLength = this.inBuffer.GetPackLength() + 10;
					this.newMsg = false;
				}
				if (this.msgReceiveLength >= this.msgRealLength)
				{
					int num = this.ProcessCommand();
					this.msgReceiveLength -= num;
					this.newMsg = true;
				}
				this.netWorkBase.Receive(this.inBuffer.GetRawBuffer(), this.inBuffer.GetCurrentOffset(), this.inBuffer.GetCurrentSize(), new NetWorkReceiveCallback(this.ReceiveCallback));
			}
			else if (bytesRead == 0)
			{
				this.netWorkBase.ShutDown();
				NetManager.Instance().PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
			}
			else
			{
				this.netWorkBase.ShutDown();
				NetManager.Instance().PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
			}
		}

		// Token: 0x04000A2E RID: 2606
		private ServerType serverType;

		// Token: 0x04000A2F RID: 2607
		public static int TIME_OUT_SECONDS = 10;

		// Token: 0x04000A30 RID: 2608
		public static byte[] cmdBuffer = new byte[65535];

		// Token: 0x04000A31 RID: 2609
		private bool mCanSend = true;

		// Token: 0x04000A32 RID: 2610
		protected bool isInited;

		// Token: 0x04000A33 RID: 2611
		protected string serverIP = string.Empty;

		// Token: 0x04000A34 RID: 2612
		protected int serverPort;

		// Token: 0x04000A35 RID: 2613
		protected NetWorkBase netWorkBase;

		// Token: 0x04000A36 RID: 2614
		protected NetInputBuffer inBuffer;

		// Token: 0x04000A37 RID: 2615
		protected NetOutputBuffer outBuffer;

		// Token: 0x04000A38 RID: 2616
		private PacketBuffer packetBuffer = new PacketBuffer();

		// Token: 0x04000A39 RID: 2617
		protected int msgRealLength = -1;

		// Token: 0x04000A3A RID: 2618
		protected int msgReceiveLength = -1;

		// Token: 0x04000A3B RID: 2619
		protected bool newMsg;

		// Token: 0x04000A3C RID: 2620
		protected static int msgSendLength = -1;

		// Token: 0x04000A3D RID: 2621
		protected static int timeOutMilliseconds = -1;

		// Token: 0x04000A3E RID: 2622
		protected int lastRequestID = -1;

		// Token: 0x04000A3F RID: 2623
		protected DealReceive ReceiveCallBack;

		// Token: 0x04000A40 RID: 2624
		protected Timer timer;

		// Token: 0x04000A41 RID: 2625
		protected PushNetErrorCallback timeoutCB;

		// Token: 0x04000A42 RID: 2626
		protected int lastRecvTime;
	}
}
