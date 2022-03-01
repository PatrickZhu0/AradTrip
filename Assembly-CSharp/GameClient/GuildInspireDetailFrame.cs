using System;
using System.Collections.Generic;
using Network;
using Protocol;
using Scripts.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001623 RID: 5667
	internal class GuildInspireDetailFrame : ClientFrame
	{
		// Token: 0x0600DE74 RID: 56948 RVA: 0x00388CE6 File Offset: 0x003870E6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildInspireDetailFrame";
		}

		// Token: 0x0600DE75 RID: 56949 RVA: 0x00388CED File Offset: 0x003870ED
		protected override void _OnOpenFrame()
		{
			this.SendInspireListReq();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DE76 RID: 56950 RVA: 0x00388CFB File Offset: 0x003870FB
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			this.ClearData();
		}

		// Token: 0x0600DE77 RID: 56951 RVA: 0x00388D09 File Offset: 0x00387109
		private void ClearData()
		{
		}

		// Token: 0x0600DE78 RID: 56952 RVA: 0x00388D0B File Offset: 0x0038710B
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInspireInfoUpdate, new ClientEventSystem.UIEventHandler(this.UpdateInterface));
		}

		// Token: 0x0600DE79 RID: 56953 RVA: 0x00388D28 File Offset: 0x00387128
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInspireInfoUpdate, new ClientEventSystem.UIEventHandler(this.UpdateInterface));
		}

		// Token: 0x0600DE7A RID: 56954 RVA: 0x00388D48 File Offset: 0x00387148
		private void UpdateInterface(UIEvent iEvent)
		{
			List<GuildBattleInspireInfo> guildBattleInspireInfoList = DataManager<GuildDataManager>.GetInstance().GetGuildBattleInspireInfoList();
			for (int i = 0; i < guildBattleInspireInfoList.Count; i++)
			{
				GuildBattleInspireInfo guildBattleInspireInfo = guildBattleInspireInfoList[i];
				for (int j = i + 1; j < guildBattleInspireInfoList.Count; j++)
				{
					GuildBattleInspireInfo guildBattleInspireInfo2 = guildBattleInspireInfoList[j];
					if (guildBattleInspireInfoList[j].inspireNum > guildBattleInspireInfoList[i].inspireNum)
					{
						GuildBattleInspireInfo give = new GuildBattleInspireInfo();
						DataManager<GuildDataManager>.GetInstance().SetDataExchange(ref give, guildBattleInspireInfoList[i]);
						DataManager<GuildDataManager>.GetInstance().SetDataExchange(ref guildBattleInspireInfo, guildBattleInspireInfoList[j]);
						DataManager<GuildDataManager>.GetInstance().SetDataExchange(ref guildBattleInspireInfo2, give);
					}
				}
			}
			this.InitScrollListBind(guildBattleInspireInfoList);
			this.RefreshListCount();
		}

		// Token: 0x0600DE7B RID: 56955 RVA: 0x00388E08 File Offset: 0x00387208
		private void InitScrollListBind(List<GuildBattleInspireInfo> ListData)
		{
			this.mMemList.Initialize();
			this.mMemList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdateScrollListBind(item, ListData);
				}
			};
			this.mMemList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x0600DE7C RID: 56956 RVA: 0x00388E74 File Offset: 0x00387274
		private void UpdateScrollListBind(ComUIListElementScript item, List<GuildBattleInspireInfo> ListData)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= ListData.Count)
			{
				return;
			}
			Text com = component.GetCom<Text>("Name");
			Text com2 = component.GetCom<Text>("Num");
			Image com3 = component.GetCom<Image>("Back1");
			Image com4 = component.GetCom<Image>("Back2");
			com3.gameObject.CustomActive(item.m_index % 2 == 0);
			com4.gameObject.CustomActive(item.m_index % 2 == 1);
			com.text = ListData[item.m_index].playerName;
			com2.text = ListData[item.m_index].inspireNum.ToString();
		}

		// Token: 0x0600DE7D RID: 56957 RVA: 0x00388F4C File Offset: 0x0038734C
		private void RefreshListCount()
		{
			List<GuildBattleInspireInfo> guildBattleInspireInfoList = DataManager<GuildDataManager>.GetInstance().GetGuildBattleInspireInfoList();
			this.mMemList.SetElementAmount(guildBattleInspireInfoList.Count);
			int num = 0;
			for (int i = 0; i < guildBattleInspireInfoList.Count; i++)
			{
				num += (int)guildBattleInspireInfoList[i].inspireNum;
			}
			this.mTotalNum.text = num.ToString();
		}

		// Token: 0x0600DE7E RID: 56958 RVA: 0x00388FB8 File Offset: 0x003873B8
		private void SendInspireListReq()
		{
			WorldGuildBattleInspireInfoReq cmd = new WorldGuildBattleInspireInfoReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGuildBattleInspireInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600DE7F RID: 56959 RVA: 0x00388FDC File Offset: 0x003873DC
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mMemList = this.mBind.GetCom<ComUIListScript>("MemList");
			this.mTotalNum = this.mBind.GetCom<Text>("TotalNum");
		}

		// Token: 0x0600DE80 RID: 56960 RVA: 0x00389047 File Offset: 0x00387447
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mMemList = null;
			this.mTotalNum = null;
		}

		// Token: 0x0600DE81 RID: 56961 RVA: 0x0038907A File Offset: 0x0038747A
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<GuildInspireDetailFrame>(this, false);
		}

		// Token: 0x040083D3 RID: 33747
		private Button mBtClose;

		// Token: 0x040083D4 RID: 33748
		private ComUIListScript mMemList;

		// Token: 0x040083D5 RID: 33749
		private Text mTotalNum;
	}
}
