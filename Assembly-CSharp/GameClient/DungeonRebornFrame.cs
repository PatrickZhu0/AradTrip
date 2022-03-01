using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010B1 RID: 4273
	public class DungeonRebornFrame : ClientFrame
	{
		// Token: 0x0600A123 RID: 41251 RVA: 0x0020A558 File Offset: 0x00208958
		protected override void _bindExUI()
		{
			this.m_countScirpt = this.mBind.GetCom<ComCountScript>("_countScirpt");
			this.m_dianji = this.mBind.GetCom<Image>("_dianji");
			this.m_viptips = this.mBind.GetCom<Text>("_viptips");
			this.mLeftCoinCount = this.mBind.GetCom<Text>("LeftCoinCount");
			this.mRebornRoot = this.mBind.GetGameObject("RebornRoot");
			this.mDungeonReborn = this.mBind.GetGameObject("DungeonReborn");
			this.mLeftRebornCoinCount = this.mBind.GetCom<Text>("LeftRebornCoinCount");
			this.mLeftRebornCount = this.mBind.GetCom<Text>("LeftRebornCount");
			this.mLeftCountRoot = this.mBind.GetGameObject("LeftCountRoot");
			this.mCannotRebornRoot = this.mBind.GetGameObject("CannotRebornRoot");
			this.mGiveupRebornRoot = this.mBind.GetCom<RectTransform>("GiveupRebornRoot");
			this.mGiveupRebornBtn = this.mBind.GetCom<Button>("GiveupRebornBtn");
			if (null != this.mGiveupRebornBtn)
			{
				this.mGiveupRebornBtn.onClick.AddListener(new UnityAction(this._onGiveupRebornBtnButtonClick));
			}
			this.mBtnOk = this.mBind.GetCom<Button>("btnOk");
			if (null != this.mBtnOk)
			{
				this.mBtnOk.onClick.AddListener(new UnityAction(this._onBtnOkButtonClick));
			}
			this.mVipDescRoot = this.mBind.GetGameObject("vipDescRoot");
			this.mNormalDescRoot = this.mBind.GetGameObject("normalDescRoot");
			this.mVipOkButtonRoot = this.mBind.GetGameObject("vipOkButtonRoot");
			this.mNormalOkButtonRoot = this.mBind.GetGameObject("normalOkButtonRoot");
			this.mNotVipLevel = this.mBind.GetCom<Text>("notVipLevel");
			this.mNotVipCount = this.mBind.GetCom<Text>("notVipCount");
			this.mIsVipLevel = this.mBind.GetCom<Text>("isVipLevel");
			this.mIsVipLeft = this.mBind.GetCom<Text>("isVipLeft");
			this.mIsVipSum = this.mBind.GetCom<Text>("isVipSum");
			this.mBtnCancel = this.mBind.GetCom<Button>("btnCancel");
			if (null != this.mBtnCancel)
			{
				this.mBtnCancel.onClick.AddListener(new UnityAction(this._onBtnCancelButtonClick));
			}
			this.mOkButtonRoot = this.mBind.GetGameObject("okButtonRoot");
			this.mCancelButtonRoot = this.mBind.GetGameObject("cancelButtonRoot");
		}

		// Token: 0x0600A124 RID: 41252 RVA: 0x0020A814 File Offset: 0x00208C14
		protected override void _unbindExUI()
		{
			this.m_countScirpt = null;
			this.m_dianji = null;
			this.m_viptips = null;
			this.mLeftCoinCount = null;
			this.mRebornRoot = null;
			this.mDungeonReborn = null;
			this.mLeftRebornCoinCount = null;
			this.mLeftRebornCount = null;
			this.mLeftCountRoot = null;
			this.mCannotRebornRoot = null;
			this.mGiveupRebornRoot = null;
			if (null != this.mGiveupRebornBtn)
			{
				this.mGiveupRebornBtn.onClick.RemoveListener(new UnityAction(this._onGiveupRebornBtnButtonClick));
			}
			this.mGiveupRebornBtn = null;
			if (null != this.mBtnOk)
			{
				this.mBtnOk.onClick.RemoveListener(new UnityAction(this._onBtnOkButtonClick));
			}
			this.mBtnOk = null;
			this.mVipDescRoot = null;
			this.mNormalDescRoot = null;
			this.mVipOkButtonRoot = null;
			this.mNormalOkButtonRoot = null;
			this.mNotVipLevel = null;
			this.mNotVipCount = null;
			this.mIsVipLevel = null;
			this.mIsVipLeft = null;
			this.mIsVipSum = null;
			if (null != this.mBtnCancel)
			{
				this.mBtnCancel.onClick.RemoveListener(new UnityAction(this._onBtnCancelButtonClick));
			}
			this.mBtnCancel = null;
			this.mOkButtonRoot = null;
			this.mCancelButtonRoot = null;
		}

		// Token: 0x0600A125 RID: 41253 RVA: 0x0020A957 File Offset: 0x00208D57
		private void _onBtnOkButtonClick()
		{
			this._onButtonReborn();
		}

		// Token: 0x0600A126 RID: 41254 RVA: 0x0020A95F File Offset: 0x00208D5F
		private void _onBtnCancelButtonClick()
		{
			this.m_countScirpt.StopCount();
			this.frame.CustomActive(false);
		}

		// Token: 0x0600A127 RID: 41255 RVA: 0x0020A978 File Offset: 0x00208D78
		private void _onGiveupRebornBtnButtonClick()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null)
			{
				return;
			}
			if (BattleMain.instance.GetPlayerManager().GetPlayerCount() == 1)
			{
				this.m_countScirpt.RebornFail();
			}
			if (Singleton<RecordServer>.instance != null)
			{
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(this, false);
		}

		// Token: 0x0600A128 RID: 41256 RVA: 0x0020A9D5 File Offset: 0x00208DD5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Reborn/DungeonReborn";
		}

		// Token: 0x0600A129 RID: 41257 RVA: 0x0020A9DC File Offset: 0x00208DDC
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A12A RID: 41258 RVA: 0x0020A9E0 File Offset: 0x00208DE0
		protected override void _OnOpenFrame()
		{
			DungeonRebornFrame.sState = DungeonRebornFrame.eState.None;
			this._Initialize();
			this._updateCancelButtonState();
			this._TryStartCountDown();
			this._RegisterUIEvent();
			this._updateOkButtonState();
			this._updateLeftCount();
			this.UpdateDungeonRebornCount();
			if (Global.Settings.IsTestTeam())
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(2000, delegate
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DungeonRebornFrame>(null))
					{
						this._onButtonReborn();
					}
				}, 0, 0, false);
			}
			if (Singleton<RecordServer>.instance != null)
			{
			}
		}

		// Token: 0x0600A12B RID: 41259 RVA: 0x0020AA5A File Offset: 0x00208E5A
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600A12C RID: 41260 RVA: 0x0020AA62 File Offset: 0x00208E62
		private bool _hasGotVipRight()
		{
			return DungeonUtility.GetVipRebornSumCount() > 0;
		}

		// Token: 0x0600A12D RID: 41261 RVA: 0x0020AA6C File Offset: 0x00208E6C
		private bool _isVipFreeReborn()
		{
			return DungeonUtility.GetVipRebornLeftCount() > 0;
		}

		// Token: 0x0600A12E RID: 41262 RVA: 0x0020AA78 File Offset: 0x00208E78
		private void _updateLeftCount()
		{
			this.mLeftCoinCount.text = DataManager<PlayerBaseData>.GetInstance().AliveCoin.ToString();
		}

		// Token: 0x0600A12F RID: 41263 RVA: 0x0020AAA8 File Offset: 0x00208EA8
		private void UpdateDungeonRebornCount()
		{
			int localActorRebornCount = this.GetLocalActorRebornCount();
			int dungeonRebornLimit = this.GetDungeonRebornLimit();
			IBattle battle = BattleMain.instance.GetBattle();
			bool flag = true;
			if (this.IsBattleRebornLimit())
			{
				flag = (this.GetBattleLeftRebornCount() > 0);
			}
			bool flag2;
			if (flag)
			{
				if (dungeonRebornLimit < 0)
				{
					return;
				}
				flag2 = (localActorRebornCount >= dungeonRebornLimit);
			}
			else
			{
				flag2 = true;
			}
			this.mCancelButtonRoot.CustomActive(false);
			if (flag2)
			{
				this.mCannotRebornRoot.CustomActive(true);
				this.mDungeonReborn.CustomActive(false);
				this.mRebornRoot.CustomActive(false);
				this.mOkButtonRoot.CustomActive(false);
				this.mVipDescRoot.CustomActive(false);
				this.mGiveupRebornRoot.gameObject.CustomActive(true);
			}
			else
			{
				this.mCannotRebornRoot.CustomActive(false);
				this.mGiveupRebornRoot.gameObject.CustomActive(false);
				this.mRebornRoot.CustomActive(false);
				this.mDungeonReborn.CustomActive(true);
				this.mLeftRebornCoinCount.text = DataManager<PlayerBaseData>.GetInstance().AliveCoin.ToString();
				this.mLeftRebornCount.text = string.Format(TR.Value("chapter_revive_tips"), dungeonRebornLimit - localActorRebornCount);
			}
		}

		// Token: 0x0600A130 RID: 41264 RVA: 0x0020ABE7 File Offset: 0x00208FE7
		private void _updateOkButtonState()
		{
			this.mOkButtonRoot.SetActive(this._canReborn());
		}

		// Token: 0x0600A131 RID: 41265 RVA: 0x0020ABFA File Offset: 0x00208FFA
		private void _updateCancelButtonState()
		{
			if (!this.CheckRebornCount())
			{
				return;
			}
			this.mCancelButtonRoot.SetActive(!BattleMain.instance.GetPlayerManager().IsAllPlayerDead());
		}

		// Token: 0x0600A132 RID: 41266 RVA: 0x0020AC28 File Offset: 0x00209028
		private void _Initialize()
		{
			this.m_countScirpt.StopCount();
			this.mVipDescRoot.SetActive(false);
			this.mVipOkButtonRoot.SetActive(false);
			this.mNormalDescRoot.SetActive(false);
			this.mNormalOkButtonRoot.SetActive(false);
			if (this._hasGotVipRight())
			{
				this.mVipDescRoot.SetActive(true);
				this.mIsVipLevel.text = DataManager<PlayerBaseData>.GetInstance().VipLevel.ToString();
				this.mIsVipLeft.text = DungeonUtility.GetVipRebornLeftCount().ToString();
				this.mIsVipSum.text = DungeonUtility.GetVipRebornSumCount().ToString();
			}
			else
			{
				KeyValuePair<int, float> firstValidVipLevelPrivilegeData = Utility.GetFirstValidVipLevelPrivilegeData(VipPrivilegeTable.eType.FREE_REVIVE);
				if (firstValidVipLevelPrivilegeData.Value > 0f)
				{
					this.mNormalDescRoot.SetActive(true);
					this.mNotVipLevel.text = firstValidVipLevelPrivilegeData.Key.ToString();
					this.mNotVipCount.text = ((int)firstValidVipLevelPrivilegeData.Value).ToString();
				}
			}
			if (this._isVipFreeReborn())
			{
				this.mVipOkButtonRoot.SetActive(true);
			}
			else
			{
				this.mNormalOkButtonRoot.SetActive(true);
			}
		}

		// Token: 0x0600A133 RID: 41267 RVA: 0x0020AD78 File Offset: 0x00209178
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattlePlayerDead, new ClientEventSystem.UIEventHandler(this._OnBattlePlayerDead));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRebornFail, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonFinishRebornFail, new ClientEventSystem.UIEventHandler(this._onDungeonFinishRebornFail));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._OnRebornCountAdd));
		}

		// Token: 0x0600A134 RID: 41268 RVA: 0x0020AE0C File Offset: 0x0020920C
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattlePlayerDead, new ClientEventSystem.UIEventHandler(this._OnBattlePlayerDead));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRebornFail, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onBattlePlayerRebornSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonFinishRebornFail, new ClientEventSystem.UIEventHandler(this._onDungeonFinishRebornFail));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._OnRebornCountAdd));
		}

		// Token: 0x0600A135 RID: 41269 RVA: 0x0020AEA0 File Offset: 0x002092A0
		private void _OnRebornCountAdd(UIEvent ui)
		{
			this._Initialize();
			this._updateCancelButtonState();
			this._TryStartCountDown();
			this._updateOkButtonState();
			this._updateLeftCount();
			this.UpdateDungeonRebornCount();
		}

		// Token: 0x0600A136 RID: 41270 RVA: 0x0020AEC6 File Offset: 0x002092C6
		private void _OnBattlePlayerDead(UIEvent uiEvent)
		{
			this._updateCancelButtonState();
			this._TryStartCountDown();
		}

		// Token: 0x0600A137 RID: 41271 RVA: 0x0020AED4 File Offset: 0x002092D4
		private void _onBattlePlayerRebornSuccess(UIEvent ui)
		{
			byte b = (byte)ui.Param1;
			this.m_countScirpt.StopCount();
			byte seat = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerInfo.seat;
			DungeonRebornFrame.sState = DungeonRebornFrame.eState.Reborn;
			if (b == seat)
			{
				if (Singleton<RecordServer>.instance != null)
				{
				}
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRebornFrame>(this, false);
			}
			else
			{
				this._updateCancelButtonState();
			}
		}

		// Token: 0x0600A138 RID: 41272 RVA: 0x0020AF40 File Offset: 0x00209340
		private void _onDungeonFinishRebornFail(UIEvent ui)
		{
			DungeonRebornFrame.sState = DungeonRebornFrame.eState.Cancel;
		}

		// Token: 0x0600A139 RID: 41273 RVA: 0x0020AF48 File Offset: 0x00209348
		private void _onBattlePlayerRebornFail(UIEvent ui)
		{
			if (!this.CheckRebornCount())
			{
				return;
			}
			byte b = (byte)ui.Param1;
			this.m_countScirpt.ResumeCount();
		}

		// Token: 0x0600A13A RID: 41274 RVA: 0x0020AF78 File Offset: 0x00209378
		private void _TryStartCountDown()
		{
			if (this.m_countScirpt.State == ComCountScript.CountState.Count)
			{
				return;
			}
			if (BattleMain.instance.GetPlayerManager().IsAllPlayerDead())
			{
				this.frame.CustomActive(true);
				this.m_countScirpt.StartCount(delegate
				{
					this._BackToTown();
				}, 9);
			}
		}

		// Token: 0x0600A13B RID: 41275 RVA: 0x0020AFD0 File Offset: 0x002093D0
		private void _BackToTown()
		{
			DungeonRebornFrame.sState = DungeonRebornFrame.eState.Cancel;
		}

		// Token: 0x0600A13C RID: 41276 RVA: 0x0020AFD8 File Offset: 0x002093D8
		private bool _canReborn()
		{
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			IBattle battle = BattleMain.instance.GetBattle();
			return (battle == null || battle.CanReborn()) && DungeonUtility.CanReborn(dungeonID, true);
		}

		// Token: 0x0600A13D RID: 41277 RVA: 0x0020B024 File Offset: 0x00209424
		private void _onButtonReborn()
		{
			if (this._canReborn())
			{
				if (this.m_countScirpt == null)
				{
					return;
				}
				int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
				byte seat = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerInfo.seat;
				DungeonUtility.eDungeonRebornType dungeonRebornType = DungeonUtility.GetDungeonRebornType(dungeonID, true);
				if (dungeonRebornType != DungeonUtility.eDungeonRebornType.QuickBuyReborn)
				{
					this.m_countScirpt.PauseCount();
				}
				DungeonUtility.StartRebornProcess(seat, seat, dungeonID);
				if (Singleton<RecordServer>.instance != null)
				{
				}
			}
			else
			{
				SystemNotifyManager.SystemNotify(1098, string.Empty);
			}
		}

		// Token: 0x0600A13E RID: 41278 RVA: 0x0020B0C4 File Offset: 0x002094C4
		protected bool CheckRebornCount()
		{
			int localActorRebornCount = this.GetLocalActorRebornCount();
			int dungeonRebornLimit = this.GetDungeonRebornLimit();
			return localActorRebornCount < dungeonRebornLimit;
		}

		// Token: 0x0600A13F RID: 41279 RVA: 0x0020B0E4 File Offset: 0x002094E4
		protected int GetLocalActorRebornCount()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null || BattleMain.instance.GetPlayerManager().GetMainPlayer() == null)
			{
				return 0;
			}
			BeActor playerActor = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
			if (playerActor == null)
			{
				return 0;
			}
			return playerActor.dungeonRebornCount;
		}

		// Token: 0x0600A140 RID: 41280 RVA: 0x0020B144 File Offset: 0x00209544
		protected int GetDungeonRebornLimit()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetDungeonManager() == null || BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
			{
				return 0;
			}
			int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			return DungeonUtility.GetDungeonRebornCount(dungeonID);
		}

		// Token: 0x0600A141 RID: 41281 RVA: 0x0020B1A0 File Offset: 0x002095A0
		protected bool IsBattleRebornLimit()
		{
			return BattleMain.instance != null && BattleMain.instance.GetBattle() != null && BattleMain.instance.GetBattle().IsRebornCountLimit();
		}

		// Token: 0x0600A142 RID: 41282 RVA: 0x0020B1CC File Offset: 0x002095CC
		protected int GetBattleLeftRebornCount()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetBattle() == null)
			{
				return 0;
			}
			IBattle battle = BattleMain.instance.GetBattle();
			if (!battle.IsRebornCountLimit())
			{
				return 0;
			}
			return battle.GetLeftRebornCount();
		}

		// Token: 0x040059A1 RID: 22945
		private ComCountScript m_countScirpt;

		// Token: 0x040059A2 RID: 22946
		private Image m_dianji;

		// Token: 0x040059A3 RID: 22947
		private Text m_viptips;

		// Token: 0x040059A4 RID: 22948
		private Text mLeftCoinCount;

		// Token: 0x040059A5 RID: 22949
		private GameObject mRebornRoot;

		// Token: 0x040059A6 RID: 22950
		private GameObject mDungeonReborn;

		// Token: 0x040059A7 RID: 22951
		private Text mLeftRebornCoinCount;

		// Token: 0x040059A8 RID: 22952
		private Text mLeftRebornCount;

		// Token: 0x040059A9 RID: 22953
		private GameObject mLeftCountRoot;

		// Token: 0x040059AA RID: 22954
		private GameObject mCannotRebornRoot;

		// Token: 0x040059AB RID: 22955
		private RectTransform mGiveupRebornRoot;

		// Token: 0x040059AC RID: 22956
		private Button mGiveupRebornBtn;

		// Token: 0x040059AD RID: 22957
		private Button mBtnOk;

		// Token: 0x040059AE RID: 22958
		private GameObject mVipDescRoot;

		// Token: 0x040059AF RID: 22959
		private GameObject mNormalDescRoot;

		// Token: 0x040059B0 RID: 22960
		private GameObject mVipOkButtonRoot;

		// Token: 0x040059B1 RID: 22961
		private GameObject mNormalOkButtonRoot;

		// Token: 0x040059B2 RID: 22962
		private Text mNotVipLevel;

		// Token: 0x040059B3 RID: 22963
		private Text mNotVipCount;

		// Token: 0x040059B4 RID: 22964
		private Text mIsVipLevel;

		// Token: 0x040059B5 RID: 22965
		private Text mIsVipLeft;

		// Token: 0x040059B6 RID: 22966
		private Text mIsVipSum;

		// Token: 0x040059B7 RID: 22967
		private Button mBtnCancel;

		// Token: 0x040059B8 RID: 22968
		private GameObject mOkButtonRoot;

		// Token: 0x040059B9 RID: 22969
		private GameObject mCancelButtonRoot;

		// Token: 0x040059BA RID: 22970
		public static bool isLocal;

		// Token: 0x040059BB RID: 22971
		private const int COUNT_TIME = 9;

		// Token: 0x040059BC RID: 22972
		public static DungeonRebornFrame.eState sState;

		// Token: 0x020010B2 RID: 4274
		public enum eState
		{
			// Token: 0x040059BE RID: 22974
			None,
			// Token: 0x040059BF RID: 22975
			Reborn,
			// Token: 0x040059C0 RID: 22976
			Cancel,
			// Token: 0x040059C1 RID: 22977
			NoWay
		}
	}
}
