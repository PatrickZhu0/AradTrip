using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001118 RID: 4376
	public class ChijiSettlementLoseFrame : ClientFrame
	{
		// Token: 0x0600A603 RID: 42499 RVA: 0x0022671E File Offset: 0x00224B1E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiSettlementLoseFrame";
		}

		// Token: 0x0600A604 RID: 42500 RVA: 0x00226728 File Offset: 0x00224B28
		protected sealed override void _OnOpenFrame()
		{
			SettlementInfo settlementinfo = DataManager<ChijiDataManager>.GetInstance().Settlementinfo;
			if (settlementinfo != null)
			{
				this.InitInterface(settlementinfo);
			}
			this.bAutoQuitChiji = true;
			this.AutoQuitChijiTime = 0f;
			this._bindUIEvent();
		}

		// Token: 0x0600A605 RID: 42501 RVA: 0x00226765 File Offset: 0x00224B65
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this._ClearData();
			this._unBindUIEvent();
		}

		// Token: 0x0600A606 RID: 42502 RVA: 0x00226779 File Offset: 0x00224B79
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600A607 RID: 42503 RVA: 0x00226796 File Offset: 0x00224B96
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600A608 RID: 42504 RVA: 0x002267B4 File Offset: 0x00224BB4
		private void _OnCounterChanged(UIEvent ui)
		{
			SettlementInfo settlementinfo = DataManager<ChijiDataManager>.GetInstance().Settlementinfo;
			if (settlementinfo != null)
			{
				this.InitInterface(settlementinfo);
			}
		}

		// Token: 0x0600A609 RID: 42505 RVA: 0x002267D9 File Offset: 0x00224BD9
		private void _ClearData()
		{
			this.bAutoQuitChiji = false;
			this.AutoQuitChijiTime = 0f;
		}

		// Token: 0x0600A60A RID: 42506 RVA: 0x002267F0 File Offset: 0x00224BF0
		private void InitInterface(SettlementInfo settlementInfo)
		{
			if (this.mName != null)
			{
				this.mName.text = DataManager<PlayerBaseData>.GetInstance().Name;
			}
			if (this.mRank != null)
			{
				this.mRank.text = settlementInfo.rank.ToString();
			}
			if (this.mTotalRank != null)
			{
				this.mTotalRank.text = settlementInfo.playerNum.ToString();
			}
			if (this.mKillHeroCount != null)
			{
				this.mKillHeroCount.text = settlementInfo.kills.ToString();
			}
			if (this.mSurvivalTime != null)
			{
				this.mSurvivalTime.text = Function.GetLastsTimeStr(settlementInfo.survivalTime);
			}
			if (this.mIntegralCount != null)
			{
				this.mIntegralCount.text = settlementInfo.score.ToString();
			}
			if (this.mGloryCount != null)
			{
				this.mGloryCount.text = settlementInfo.glory.ToString();
			}
			if (this.mTotalGloryCount != null)
			{
				this.mTotalGloryCount.text = string.Format("{0}/{1}", DataManager<ChijiDataManager>.GetInstance()._GetWeeklyTotalGlory(), DataManager<ChijiDataManager>.GetInstance()._GetWeeklyMaxPVPGlory());
			}
		}

		// Token: 0x0600A60B RID: 42507 RVA: 0x00226971 File Offset: 0x00224D71
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A60C RID: 42508 RVA: 0x00226974 File Offset: 0x00224D74
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.bAutoQuitChiji)
			{
				this.AutoQuitChijiTime += timeElapsed;
				if (this.AutoQuitChijiTime > 15f)
				{
					this.bAutoQuitChiji = false;
					this._onBtCloseButtonClick();
				}
			}
		}

		// Token: 0x0600A60D RID: 42509 RVA: 0x002269AC File Offset: 0x00224DAC
		protected sealed override void _bindExUI()
		{
			this.mRank = this.mBind.GetCom<Text>("Rank");
			this.mTotalRank = this.mBind.GetCom<Text>("TotalRank");
			this.mKillHeroCount = this.mBind.GetCom<Text>("KillHeroCount");
			this.mSurvivalTime = this.mBind.GetCom<Text>("SurvivalTime");
			this.mIntegralCount = this.mBind.GetCom<Text>("IntegralCount");
			this.mWinOrFail = this.mBind.GetCom<Image>("WinOrFail");
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mGloryCount = this.mBind.GetCom<Text>("GloryCount");
			this.mTotalGloryCount = this.mBind.GetCom<Text>("TotalGloryCount");
		}

		// Token: 0x0600A60E RID: 42510 RVA: 0x00226AC4 File Offset: 0x00224EC4
		protected sealed override void _unbindExUI()
		{
			this.mRank = null;
			this.mTotalRank = null;
			this.mKillHeroCount = null;
			this.mSurvivalTime = null;
			this.mIntegralCount = null;
			this.mWinOrFail = null;
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtClose = null;
			this.mName = null;
			this.mGloryCount = null;
			this.mTotalGloryCount = null;
		}

		// Token: 0x0600A60F RID: 42511 RVA: 0x00226B44 File Offset: 0x00224F44
		private void _onBtCloseButtonClick()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemGameBattle.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.SceneType == CitySceneTable.eSceneType.BATTLE)
					{
						MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemGameBattle._NetSyncChangeScene(new SceneParams
						{
							currSceneID = clientSystemGameBattle.CurrentSceneID,
							currDoorID = 0,
							targetSceneID = 10101,
							targetDoorID = 0
						}, false));
						DataManager<ChijiDataManager>.GetInstance().SwitchingChijiSceneToPrepare = true;
					}
					this.frameMgr.CloseFrame<ChijiSettlementLoseFrame>(this, false);
				}
				else
				{
					this.frameMgr.CloseFrame<ChijiSettlementLoseFrame>(this, false);
				}
			}
			else
			{
				this.frameMgr.CloseFrame<ChijiSettlementLoseFrame>(this, false);
			}
		}

		// Token: 0x04005CD1 RID: 23761
		private bool bAutoQuitChiji;

		// Token: 0x04005CD2 RID: 23762
		private float AutoQuitChijiTime;

		// Token: 0x04005CD3 RID: 23763
		private Text mRank;

		// Token: 0x04005CD4 RID: 23764
		private Text mTotalRank;

		// Token: 0x04005CD5 RID: 23765
		private Text mKillHeroCount;

		// Token: 0x04005CD6 RID: 23766
		private Text mSurvivalTime;

		// Token: 0x04005CD7 RID: 23767
		private Text mIntegralCount;

		// Token: 0x04005CD8 RID: 23768
		private Image mWinOrFail;

		// Token: 0x04005CD9 RID: 23769
		private Button mBtClose;

		// Token: 0x04005CDA RID: 23770
		private Text mName;

		// Token: 0x04005CDB RID: 23771
		private Text mGloryCount;

		// Token: 0x04005CDC RID: 23772
		private Text mTotalGloryCount;
	}
}
