using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020017FA RID: 6138
	public class ServerSceneFuncSwitchManager : DataManager<ServerSceneFuncSwitchManager>
	{
		// Token: 0x0600F203 RID: 61955 RVA: 0x0041478C File Offset: 0x00412B8C
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ServerSceneFuncSwitchManager;
		}

		// Token: 0x0600F204 RID: 61956 RVA: 0x00414790 File Offset: 0x00412B90
		public sealed override void Initialize()
		{
			this.Clear();
			this.BindNetEvent();
		}

		// Token: 0x0600F205 RID: 61957 RVA: 0x0041479E File Offset: 0x00412B9E
		public sealed override void Clear()
		{
			this.UnBindNetEvent();
			this.mServerCloseFuncTypeList.Clear();
			this.mServerFuncSwitchListenerDic.Clear();
		}

		// Token: 0x0600F206 RID: 61958 RVA: 0x004147BC File Offset: 0x00412BBC
		[Obsolete("IsTypeFuncLock is Obsolete, Please use IsServiceTypeSwitchOpen")]
		public bool IsTypeFuncLock(ServiceType type)
		{
			return this.mServerCloseFuncTypeList != null && this.mServerCloseFuncTypeList.Contains(type);
		}

		// Token: 0x0600F207 RID: 61959 RVA: 0x004147DF File Offset: 0x00412BDF
		public bool IsServiceTypeSwitchOpen(ServiceType type)
		{
			return this.mServerCloseFuncTypeList == null || !this.mServerCloseFuncTypeList.Contains(type);
		}

		// Token: 0x0600F208 RID: 61960 RVA: 0x00414804 File Offset: 0x00412C04
		public void AddServerFuncSwitchListener(ServiceType type, ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler handler)
		{
			if (this.mServerFuncSwitchListenerDic == null)
			{
				return;
			}
			if (!this.mServerFuncSwitchListenerDic.ContainsKey((int)type))
			{
				this.mServerFuncSwitchListenerDic.Add((int)type, new List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler>
				{
					handler
				});
			}
			else
			{
				List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler> list = this.mServerFuncSwitchListenerDic[(int)type];
				if (list == null)
				{
					return;
				}
				if (!list.Contains(handler))
				{
					list.Add(handler);
				}
			}
		}

		// Token: 0x0600F209 RID: 61961 RVA: 0x00414878 File Offset: 0x00412C78
		public void RemoveServerFuncSwitchListener(ServiceType type, ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler handler)
		{
			if (this.mServerFuncSwitchListenerDic == null)
			{
				return;
			}
			if (this.mServerFuncSwitchListenerDic.ContainsKey((int)type))
			{
				List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler> list = this.mServerFuncSwitchListenerDic[(int)type];
				if (list == null)
				{
					return;
				}
				if (list.Contains(handler))
				{
					list.Remove(handler);
				}
			}
		}

		// Token: 0x0600F20A RID: 61962 RVA: 0x004148CC File Offset: 0x00412CCC
		private void RemoveAllServerFuncSwitchListener()
		{
			if (this.mServerFuncSwitchListenerDic == null)
			{
				return;
			}
			this.mServerFuncSwitchListenerDic.Clear();
		}

		// Token: 0x0600F20B RID: 61963 RVA: 0x004148E5 File Offset: 0x00412CE5
		private void BindNetEvent()
		{
			NetProcess.AddMsgHandler(501214U, new Action<MsgDATA>(this.OnSceneSyncServiceSwitch));
			NetProcess.AddMsgHandler(501215U, new Action<MsgDATA>(this.OnSceneUpdateServiceSwitch));
		}

		// Token: 0x0600F20C RID: 61964 RVA: 0x00414913 File Offset: 0x00412D13
		private void UnBindNetEvent()
		{
			NetProcess.RemoveMsgHandler(501214U, new Action<MsgDATA>(this.OnSceneSyncServiceSwitch));
			NetProcess.RemoveMsgHandler(501215U, new Action<MsgDATA>(this.OnSceneUpdateServiceSwitch));
		}

		// Token: 0x0600F20D RID: 61965 RVA: 0x00414944 File Offset: 0x00412D44
		private void OnSceneSyncServiceSwitch(MsgDATA data)
		{
			SceneSyncServiceSwitch sceneSyncServiceSwitch = new SceneSyncServiceSwitch();
			sceneSyncServiceSwitch.decode(data.bytes);
			ushort[] closedServices = sceneSyncServiceSwitch.closedServices;
			if (closedServices == null)
			{
				return;
			}
			for (int i = 0; i < closedServices.Length; i++)
			{
				if (Enum.IsDefined(typeof(ServiceType), (int)closedServices[i]))
				{
					ServiceType item = (ServiceType)closedServices[i];
					if (!this.mServerCloseFuncTypeList.Contains(item))
					{
						this.mServerCloseFuncTypeList.Add(item);
					}
				}
			}
		}

		// Token: 0x0600F20E RID: 61966 RVA: 0x004149C8 File Offset: 0x00412DC8
		private void OnSceneUpdateServiceSwitch(MsgDATA data)
		{
			SceneUpdateServiceSwitch sceneUpdateServiceSwitch = new SceneUpdateServiceSwitch();
			sceneUpdateServiceSwitch.decode(data.bytes);
			if (!Enum.IsDefined(typeof(ServiceType), (int)sceneUpdateServiceSwitch.type))
			{
			}
			ServiceType type = (ServiceType)sceneUpdateServiceSwitch.type;
			bool flag = sceneUpdateServiceSwitch.open == 1;
			if (this.mServerCloseFuncTypeList.Contains(type) && flag)
			{
				this.mServerCloseFuncTypeList.Remove(type);
			}
			else if (!this.mServerCloseFuncTypeList.Contains(type) && !flag)
			{
				this.mServerCloseFuncTypeList.Add(type);
			}
			this.TriggerServerFuncSwitchListener(type, flag);
		}

		// Token: 0x0600F20F RID: 61967 RVA: 0x00414A78 File Offset: 0x00412E78
		private void TriggerServerFuncSwitchListener(ServiceType type, bool isOpen)
		{
			if (this.mServerFuncSwitchListenerDic == null)
			{
				return;
			}
			if (this.mServerFuncSwitchListenerDic.ContainsKey((int)type))
			{
				List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler> list = this.mServerFuncSwitchListenerDic[(int)type];
				if (list == null)
				{
					return;
				}
				for (int i = 0; i < list.Count; i++)
				{
					ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler serverSceneFuncSwitchHandler = list[i];
					if (serverSceneFuncSwitchHandler != null)
					{
						serverSceneFuncSwitchHandler(new ServerSceneFuncSwitch
						{
							sType = type,
							sIsOpen = isOpen
						});
					}
				}
			}
		}

		// Token: 0x040094BC RID: 38076
		private List<ServiceType> mServerCloseFuncTypeList = new List<ServiceType>();

		// Token: 0x040094BD RID: 38077
		private Dictionary<int, List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler>> mServerFuncSwitchListenerDic = new Dictionary<int, List<ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler>>();

		// Token: 0x020017FB RID: 6139
		// (Invoke) Token: 0x0600F211 RID: 61969
		public delegate void ServerSceneFuncSwitchHandler(ServerSceneFuncSwitch funcSwitch);
	}
}
