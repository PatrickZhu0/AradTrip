using System;
using System.Collections.Generic;
using Network;

namespace GameClient
{
	// Token: 0x02001234 RID: 4660
	public abstract class DataManager<T> : GameBindSystem, IDataManager where T : DataManager<T>, new()
	{
		// Token: 0x0600B341 RID: 45889 RVA: 0x001F1618 File Offset: 0x001EFA18
		protected DataManager()
		{
			if (DataManager<T>.ms_bCreated)
			{
				Logger.LogErrorFormat("{0} can not create twice!!", new object[]
				{
					typeof(T).Name
				});
			}
			DataManager<T>.ms_bCreated = true;
		}

		// Token: 0x0600B342 RID: 45890 RVA: 0x001F1668 File Offset: 0x001EFA68
		public virtual EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B343 RID: 45891
		public abstract void Initialize();

		// Token: 0x0600B344 RID: 45892
		public abstract void Clear();

		// Token: 0x0600B345 RID: 45893 RVA: 0x001F166C File Offset: 0x001EFA6C
		public virtual void Update(float a_fTime)
		{
		}

		// Token: 0x0600B346 RID: 45894 RVA: 0x001F166E File Offset: 0x001EFA6E
		public static T GetInstance()
		{
			if (DataManager<T>.ms_instance == null)
			{
				DataManager<T>.ms_instance = Activator.CreateInstance<T>();
			}
			return DataManager<T>.ms_instance;
		}

		// Token: 0x0600B347 RID: 45895 RVA: 0x001F168E File Offset: 0x001EFA8E
		public void InitiallizeSystem()
		{
			this.ClearAll();
			this.Initialize();
		}

		// Token: 0x0600B348 RID: 45896 RVA: 0x001F169C File Offset: 0x001EFA9C
		public void ProcessInitNetMessage(WaitNetMessageManager.NetMessages a_msgEvent)
		{
			this._SetupEnterGameData(a_msgEvent);
		}

		// Token: 0x0600B349 RID: 45897 RVA: 0x001F16A5 File Offset: 0x001EFAA5
		public void ClearAll()
		{
			this.Clear();
			base.ExistBindSystem();
		}

		// Token: 0x0600B34A RID: 45898 RVA: 0x001F16B4 File Offset: 0x001EFAB4
		public void BindEnterGameMsg(List<uint> a_msgEvent)
		{
			this._InitEnterGameBind();
			for (int i = 0; i < this.m_arrEnterGameBindings.Count; i++)
			{
				a_msgEvent.Add(this.m_arrEnterGameBindings[i].id);
			}
		}

		// Token: 0x0600B34B RID: 45899 RVA: 0x001F16FA File Offset: 0x001EFAFA
		public virtual void OnEnterSystem()
		{
		}

		// Token: 0x0600B34C RID: 45900 RVA: 0x001F16FC File Offset: 0x001EFAFC
		public virtual void OnExitSystem()
		{
		}

		// Token: 0x0600B34D RID: 45901 RVA: 0x001F16FE File Offset: 0x001EFAFE
		public virtual void OnApplicationQuit()
		{
		}

		// Token: 0x0600B34E RID: 45902 RVA: 0x001F1700 File Offset: 0x001EFB00
		public virtual void OnApplicationStart()
		{
		}

		// Token: 0x0600B34F RID: 45903 RVA: 0x001F1704 File Offset: 0x001EFB04
		private void _SetupEnterGameData(WaitNetMessageManager.NetMessages a_msgEvent)
		{
			for (int i = 0; i < this.m_arrEnterGameBindings.Count; i++)
			{
				EnterGameBinding enterGameBinding = this.m_arrEnterGameBindings[i];
				List<MsgDATA> messageDatas = a_msgEvent.GetMessageDatas(enterGameBinding.id);
				if (messageDatas != null)
				{
					Action<MsgDATA> method = enterGameBinding.method;
					if (method != null)
					{
						for (int j = 0; j < messageDatas.Count; j++)
						{
							method(messageDatas[j]);
						}
					}
				}
				else
				{
					Logger.LogErrorFormat("{2}根据网络数据初始化，找不到消息{0}(ID:{1})的网络数据！！", new object[]
					{
						Singleton<ProtocolHelper>.instance.GetName(enterGameBinding.id),
						enterGameBinding.id,
						typeof(T).Name
					});
				}
			}
		}

		// Token: 0x0600B350 RID: 45904 RVA: 0x001F17CB File Offset: 0x001EFBCB
		public virtual void OnBindEnterGameMsg()
		{
		}

		// Token: 0x0600B351 RID: 45905 RVA: 0x001F17CD File Offset: 0x001EFBCD
		private void _InitEnterGameBind()
		{
			if (this.m_bBindInited)
			{
				return;
			}
			this.OnBindEnterGameMsg();
			this.m_bBindInited = true;
		}

		// Token: 0x04006507 RID: 25863
		private static T ms_instance;

		// Token: 0x04006508 RID: 25864
		private static bool ms_bCreated;

		// Token: 0x04006509 RID: 25865
		protected List<EnterGameBinding> m_arrEnterGameBindings = new List<EnterGameBinding>();

		// Token: 0x0400650A RID: 25866
		protected bool m_bBindInited;
	}
}
