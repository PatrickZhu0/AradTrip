using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010D5 RID: 4309
	public class PauseFrame : ClientFrame
	{
		// Token: 0x0600A30C RID: 41740 RVA: 0x00215804 File Offset: 0x00213C04
		public override string GetPrefabPath()
		{
			if (!this.IsDrugVisible())
			{
				return "UIFlatten/Prefabs/Battle/Pause/DungeonPauseCommon";
			}
			return (DataManager<PlayerBaseData>.GetInstance().VipLevel <= 0) ? "UIFlatten/Prefabs/Battle/Pause/DungeonPause" : "UIFlatten/Prefabs/Battle/Pause/DungeonPauseVIP";
		}

		// Token: 0x0600A30D RID: 41741 RVA: 0x00215838 File Offset: 0x00213C38
		private bool IsDrugVisible()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			return clientSystemBattle != null && clientSystemBattle.IsDrugVisible();
		}

		// Token: 0x0600A30E RID: 41742 RVA: 0x00215863 File Offset: 0x00213C63
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A30F RID: 41743 RVA: 0x00215868 File Offset: 0x00213C68
		protected override void _bindExUI()
		{
			this.mCancel = this.mBind.GetCom<Button>("cancel");
			this.mCancel.onClick.AddListener(new UnityAction(this._onCancelButtonClick));
			this.mOk = this.mBind.GetCom<Button>("ok");
			this.mOk.onClick.AddListener(new UnityAction(this._onOkButtonClick));
			this.mTitle = this.mBind.GetCom<Button>("title");
			this.mTitle.onClick.AddListener(new UnityAction(this._onTitleButtonClick));
			this.reporter = this.mBind.GetCom<Button>("reporter");
			this.node = this.mBind.GetGameObject("node");
			this.tip = this.mBind.GetGameObject("tip");
			this.info = this.mBind.GetCom<Text>("info");
		}

		// Token: 0x0600A310 RID: 41744 RVA: 0x00215964 File Offset: 0x00213D64
		protected override void _unbindExUI()
		{
			this.mCancel.onClick.RemoveListener(new UnityAction(this._onCancelButtonClick));
			this.mCancel = null;
			this.mOk.onClick.RemoveListener(new UnityAction(this._onOkButtonClick));
			this.mOk = null;
			this.mTitle.onClick.RemoveListener(new UnityAction(this._onTitleButtonClick));
			this.mTitle = null;
			this.tip = null;
			this.info = null;
			this.reporter = null;
		}

		// Token: 0x0600A311 RID: 41745 RVA: 0x002159EF File Offset: 0x00213DEF
		private void _onCancelButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x0600A312 RID: 41746 RVA: 0x002159F7 File Offset: 0x00213DF7
		private void _onReporterButtonClick()
		{
		}

		// Token: 0x0600A313 RID: 41747 RVA: 0x002159F9 File Offset: 0x00213DF9
		private void _onOkButtonClick()
		{
			this.OnClickBack();
		}

		// Token: 0x0600A314 RID: 41748 RVA: 0x00215A01 File Offset: 0x00213E01
		private void _onTitleButtonClick()
		{
			this._onHandle();
		}

		// Token: 0x0600A315 RID: 41749 RVA: 0x00215A0C File Offset: 0x00213E0C
		private void _onHandle()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (!Global.Settings.isDebug)
			{
				return;
			}
			BattleType battleType = BattleMain.battleType;
			switch (battleType)
			{
			case BattleType.Single:
			case BattleType.Dungeon:
			case BattleType.DeadTown:
			case BattleType.Mou:
			case BattleType.North:
			case BattleType.Hell:
			case BattleType.YuanGu:
			case BattleType.ChampionMatch:
			case BattleType.GuildPVE:
				break;
			default:
				if (battleType != BattleType.FinalTestBattle)
				{
				}
				break;
			}
		}

		// Token: 0x0600A316 RID: 41750 RVA: 0x00215A9C File Offset: 0x00213E9C
		protected override void _OnOpenFrame()
		{
			if (this.reporter != null)
			{
				this.reporter.gameObject.CustomActive(false);
			}
			if (this.node != null)
			{
				this.battlePotionSet = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/SettingPanel/BattlePotionSet", true, 0U);
				Utility.AttachTo(this.battlePotionSet, this.node, false);
				if (DataManager<PlayerBaseData>.GetInstance().VipLevel > 0)
				{
					this.vipsetting = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/SettingPanel/VipSetting", true, 0U);
					Utility.AttachTo(this.vipsetting, this.node, false);
					this.vipsetting.transform.localPosition = new Vector3(75f, -440f, 0f);
				}
			}
			this.SetTip();
		}

		// Token: 0x0600A317 RID: 41751 RVA: 0x00215B68 File Offset: 0x00213F68
		private void SetTip()
		{
			if (BattleMain.battleType == BattleType.FinalTestBattle)
			{
				this.tip.CustomActive(true);
			}
		}

		// Token: 0x0600A318 RID: 41752 RVA: 0x00215B82 File Offset: 0x00213F82
		protected override void _OnCloseFrame()
		{
			if (this.battlePotionSet != null)
			{
				Object.Destroy(this.battlePotionSet);
			}
			if (this.vipsetting != null)
			{
				Object.Destroy(this.vipsetting);
			}
			base._OnCloseFrame();
		}

		// Token: 0x0600A319 RID: 41753 RVA: 0x00215BC2 File Offset: 0x00213FC2
		public void OnClickClose()
		{
			if (!BattleMain.IsModeMultiplayer(BattleMain.mode))
			{
				BattleMain.instance.GetDungeonManager().ResumeFight(true, string.Empty, false);
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<PauseFrame>(null, false);
		}

		// Token: 0x0600A31A RID: 41754 RVA: 0x00215BF8 File Offset: 0x00213FF8
		public void OnClickBack()
		{
			DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList = true;
			if (this.NeedPromotLeave())
			{
				if (BeUtility.CheckDungeonIsLimitTimeHell())
				{
					SystemNotifyManager.SystemNotify(9974, delegate()
					{
						this.DoBack();
					});
					return;
				}
				if (this.IsInDifferentWorld())
				{
					SystemNotifyManager.SystemNotify(9935, delegate()
					{
						this.DoBack();
					});
				}
				else
				{
					SystemNotifyManager.SystemNotify(3125, delegate()
					{
						this.DoBack();
					});
				}
			}
			else
			{
				this.DoBack();
			}
		}

		// Token: 0x0600A31B RID: 41755 RVA: 0x00215C84 File Offset: 0x00214084
		private bool NeedPromotLeave()
		{
			DungeonTable table = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table;
			return table != null && null != Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)table.SubType, string.Empty, string.Empty);
		}

		// Token: 0x0600A31C RID: 41756 RVA: 0x00215CD0 File Offset: 0x002140D0
		private bool IsInDifferentWorld()
		{
			DungeonTable table = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().table;
			return table.SubType == DungeonTable.eSubType.S_DEVILDDOM;
		}

		// Token: 0x0600A31D RID: 41757 RVA: 0x00215D04 File Offset: 0x00214104
		private void DoBack()
		{
			this.SaveBattleResult();
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("DoBack");
			}
			BeUtility.ResetCamera();
			Singleton<NewbieGuideManager>.instance.CleanWeakGuide();
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x0600A31E RID: 41758 RVA: 0x00215D54 File Offset: 0x00214154
		private void SaveBattleResult()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
			if (baseBattle == null)
			{
				return;
			}
			baseBattle.PveBattleResult = BattleResult.Success;
		}

		// Token: 0x04005AE6 RID: 23270
		private Button mCancel;

		// Token: 0x04005AE7 RID: 23271
		private Button mOk;

		// Token: 0x04005AE8 RID: 23272
		private Button mTitle;

		// Token: 0x04005AE9 RID: 23273
		private Button reporter;

		// Token: 0x04005AEA RID: 23274
		private GameObject node;

		// Token: 0x04005AEB RID: 23275
		private GameObject tip;

		// Token: 0x04005AEC RID: 23276
		private Text info;

		// Token: 0x04005AED RID: 23277
		private GameObject battlePotionSet;

		// Token: 0x04005AEE RID: 23278
		private GameObject vipsetting;
	}
}
