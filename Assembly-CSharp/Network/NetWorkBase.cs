using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using GamePool;
using UnityEngine;

namespace Network
{
	// Token: 0x020001C9 RID: 457
	public class NetWorkBase
	{
		// Token: 0x06000EAB RID: 3755 RVA: 0x0004ACAC File Offset: 0x000490AC
		public NetWorkBase(ServerType type)
		{
			if (this.isInited)
			{
				return;
			}
			this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
			this.isInited = true;
			this.serverType = type;
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x0004ACFE File Offset: 0x000490FE
		public NetWorkBase.NETMANAGER_STATUS GetCurrentStatus()
		{
			return this.netStatus;
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x0004AD06 File Offset: 0x00049106
		private void SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS status)
		{
			this.netStatus = status;
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x0004AD0F File Offset: 0x0004910F
		public bool IsNetworkReachable()
		{
			return Application.internetReachability != 0;
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x0004AD1C File Offset: 0x0004911C
		public bool IsNetworkOK()
		{
			return this.client != null && this.netStatus == NetWorkBase.NETMANAGER_STATUS.CONNECTED;
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x0004AD38 File Offset: 0x00049138
		public bool Connect(string addr, int port, int MaxtimeOut, NetWorkStatusCallback cb = null)
		{
			this.connCB = cb;
			if (!this.isInited)
			{
				if (this.connCB != null)
				{
					this.connCB(false, "NetWorkBase is not initialized.");
				}
				return false;
			}
			bool result;
			try
			{
				IPAddress address = IPAddress.Parse(addr);
				IPEndPoint remoteEP = new IPEndPoint(address, port);
				this.client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				if (this.client == null)
				{
					this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
					if (this.connCB != null)
					{
						this.connCB(false, "Create Socket Failed");
					}
					result = false;
				}
				else
				{
					this.connectDone.Reset();
					this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.CONNECTING);
					this.client.BeginConnect(remoteEP, new AsyncCallback(this.ConnectCallback), this.client);
					if (!this.connectDone.WaitOne(MaxtimeOut, false))
					{
						this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
						throw new TimeoutException("Connect TimeOut");
					}
					if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
					{
						this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
						throw new Exception("Connect Failed");
					}
					if (this.connCB != null)
					{
						this.connCB(true, string.Empty);
					}
					result = true;
				}
			}
			catch (Exception ex)
			{
				this.ShutDown();
				this.connectDone.Reset();
				if (this.connCB != null)
				{
					this.connCB(false, "NetworkBase Connect: " + ex.ToString());
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x0004AEB0 File Offset: 0x000492B0
		public void ConnectAsync(string addr, int port, int MaxtimeOut, NetWorkStatusCallback cb = null)
		{
			this.connCB = cb;
			if (!this.isInited)
			{
				if (this.connCB != null)
				{
					this.connCB(false, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				IPAddress address = IPAddress.Parse(addr);
				IPEndPoint remoteEP = new IPEndPoint(address, port);
				this.client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				if (this.client == null)
				{
					this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
					if (this.connCB != null)
					{
						this.connCB(false, "Create Socket Failed");
					}
				}
				else
				{
					this.connectDone.Reset();
					this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.CONNECTING);
					this.client.BeginConnect(remoteEP, new AsyncCallback(this.ConnectAsyncCallback), this.client);
					Thread thread = new Thread(new ParameterizedThreadStart(this._OnWaitConnectAsyncReturnThread));
					thread.Start(MaxtimeOut);
				}
			}
			catch (Exception ex)
			{
				this.ShutDown();
				if (this.connCB != null)
				{
					this.connCB(false, "NetworkBase Connect: " + ex.ToString());
				}
			}
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x0004AFD8 File Offset: 0x000493D8
		protected void _OnWaitConnectAsyncReturnThread(object obj)
		{
			int millisecondsTimeout = int.Parse(obj.ToString());
			if (this.connectDone.WaitOne(millisecondsTimeout, false))
			{
				if (this.netStatus == NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.connCB != null)
					{
						this.connCB(true, string.Empty);
					}
					return;
				}
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.connCB != null)
				{
					this.connCB(false, "Connect Failed");
				}
			}
			else
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.connCB != null)
				{
					this.connCB(false, "Connect TimeOut");
				}
			}
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x0004B078 File Offset: 0x00049478
		public void ShutDown()
		{
			if (this.GetCurrentStatus() == NetWorkBase.NETMANAGER_STATUS.NO_CONNECT)
			{
				return;
			}
			this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
			this.connectDone.Reset();
			if (!this.isInited)
			{
				return;
			}
			try
			{
				if (this.client != null)
				{
					this.client.Shutdown(SocketShutdown.Both);
					this.client.Close();
					this.client = null;
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x0004B0F8 File Offset: 0x000494F8
		public bool SendByPool(MsgBuffer buffer, NetWorkStatusCallback cb = null)
		{
			this.sendCB = cb;
			if (!this.isInited)
			{
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetWorkBase is not initialized.");
				}
				return true;
			}
			try
			{
				if (this.client == null)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase Send: Socket is not created.");
					}
					return true;
				}
				if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase Send: Socket is not created.");
					}
					return true;
				}
				SendContex sendContex = this.sendContexPool.Get();
				sendContex.sock = this.client;
				sendContex.buffer = buffer;
				SocketError socketError;
				this.client.BeginSend(buffer.data, 0, buffer.length, SocketFlags.None, out socketError, new AsyncCallback(this.SendCallbackWithPool), sendContex);
			}
			catch (Exception ex)
			{
				this.ShutDown();
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetworkBase Send Exception: " + ex.ToString());
				}
			}
			return true;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x0004B22C File Offset: 0x0004962C
		public void Send(byte[] byteData, int offset, int buffLen, NetWorkStatusCallback cb = null)
		{
			this.sendCB = cb;
			if (!this.isInited)
			{
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase Send: Socket is not created.");
					}
				}
				else if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase Send: Socket is not created.");
					}
				}
				else
				{
					SocketError socketError;
					this.client.BeginSend(byteData, offset, buffLen, SocketFlags.None, out socketError, new AsyncCallback(this.SendCallback), this.client);
				}
			}
			catch (Exception ex)
			{
				this.ShutDown();
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetworkBase Send Exception: " + ex.ToString());
				}
			}
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x0004B334 File Offset: 0x00049734
		public void Receive(byte[] byteData, int offset, int size, NetWorkReceiveCallback cb = null)
		{
			this.recvCB = cb;
			if (!this.isInited)
			{
				if (this.recvCB != null)
				{
					this.recvCB(false, -1, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.recvCB != null)
					{
						this.recvCB(false, -1, "NetworkBase Receive: Socket is not created.");
					}
				}
				else if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.recvCB != null)
					{
						this.recvCB(false, -1, "NetworkBase Receive: netStatus is not CONNECT_SUCESS.");
					}
				}
				else
				{
					this.client.BeginReceive(byteData, offset, size, SocketFlags.None, new AsyncCallback(this.ReceiveCallback), this.client);
				}
			}
			catch (Exception ex)
			{
				this.ShutDown();
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.recvCB != null)
				{
					this.recvCB(false, -1, "NetworkBase Receive Exception: " + ex.ToString());
				}
			}
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x0004B440 File Offset: 0x00049840
		private void ConnectCallback(IAsyncResult ar)
		{
			if (!this.isInited)
			{
				if (this.connCB != null)
				{
					this.connCB(false, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.connCB != null)
					{
						this.connCB(false, "NetworkBase ConnectCallback: Socket is not created.");
					}
				}
				else
				{
					Socket socket = (Socket)ar.AsyncState;
					if (socket != null)
					{
						socket.EndConnect(ar);
						this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.CONNECTED);
					}
					else
					{
						this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
					}
				}
			}
			catch (Exception ex)
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.connCB != null)
				{
					this.connCB(false, "NetworkBase ConnectCallback Exception: " + ex.ToString());
				}
				this.ShutDown();
			}
			finally
			{
				this.connectDone.Set();
			}
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x0004B538 File Offset: 0x00049938
		private void ConnectAsyncCallback(IAsyncResult ar)
		{
			if (!this.isInited)
			{
				if (this.connCB != null)
				{
					this.connCB(false, "NetWorkBase is not initialized.");
				}
				this.connectDone.Set();
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.connCB != null)
					{
						this.connCB(false, "NetworkBase ConnectAsyncCallback: Socket is not created.");
					}
				}
				else
				{
					Socket socket = (Socket)ar.AsyncState;
					if (socket != null)
					{
						socket.EndConnect(ar);
						this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.CONNECTED);
					}
				}
			}
			catch (Exception ex)
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.connCB != null)
				{
					this.connCB(false, "NetworkBase ConnectAsyncCallback Exception: " + ex.ToString());
				}
				this.ShutDown();
			}
			finally
			{
				this.connectDone.Set();
			}
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x0004B630 File Offset: 0x00049A30
		private void SendCallbackWithPool(IAsyncResult ar)
		{
			SendContex sendContex = (SendContex)ar.AsyncState;
			if (!this.isInited)
			{
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetWorkBase is not initialized.");
				}
				NetOutputBuffer.GetMsgPool().Release(sendContex.buffer);
				this.sendContexPool.Release(sendContex);
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase SendCallback: Socket is not created.");
					}
					NetOutputBuffer.GetMsgPool().Release(sendContex.buffer);
					this.sendContexPool.Release(sendContex);
					return;
				}
				if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase SendCallback: netStatus is not CONNECT_SUCESS.");
					}
					NetOutputBuffer.GetMsgPool().Release(sendContex.buffer);
					this.sendContexPool.Release(sendContex);
					return;
				}
				Socket sock = sendContex.sock;
				SocketError socketError = SocketError.Success;
				int num = sock.EndSend(ar, out socketError);
				if (socketError != SocketError.Success)
				{
				}
				if (socketError != SocketError.Success && socketError != SocketError.WouldBlock && socketError != SocketError.TryAgain && socketError != SocketError.Interrupted)
				{
					throw new Exception("Connect Failed");
				}
				if (socketError != SocketError.Success)
				{
				}
				if (this.sendCB != null)
				{
					this.sendCB(true, string.Empty);
				}
			}
			catch (Exception ex)
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				MonoSingleton<NetManager>.instance.PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetworkBase SendCallback Exception: " + ex.ToString());
				}
				this.ShutDown();
			}
			NetOutputBuffer.GetMsgPool().Release(sendContex.buffer);
			this.sendContexPool.Release(sendContex);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x0004B818 File Offset: 0x00049C18
		private void SendCallback(IAsyncResult ar)
		{
			if (!this.isInited)
			{
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase SendCallback: Socket is not created.");
					}
				}
				else if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.sendCB != null)
					{
						this.sendCB(false, "NetworkBase SendCallback: netStatus is not CONNECT_SUCESS.");
					}
				}
				else
				{
					Socket socket = (Socket)ar.AsyncState;
					SocketError socketError = SocketError.Success;
					int num = socket.EndSend(ar, out socketError);
					if (socketError != SocketError.Success)
					{
					}
					if (socketError != SocketError.Success && socketError != SocketError.WouldBlock && socketError != SocketError.TryAgain && socketError != SocketError.Interrupted)
					{
						throw new Exception("Connect Failed");
					}
					if (socketError != SocketError.Success)
					{
					}
					if (this.sendCB != null)
					{
						this.sendCB(true, string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				MonoSingleton<NetManager>.instance.PushSocketEvent(this.serverType, SocketEventType.DISCONNECT, 0U, 0U);
				if (this.sendCB != null)
				{
					this.sendCB(false, "NetworkBase SendCallback Exception: " + ex.ToString());
				}
				this.ShutDown();
			}
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0004B97C File Offset: 0x00049D7C
		private void ReceiveCallback(IAsyncResult ar)
		{
			if (!this.isInited)
			{
				if (this.recvCB != null)
				{
					this.recvCB(false, -1, "NetWorkBase is not initialized.");
				}
				return;
			}
			try
			{
				if (this.client == null)
				{
					if (this.recvCB != null)
					{
						this.recvCB(false, -1, "NetworkBase ReceiveCallback: Socket is not created.");
					}
				}
				else if (this.netStatus != NetWorkBase.NETMANAGER_STATUS.CONNECTED)
				{
					if (this.recvCB != null)
					{
						this.recvCB(false, -1, "NetworkBase ReceiveCallback: netStatus is not CONNECT_SUCESS.");
					}
				}
				else
				{
					Socket socket = (Socket)ar.AsyncState;
					SocketError socketError = SocketError.Success;
					int bytesRead = socket.EndReceive(ar, out socketError);
					if (socketError != SocketError.Success)
					{
					}
					if (socketError != SocketError.Success && socketError != SocketError.WouldBlock && socketError != SocketError.TryAgain && socketError != SocketError.Interrupted)
					{
						throw new Exception("Connect Failed");
					}
					if (this.recvCB != null)
					{
						this.recvCB(true, bytesRead, "NetworkBase ReceiveCallback: netStatus is not CONNECT_SUCESS.");
					}
				}
			}
			catch (Exception ex)
			{
				this.SetCurrentStatus(NetWorkBase.NETMANAGER_STATUS.NO_CONNECT);
				if (this.recvCB != null)
				{
					this.recvCB(false, -1, "NetworkBase ReceiveCallback Exception: Connect is shutdown.");
				}
			}
		}

		// Token: 0x04000A1C RID: 2588
		private ServerType serverType;

		// Token: 0x04000A1D RID: 2589
		protected bool isInited;

		// Token: 0x04000A1E RID: 2590
		protected Socket client;

		// Token: 0x04000A1F RID: 2591
		private ManualResetEvent connectDone = new ManualResetEvent(false);

		// Token: 0x04000A20 RID: 2592
		private NetWorkBase.NETMANAGER_STATUS netStatus = NetWorkBase.NETMANAGER_STATUS.NO_CONNECT;

		// Token: 0x04000A21 RID: 2593
		private MutexObjectPool<SendContex> sendContexPool = new MutexObjectPool<SendContex>();

		// Token: 0x04000A22 RID: 2594
		protected NetWorkStatusCallback connCB;

		// Token: 0x04000A23 RID: 2595
		protected NetWorkStatusCallback sendCB;

		// Token: 0x04000A24 RID: 2596
		protected NetWorkReceiveCallback recvCB;

		// Token: 0x04000A25 RID: 2597
		protected NetWorkStatusCallback toutCB;

		// Token: 0x020001CA RID: 458
		public enum NETMANAGER_STATUS
		{
			// Token: 0x04000A27 RID: 2599
			NO_CONNECT = -1,
			// Token: 0x04000A28 RID: 2600
			CONNECTED,
			// Token: 0x04000A29 RID: 2601
			CONNECTING
		}
	}
}
