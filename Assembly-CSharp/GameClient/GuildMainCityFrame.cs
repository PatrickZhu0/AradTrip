using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001629 RID: 5673
	internal class GuildMainCityFrame : ClientFrame
	{
		// Token: 0x0600DEC5 RID: 57029 RVA: 0x0038C3D9 File Offset: 0x0038A7D9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMainCity";
		}

		// Token: 0x0600DEC6 RID: 57030 RVA: 0x0038C3E0 File Offset: 0x0038A7E0
		protected override void _OnOpenFrame()
		{
			this._UpdateBuildings();
			this._UpdateRedPoint();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DEC7 RID: 57031 RVA: 0x0038C3F4 File Offset: 0x0038A7F4
		protected override void _OnCloseFrame()
		{
			this.m_arrBuildingInfos.Clear();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DEC8 RID: 57032 RVA: 0x0038C408 File Offset: 0x0038A808
		protected override void _bindExUI()
		{
			this.buildingRedPoint = this.mBind.GetGameObject("buildingRedPoint");
			this.honourRedPoint = this.mBind.GetGameObject("honourRedPoint");
			this.bossDiffSetRedPoint = this.mBind.GetGameObject("bossDiffSetRedPoint");
		}

		// Token: 0x0600DEC9 RID: 57033 RVA: 0x0038C457 File Offset: 0x0038A857
		protected override void _unbindExUI()
		{
			this.buildingRedPoint = null;
			this.honourRedPoint = null;
			this.bossDiffSetRedPoint = null;
		}

		// Token: 0x0600DECA RID: 57034 RVA: 0x0038C46E File Offset: 0x0038A86E
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnUpgradeBuildingSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0600DECB RID: 57035 RVA: 0x0038C4A3 File Offset: 0x0038A8A3
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildUpgradeBuildingSuccess, new ClientEventSystem.UIEventHandler(this._OnUpgradeBuildingSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0600DECC RID: 57036 RVA: 0x0038C4D8 File Offset: 0x0038A8D8
		private void _UpdateRedPoint()
		{
			this.buildingRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildBuildingManager));
			this.honourRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildEmblem));
			this.bossDiffSetRedPoint.CustomActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.GuildSetBossDiff));
		}

		// Token: 0x0600DECD RID: 57037 RVA: 0x0038C52A File Offset: 0x0038A92A
		private void _OnRedPointChanged(UIEvent a_event)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0600DECE RID: 57038 RVA: 0x0038C534 File Offset: 0x0038A934
		private void _UpdateBuildings()
		{
			this.m_arrBuildingInfos.Clear();
			Dictionary<GuildBuildingType, GameObject> dictionary = new Dictionary<GuildBuildingType, GameObject>();
			dictionary.Add(GuildBuildingType.MAIN, Utility.FindGameObject(this.frame, "ScrollView/Viewport/Content/MainCity", true));
			dictionary.Add(GuildBuildingType.SHOP, Utility.FindGameObject(this.frame, "ScrollView/Viewport/Content/Shop", true));
			dictionary.Add(GuildBuildingType.HONOUR, Utility.FindGameObject(this.frame, "ScrollView/Viewport/Content/Honour", true));
			dictionary.Add(GuildBuildingType.FETE, Utility.FindGameObject(this.frame, "ScrollView/Viewport/Content/Fete", true));
			Dictionary<GuildBuildingType, UnityAction> btnCallBack = new Dictionary<GuildBuildingType, UnityAction>();
			if (btnCallBack != null)
			{
				btnCallBack[GuildBuildingType.MAIN] = delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBuildingManagerFrame>(FrameLayer.Middle, null, string.Empty);
					if (this.buildingRedPoint.activeSelf)
					{
						DataManager<GuildDataManager>.GetInstance().checkedLvUpBulilding = true;
					}
					this.buildingRedPoint.CustomActive(false);
				};
				btnCallBack[GuildBuildingType.SHOP] = delegate()
				{
					int nLevel = DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings[GuildBuildingType.SHOP].nLevel;
					GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(nLevel, string.Empty, string.Empty);
					if (tableItem != null)
					{
						DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(tableItem.ShopId, 0, 0, -1);
					}
				};
				btnCallBack[GuildBuildingType.HONOUR] = delegate()
				{
					if (DataManager<GuildDataManager>.GetInstance().GetGuildLv() < DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit() || (int)DataManager<PlayerBaseData>.GetInstance().Level < DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit())
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("emblem_unlock_condition", DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit(), DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit()), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildEmblemUpFrame>(FrameLayer.Middle, null, string.Empty);
					if (this.honourRedPoint.activeSelf)
					{
						DataManager<GuildDataManager>.GetInstance().checkedLvUpEmblem = true;
					}
					this.honourRedPoint.CustomActive(false);
				};
				btnCallBack[GuildBuildingType.FETE] = delegate()
				{
					if (DataManager<GuildDataManager>.GetInstance().GetGuildLv() < GuildDataManager.GetGuildDungeonActivityGuildLvLimit())
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_build_boss_lv_set_condition", GuildDataManager.GetGuildDungeonActivityGuildLvLimit()), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonBossDiffSetFrame>(FrameLayer.Middle, null, string.Empty);
					if (this.bossDiffSetRedPoint.activeSelf)
					{
						DataManager<GuildDataManager>.GetInstance().checkedSetBossDiff = true;
					}
					this.bossDiffSetRedPoint.CustomActive(false);
				};
			}
			Dictionary<GuildBuildingType, GuildMainCityFrame.CheckBuildingIsUnLock> dictionary2 = new Dictionary<GuildBuildingType, GuildMainCityFrame.CheckBuildingIsUnLock>();
			if (dictionary2 != null)
			{
				dictionary2[GuildBuildingType.HONOUR] = (() => DataManager<GuildDataManager>.GetInstance().GetGuildLv() >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit() && (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit());
				dictionary2[GuildBuildingType.FETE] = (() => DataManager<GuildDataManager>.GetInstance().GetGuildLv() >= GuildDataManager.GetGuildDungeonActivityGuildLvLimit());
			}
			if (DataManager<GuildDataManager>.GetInstance().myGuild != null && DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings != null)
			{
				Dictionary<GuildBuildingType, GuildBuildingData>.Enumerator enumerator = DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Dictionary<GuildBuildingType, GameObject> dictionary3 = dictionary;
					KeyValuePair<GuildBuildingType, GuildBuildingData> keyValuePair = enumerator.Current;
					if (dictionary3.ContainsKey(keyValuePair.Key))
					{
						GuildMainCityFrame.GuildBuildingInfo info = new GuildMainCityFrame.GuildBuildingInfo();
						GuildMainCityFrame.GuildBuildingInfo info2 = info;
						KeyValuePair<GuildBuildingType, GuildBuildingData> keyValuePair2 = enumerator.Current;
						info2.data = keyValuePair2.Value;
						GameObject gameObject = dictionary[info.data.eType];
						gameObject.CustomActive(true);
						info.labLevel = Utility.GetComponetInChild<Text>(gameObject, "Level");
						Button componetInChild = Utility.GetComponetInChild<Button>(gameObject, "LevelUp");
						componetInChild.onClick.RemoveAllListeners();
						componetInChild.onClick.AddListener(delegate()
						{
							if (btnCallBack != null)
							{
								btnCallBack[info.data.eType].Invoke();
							}
						});
						UIGray uigray = gameObject.SafeAddComponent(false);
						if (uigray != null)
						{
							uigray.bEnabled2Text = false;
							uigray.enabled = false;
							uigray.enabled = (DataManager<GuildDataManager>.GetInstance().GetGuildLv() < DataManager<GuildDataManager>.GetInstance().GetUnLockBuildingNeedMainCityLv(info.data.eType));
						}
						if (dictionary2 != null && dictionary2.ContainsKey(info.data.eType))
						{
							componetInChild.SafeSetGray(!dictionary2[info.data.eType](), true);
						}
						this.m_arrBuildingInfos.Add(info);
					}
				}
			}
			for (int i = 0; i < this.m_arrBuildingInfos.Count; i++)
			{
				GuildBuildingData data = this.m_arrBuildingInfos[i].data;
				GuildMainCityFrame.GuildBuildingInfo guildBuildingInfo = this.m_arrBuildingInfos[i];
				int num = data.nLevel;
				int num2 = data.nMaxLevel;
				if (num2 <= 0)
				{
					num = 1;
					num2 = 1;
				}
				guildBuildingInfo.labLevel.text = string.Format("Lv.{0}", num);
				guildBuildingInfo.labLevel.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildLv() >= DataManager<GuildDataManager>.GetInstance().GetUnLockBuildingNeedMainCityLv(guildBuildingInfo.data.eType));
				if (num >= num2)
				{
					if (data.nUnlockMaincityLevel > 0)
					{
					}
				}
				if (!DataManager<GuildDataManager>.GetInstance().HasPermission(EGuildPermission.UpgradeBuilding, EGuildDuty.Invalid))
				{
				}
			}
		}

		// Token: 0x0600DECF RID: 57039 RVA: 0x0038C93C File Offset: 0x0038AD3C
		private void _OnUpgradeBuildingSuccess(UIEvent a_event)
		{
			this._UpdateBuildings();
			this._UpdateRedPoint();
		}

		// Token: 0x0600DED0 RID: 57040 RVA: 0x0038C94C File Offset: 0x0038AD4C
		private void _SetObjsActive(List<GameObject> a_arrObjs, bool a_bActive)
		{
			for (int i = 0; i < a_arrObjs.Count; i++)
			{
				a_arrObjs[i].SetActive(a_bActive);
			}
		}

		// Token: 0x04008428 RID: 33832
		private List<GuildMainCityFrame.GuildBuildingInfo> m_arrBuildingInfos = new List<GuildMainCityFrame.GuildBuildingInfo>();

		// Token: 0x04008429 RID: 33833
		private GameObject buildingRedPoint;

		// Token: 0x0400842A RID: 33834
		private GameObject honourRedPoint;

		// Token: 0x0400842B RID: 33835
		private GameObject bossDiffSetRedPoint;

		// Token: 0x0200162A RID: 5674
		private class GuildBuildingInfo
		{
			// Token: 0x0400842F RID: 33839
			public GuildBuildingData data;

			// Token: 0x04008430 RID: 33840
			public Text labLevel;

			// Token: 0x04008431 RID: 33841
			public Text labCostCount;

			// Token: 0x04008432 RID: 33842
			public ComButtonEnbale comLevelupEnable;

			// Token: 0x04008433 RID: 33843
			public List<GameObject> arrObjLevelup = new List<GameObject>();

			// Token: 0x04008434 RID: 33844
			public List<GameObject> arrObjMax = new List<GameObject>();

			// Token: 0x04008435 RID: 33845
			public Text labMax;
		}

		// Token: 0x0200162B RID: 5675
		// (Invoke) Token: 0x0600DED6 RID: 57046
		private delegate bool CheckBuildingIsUnLock();
	}
}
