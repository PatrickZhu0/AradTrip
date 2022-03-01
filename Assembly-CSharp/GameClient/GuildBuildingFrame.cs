using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015FC RID: 5628
	internal class GuildBuildingFrame : ClientFrame
	{
		// Token: 0x0600DC91 RID: 56465 RVA: 0x0037BABF File Offset: 0x00379EBF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBuilding";
		}

		// Token: 0x0600DC92 RID: 56466 RVA: 0x0037BAC6 File Offset: 0x00379EC6
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.m_currBuildingType = (GuildBuildingType)this.userData;
			}
			this._InitTabs();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DC93 RID: 56467 RVA: 0x0037BAF0 File Offset: 0x00379EF0
		protected override void _OnCloseFrame()
		{
			for (int i = 0; i < this.m_arrBuildingInfos.Length; i++)
			{
				if (this.m_arrBuildingInfos[i].eBuildType == this.m_currBuildingType)
				{
					this.frameMgr.CloseFrameByType(this.m_arrBuildingInfos[i].frameType, false);
				}
			}
			this.m_currBuildingType = GuildBuildingType.MAIN;
			this.m_bToggleBlockSignal = false;
			for (int j = 0; j < this.m_arrBuildingInfos.Length; j++)
			{
				this.m_arrBuildingInfos[j].toggle = null;
				this.m_arrBuildingInfos[j].objRedPoint = null;
			}
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC94 RID: 56468 RVA: 0x0037BB90 File Offset: 0x00379F90
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildCloseMainFrame, new ClientEventSystem.UIEventHandler(this._OnCloseMainFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0600DC95 RID: 56469 RVA: 0x0037BBEC File Offset: 0x00379FEC
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildCloseMainFrame, new ClientEventSystem.UIEventHandler(this._OnCloseMainFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0600DC96 RID: 56470 RVA: 0x0037BC48 File Offset: 0x0037A048
		private void _InitTabs()
		{
			this.m_bToggleBlockSignal = true;
			for (int i = 0; i < this.m_arrBuildingInfos.Length; i++)
			{
				GuildBuildingFrame.BuildingInfo info = this.m_arrBuildingInfos[i];
				GameObject objRoot = this.m_objContentRoot;
				string text = "TabGroup/Tabs/" + info.strPath;
				info.toggle = Utility.GetComponetInChild<Toggle>(this.frame, text);
				info.toggle.onValueChanged.RemoveAllListeners();
				info.toggle.onValueChanged.AddListener(delegate(bool a_bChecked)
				{
					if (!this.m_bToggleBlockSignal)
					{
						if (a_bChecked)
						{
							this.m_currBuildingType = info.eBuildType;
							this.frameMgr.OpenFrame(info.frameType, objRoot, null, string.Empty, FrameLayer.Invalid);
						}
						else
						{
							this.frameMgr.CloseFrameByType(info.frameType, false);
						}
					}
				});
				info.objRedPoint = Utility.FindGameObject(this.frame, text + "/RedPoint", true);
				info.objRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(info.eRedPointType));
			}
			for (int j = 0; j < this.m_arrBuildingInfos.Length; j++)
			{
				GuildBuildingFrame.BuildingInfo buildingInfo = this.m_arrBuildingInfos[j];
				if (buildingInfo.eBuildType == this.m_currBuildingType)
				{
					buildingInfo.toggle.isOn = false;
				}
				else
				{
					buildingInfo.toggle.isOn = true;
				}
			}
			this.m_bToggleBlockSignal = false;
			GuildBuildingFrame.BuildingInfo buildingInfo2 = this._GetBuildingInfo(this.m_currBuildingType);
			if (buildingInfo2 != null)
			{
				buildingInfo2.toggle.isOn = true;
			}
		}

		// Token: 0x0600DC97 RID: 56471 RVA: 0x0037BDC4 File Offset: 0x0037A1C4
		private GuildBuildingFrame.BuildingInfo _GetBuildingInfo(GuildBuildingType a_type)
		{
			for (int i = 0; i < this.m_arrBuildingInfos.Length; i++)
			{
				if (this.m_arrBuildingInfos[i].eBuildType == a_type)
				{
					return this.m_arrBuildingInfos[i];
				}
			}
			return null;
		}

		// Token: 0x0600DC98 RID: 56472 RVA: 0x0037BE08 File Offset: 0x0037A208
		private void _CloseAll()
		{
			for (int i = 0; i < this.m_arrBuildingInfos.Length; i++)
			{
				GuildBuildingFrame.BuildingInfo buildingInfo = this.m_arrBuildingInfos[i];
				this.frameMgr.CloseFrameByType(buildingInfo.frameType, false);
			}
			this.frameMgr.CloseFrame<GuildBuildingFrame>(this, false);
		}

		// Token: 0x0600DC99 RID: 56473 RVA: 0x0037BE56 File Offset: 0x0037A256
		private void _OnCloseMainFrame(UIEvent a_event)
		{
			this._CloseAll();
		}

		// Token: 0x0600DC9A RID: 56474 RVA: 0x0037BE5E File Offset: 0x0037A25E
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this._CloseAll();
		}

		// Token: 0x0600DC9B RID: 56475 RVA: 0x0037BE68 File Offset: 0x0037A268
		private void _OnRedPointChanged(UIEvent a_event)
		{
			for (int i = 0; i < this.m_arrBuildingInfos.Length; i++)
			{
				GuildBuildingFrame.BuildingInfo buildingInfo = this.m_arrBuildingInfos[i];
				buildingInfo.objRedPoint.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(buildingInfo.eRedPointType));
			}
		}

		// Token: 0x0400821F RID: 33311
		[UIObject("TabGroup/Page")]
		private GameObject m_objContentRoot;

		// Token: 0x04008220 RID: 33312
		private GuildBuildingFrame.BuildingInfo[] m_arrBuildingInfos = new GuildBuildingFrame.BuildingInfo[]
		{
			new GuildBuildingFrame.BuildingInfo
			{
				eBuildType = GuildBuildingType.MAIN,
				strPath = "MainCity",
				eRedPointType = ERedPoint.GuildMainCity,
				frameType = typeof(GuildMainCityFrame)
			}
		};

		// Token: 0x04008221 RID: 33313
		private const string m_strPath = "TabGroup/Tabs/";

		// Token: 0x04008222 RID: 33314
		private GuildBuildingType m_currBuildingType;

		// Token: 0x04008223 RID: 33315
		private bool m_bToggleBlockSignal;

		// Token: 0x020015FD RID: 5629
		private class BuildingInfo
		{
			// Token: 0x04008224 RID: 33316
			public GuildBuildingType eBuildType;

			// Token: 0x04008225 RID: 33317
			public string strPath;

			// Token: 0x04008226 RID: 33318
			public ERedPoint eRedPointType;

			// Token: 0x04008227 RID: 33319
			public Type frameType;

			// Token: 0x04008228 RID: 33320
			public Toggle toggle;

			// Token: 0x04008229 RID: 33321
			public GameObject objRedPoint;

			// Token: 0x0400822A RID: 33322
			public Text labLevel;
		}
	}
}
