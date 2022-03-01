using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001117 RID: 4375
	public class ChijiSettlementFrame : ClientFrame
	{
		// Token: 0x0600A5F5 RID: 42485 RVA: 0x00226226 File Offset: 0x00224626
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiSettlementFrame";
		}

		// Token: 0x0600A5F6 RID: 42486 RVA: 0x00226230 File Offset: 0x00224630
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

		// Token: 0x0600A5F7 RID: 42487 RVA: 0x0022626D File Offset: 0x0022466D
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this._ClearData();
			this._unBindUIEvent();
		}

		// Token: 0x0600A5F8 RID: 42488 RVA: 0x00226281 File Offset: 0x00224681
		private void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600A5F9 RID: 42489 RVA: 0x0022629E File Offset: 0x0022469E
		private void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
		}

		// Token: 0x0600A5FA RID: 42490 RVA: 0x002262BC File Offset: 0x002246BC
		private void _OnCounterChanged(UIEvent ui)
		{
			SettlementInfo settlementinfo = DataManager<ChijiDataManager>.GetInstance().Settlementinfo;
			if (settlementinfo != null)
			{
				this.InitInterface(settlementinfo);
			}
		}

		// Token: 0x0600A5FB RID: 42491 RVA: 0x002262E1 File Offset: 0x002246E1
		private void _ClearData()
		{
			this.bAutoQuitChiji = false;
			this.AutoQuitChijiTime = 0f;
		}

		// Token: 0x0600A5FC RID: 42492 RVA: 0x002262F8 File Offset: 0x002246F8
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

		// Token: 0x0600A5FD RID: 42493 RVA: 0x00226479 File Offset: 0x00224879
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A5FE RID: 42494 RVA: 0x0022647C File Offset: 0x0022487C
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

		// Token: 0x0600A5FF RID: 42495 RVA: 0x002264B4 File Offset: 0x002248B4
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

		// Token: 0x0600A600 RID: 42496 RVA: 0x002265CC File Offset: 0x002249CC
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

		// Token: 0x0600A601 RID: 42497 RVA: 0x0022664C File Offset: 0x00224A4C
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
					this.frameMgr.CloseFrame<ChijiSettlementFrame>(this, false);
				}
				else
				{
					this.frameMgr.CloseFrame<ChijiSettlementFrame>(this, false);
				}
			}
			else
			{
				this.frameMgr.CloseFrame<ChijiSettlementFrame>(this, false);
			}
		}

		// Token: 0x04005CC5 RID: 23749
		private bool bAutoQuitChiji;

		// Token: 0x04005CC6 RID: 23750
		private float AutoQuitChijiTime;

		// Token: 0x04005CC7 RID: 23751
		private Text mRank;

		// Token: 0x04005CC8 RID: 23752
		private Text mTotalRank;

		// Token: 0x04005CC9 RID: 23753
		private Text mKillHeroCount;

		// Token: 0x04005CCA RID: 23754
		private Text mSurvivalTime;

		// Token: 0x04005CCB RID: 23755
		private Text mIntegralCount;

		// Token: 0x04005CCC RID: 23756
		private Image mWinOrFail;

		// Token: 0x04005CCD RID: 23757
		private Button mBtClose;

		// Token: 0x04005CCE RID: 23758
		private Text mName;

		// Token: 0x04005CCF RID: 23759
		private Text mGloryCount;

		// Token: 0x04005CD0 RID: 23760
		private Text mTotalGloryCount;
	}
}
