using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x02001347 RID: 4935
	public class WaitNetMessageManager : DataManager<WaitNetMessageManager>
	{
		// Token: 0x0600BF86 RID: 49030 RVA: 0x002D154A File Offset: 0x002CF94A
		public override void Initialize()
		{
		}

		// Token: 0x0600BF87 RID: 49031 RVA: 0x002D154C File Offset: 0x002CF94C
		public override void Clear()
		{
			while (this.m_arrWaitMsgData.Count > 0)
			{
				this._UnRegister(this.m_arrWaitMsgData[0]);
			}
		}

		// Token: 0x0600BF88 RID: 49032 RVA: 0x002D1578 File Offset: 0x002CF978
		public new void Update(float a_fElapsed)
		{
			for (int i = 0; i < this.m_arrWaitMsgData.Count; i++)
			{
				WaitNetMessageManager.WaitData waitData = this.m_arrWaitMsgData[i];
				if (!waitData.bWaitForever)
				{
					waitData.fWaitTime -= a_fElapsed;
					if (waitData.fWaitTime <= 0f)
					{
						waitData.HandleTimeOut();
						i--;
					}
				}
			}
		}

		// Token: 0x0600BF89 RID: 49033 RVA: 0x002D15E4 File Offset: 0x002CF9E4
		public WaitNetMessageManager.IWaitData Wait(uint a_nMsgID, Action<MsgDATA> a_handle, bool a_bModal = true, float a_fWaitTime = 15f, Action a_timeOutHandle = null)
		{
			WaitNetMessageManager.WaitBase waitBase = new WaitNetMessageManager.WaitBase();
			waitBase.InitMsgIDs(new uint[]
			{
				a_nMsgID
			});
			waitBase.fWaitTime = a_fWaitTime;
			waitBase.bWaitForever = (a_fWaitTime <= 0f);
			waitBase.bModal = a_bModal;
			waitBase.handle = a_handle;
			waitBase.timeOutHandle = a_timeOutHandle;
			waitBase.manager = this;
			this._Register(waitBase);
			return waitBase;
		}

		// Token: 0x0600BF8A RID: 49034 RVA: 0x002D1648 File Offset: 0x002CFA48
		public WaitNetMessageManager.IWaitData Wait<T>(Action<T> a_handle, bool a_bModal = true, float a_fWaitTime = 15f, Action a_timeOutHandle = null) where T : IProtocolStream, IGetMsgID, new()
		{
			WaitNetMessageManager.WaitSpecial<T> waitSpecial = new WaitNetMessageManager.WaitSpecial<T>();
			waitSpecial.InitMsgIDs(new uint[]
			{
				waitSpecial.newData.GetMsgID()
			});
			waitSpecial.fWaitTime = a_fWaitTime;
			waitSpecial.bWaitForever = (a_fWaitTime <= 0f);
			waitSpecial.bModal = a_bModal;
			waitSpecial.handle = a_handle;
			waitSpecial.timeOutHandle = a_timeOutHandle;
			waitSpecial.manager = this;
			this._Register(waitSpecial);
			return waitSpecial;
		}

		// Token: 0x0600BF8B RID: 49035 RVA: 0x002D16B8 File Offset: 0x002CFAB8
		public WaitNetMessageManager.WaitMulti Wait(uint[] a_arrMsgIDs, Action<WaitNetMessageManager.NetMessages> a_handle, bool a_bModal = true, float a_fWaitTime = 15f, Action a_timeOutHandle = null)
		{
			WaitNetMessageManager.WaitMulti waitMulti = new WaitNetMessageManager.WaitMulti();
			waitMulti.InitMsgIDs(a_arrMsgIDs);
			waitMulti.fWaitTime = a_fWaitTime;
			waitMulti.bWaitForever = (a_fWaitTime <= 0f);
			waitMulti.bModal = a_bModal;
			waitMulti.handle = a_handle;
			waitMulti.timeOutHandle = a_timeOutHandle;
			waitMulti.manager = this;
			this._Register(waitMulti);
			return waitMulti;
		}

		// Token: 0x0600BF8C RID: 49036 RVA: 0x002D1711 File Offset: 0x002CFB11
		public void CancelWait(WaitNetMessageManager.IWaitData a_waitData)
		{
			if (a_waitData == null)
			{
				return;
			}
			this._UnRegister(a_waitData as WaitNetMessageManager.WaitData);
		}

		// Token: 0x0600BF8D RID: 49037 RVA: 0x002D1728 File Offset: 0x002CFB28
		private void _Register(WaitNetMessageManager.WaitData a_waitData)
		{
			this.m_arrWaitMsgData.Add(a_waitData);
			for (int i = 0; i < a_waitData.nMsgIDs.Length; i++)
			{
				NetProcess.AddMsgHandler(a_waitData.nMsgIDs[i], new Action<MsgDATA>(a_waitData.HandleMsg));
			}
			if (a_waitData.bModal)
			{
				WaitNetMessageFrame.TryOpen();
			}
		}

		// Token: 0x0600BF8E RID: 49038 RVA: 0x002D1784 File Offset: 0x002CFB84
		private void _UnRegister(WaitNetMessageManager.WaitData a_waitData)
		{
			if (this.m_arrWaitMsgData.Contains(a_waitData))
			{
				this.m_arrWaitMsgData.Remove(a_waitData);
				for (int i = 0; i < a_waitData.nMsgIDs.Length; i++)
				{
					NetProcess.RemoveMsgHandler(a_waitData.nMsgIDs[i], new Action<MsgDATA>(a_waitData.HandleMsg));
				}
				if (a_waitData.bModal)
				{
					WaitNetMessageFrame.TryClose();
				}
			}
		}

		// Token: 0x04006C0D RID: 27661
		private List<WaitNetMessageManager.WaitData> m_arrWaitMsgData = new List<WaitNetMessageManager.WaitData>();

		// Token: 0x02001348 RID: 4936
		public class NetMessages
		{
			// Token: 0x0600BF90 RID: 49040 RVA: 0x002D1805 File Offset: 0x002CFC05
			public void AddMessage(uint msgID)
			{
				if (this._GetMessage(msgID) == null)
				{
					this._AddMessage(msgID);
				}
			}

			// Token: 0x0600BF91 RID: 49041 RVA: 0x002D181C File Offset: 0x002CFC1C
			public void SetMessageData(uint msgID, MsgDATA data)
			{
				WaitNetMessageManager.NetMessages.Message message = this._GetMessage(msgID);
				if (message != null)
				{
					if (message.DataList == null)
					{
						message.DataList = new List<MsgDATA>();
					}
					message.DataList.Add(data);
				}
			}

			// Token: 0x0600BF92 RID: 49042 RVA: 0x002D185C File Offset: 0x002CFC5C
			public MsgDATA GetMessageData(uint msgID)
			{
				WaitNetMessageManager.NetMessages.Message message = this._GetMessage(msgID);
				if (message != null && message.DataList != null)
				{
					return message.DataList[0];
				}
				return null;
			}

			// Token: 0x0600BF93 RID: 49043 RVA: 0x002D1890 File Offset: 0x002CFC90
			public List<MsgDATA> GetMessageDatas(uint msgID)
			{
				WaitNetMessageManager.NetMessages.Message message = this._GetMessage(msgID);
				if (message != null)
				{
					return message.DataList;
				}
				return null;
			}

			// Token: 0x0600BF94 RID: 49044 RVA: 0x002D18B4 File Offset: 0x002CFCB4
			public bool IsAllMessageReceived()
			{
				for (int i = 0; i < this.m_messages.Count; i++)
				{
					if (this.m_messages[i].DataList == null)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x0600BF95 RID: 49045 RVA: 0x002D18F8 File Offset: 0x002CFCF8
			public string GetUnReceivedMessageDesc()
			{
				string str = "[WaitNetMessageManager] 等待消息";
				for (int i = 0; i < this.m_messages.Count; i++)
				{
					WaitNetMessageManager.NetMessages.Message message = this.m_messages[i];
					if (message.DataList == null)
					{
						str += " ";
						str += Singleton<ProtocolHelper>.GetInstance().GetName(message.ID);
					}
				}
				return str + "超时";
			}

			// Token: 0x0600BF96 RID: 49046 RVA: 0x002D1970 File Offset: 0x002CFD70
			private WaitNetMessageManager.NetMessages.Message _GetMessage(uint id)
			{
				for (int i = 0; i < this.m_messages.Count; i++)
				{
					if (this.m_messages[i].ID == id)
					{
						return this.m_messages[i];
					}
				}
				return null;
			}

			// Token: 0x0600BF97 RID: 49047 RVA: 0x002D19C0 File Offset: 0x002CFDC0
			private void _AddMessage(uint id)
			{
				WaitNetMessageManager.NetMessages.Message message = new WaitNetMessageManager.NetMessages.Message();
				message.ID = id;
				message.DataList = null;
				this.m_messages.Add(message);
			}

			// Token: 0x04006C0E RID: 27662
			private List<WaitNetMessageManager.NetMessages.Message> m_messages = new List<WaitNetMessageManager.NetMessages.Message>();

			// Token: 0x02001349 RID: 4937
			private class Message
			{
				// Token: 0x04006C0F RID: 27663
				public uint ID;

				// Token: 0x04006C10 RID: 27664
				public List<MsgDATA> DataList;
			}
		}

		// Token: 0x0200134A RID: 4938
		public interface IWaitData
		{
		}

		// Token: 0x0200134B RID: 4939
		public abstract class WaitData : WaitNetMessageManager.IWaitData
		{
			// Token: 0x0600BF9A RID: 49050 RVA: 0x002D19FD File Offset: 0x002CFDFD
			public virtual void InitMsgIDs(params uint[] a_arrMsgIDs)
			{
				this.nMsgIDs = a_arrMsgIDs;
			}

			// Token: 0x0600BF9B RID: 49051
			public abstract void HandleTimeOut();

			// Token: 0x0600BF9C RID: 49052
			public abstract void HandleMsg(MsgDATA a_msgData);

			// Token: 0x04006C11 RID: 27665
			public uint[] nMsgIDs;

			// Token: 0x04006C12 RID: 27666
			public float fWaitTime;

			// Token: 0x04006C13 RID: 27667
			public bool bWaitForever;

			// Token: 0x04006C14 RID: 27668
			public bool bTimeOutQuit;

			// Token: 0x04006C15 RID: 27669
			public bool bModal;

			// Token: 0x04006C16 RID: 27670
			public Action timeOutHandle;

			// Token: 0x04006C17 RID: 27671
			public WaitNetMessageManager manager;
		}

		// Token: 0x0200134C RID: 4940
		public class WaitBase : WaitNetMessageManager.WaitData
		{
			// Token: 0x0600BF9E RID: 49054 RVA: 0x002D1A0E File Offset: 0x002CFE0E
			public override void HandleTimeOut()
			{
				if (this.manager != null)
				{
					this.manager._UnRegister(this);
				}
				if (this.timeOutHandle != null)
				{
					this.timeOutHandle();
				}
			}

			// Token: 0x0600BF9F RID: 49055 RVA: 0x002D1A3D File Offset: 0x002CFE3D
			public override void HandleMsg(MsgDATA a_msgData)
			{
				if (this.manager != null)
				{
					this.manager._UnRegister(this);
				}
				if (this.handle != null)
				{
					this.handle(a_msgData);
				}
			}

			// Token: 0x04006C18 RID: 27672
			public Action<MsgDATA> handle;
		}

		// Token: 0x0200134D RID: 4941
		public class WaitSpecial<T> : WaitNetMessageManager.WaitData where T : IProtocolStream, new()
		{
			// Token: 0x0600BFA1 RID: 49057 RVA: 0x002D1A80 File Offset: 0x002CFE80
			public override void HandleTimeOut()
			{
				if (this.manager != null)
				{
					this.manager._UnRegister(this);
				}
				if (this.timeOutHandle != null)
				{
					this.timeOutHandle();
				}
			}

			// Token: 0x0600BFA2 RID: 49058 RVA: 0x002D1AB0 File Offset: 0x002CFEB0
			public override void HandleMsg(MsgDATA a_msgData)
			{
				if (this.manager != null)
				{
					this.manager._UnRegister(this);
				}
				if (this.handle != null)
				{
					if (a_msgData == null)
					{
						this.handle(default(T));
					}
					else
					{
						this.newData.decode(a_msgData.bytes);
						this.handle(this.newData);
					}
				}
			}

			// Token: 0x04006C19 RID: 27673
			public Action<T> handle;

			// Token: 0x04006C1A RID: 27674
			public T newData = Activator.CreateInstance<T>();
		}

		// Token: 0x0200134E RID: 4942
		public class WaitMulti : WaitNetMessageManager.WaitData
		{
			// Token: 0x0600BFA4 RID: 49060 RVA: 0x002D1B38 File Offset: 0x002CFF38
			public override void InitMsgIDs(params uint[] a_arrMsgIDs)
			{
				this.nMsgIDs = a_arrMsgIDs;
				for (int i = 0; i < this.nMsgIDs.Length; i++)
				{
					this.m_netMessage.AddMessage(this.nMsgIDs[i]);
				}
			}

			// Token: 0x0600BFA5 RID: 49061 RVA: 0x002D1B78 File Offset: 0x002CFF78
			public override void HandleTimeOut()
			{
				if (this.manager != null)
				{
					this.manager._UnRegister(this);
				}
				if (this.timeOutHandle != null)
				{
					this.timeOutHandle();
				}
			}

			// Token: 0x0600BFA6 RID: 49062 RVA: 0x002D1BA8 File Offset: 0x002CFFA8
			public override void HandleMsg(MsgDATA a_msgData)
			{
				this.m_netMessage.SetMessageData(a_msgData.id, a_msgData);
				if (this.m_netMessage.IsAllMessageReceived())
				{
					if (this.manager != null)
					{
						this.manager._UnRegister(this);
					}
					if (this.handle != null)
					{
						this.handle(this.m_netMessage);
					}
				}
			}

			// Token: 0x04006C1B RID: 27675
			public Action<WaitNetMessageManager.NetMessages> handle;

			// Token: 0x04006C1C RID: 27676
			public WaitNetMessageManager.NetMessages m_netMessage = new WaitNetMessageManager.NetMessages();
		}
	}
}
