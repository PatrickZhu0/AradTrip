using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001721 RID: 5921
	internal class BossSelectBattleFrame : ClientFrame
	{
		// Token: 0x0600E898 RID: 59544 RVA: 0x003D8553 File Offset: 0x003D6953
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/BossSelectBattle";
		}

		// Token: 0x0600E899 RID: 59545 RVA: 0x003D855A File Offset: 0x003D695A
		protected override void _OnOpenFrame()
		{
			this.InitButtonState();
		}

		// Token: 0x0600E89A RID: 59546 RVA: 0x003D8564 File Offset: 0x003D6964
		private void InitButtonState()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(23, string.Empty, string.Empty);
			FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(24, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("please check FunctionUnlockTable ID :{0}", new object[]
				{
					23
				});
			}
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("please check FunctionUnlockTable ID :{0}", new object[]
				{
					24
				});
			}
			if (tableItem != null)
			{
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.FinishLevel)
				{
					this.mGoAbyss.enabled = true;
					this.mGoAbyssText.text = "前往深渊地下城";
				}
				else
				{
					this.mGoAbyss.enabled = false;
					this.mGoAbyssText.text = string.Format("前往深渊地下城（{0}级解锁）", tableItem.FinishLevel);
				}
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem2.FinishLevel)
				{
					this.mGoAncient.enabled = true;
					this.mGoAncientText.text = "前往远古地下城";
				}
				else
				{
					this.mGoAncient.enabled = false;
					this.mGoAncientText.text = string.Format("前往远古地下城（{0}级解锁）", tableItem2.FinishLevel);
				}
			}
		}

		// Token: 0x0600E89B RID: 59547 RVA: 0x003D86A9 File Offset: 0x003D6AA9
		private void TryCloseBossActivityFrame()
		{
		}

		// Token: 0x0600E89C RID: 59548 RVA: 0x003D86AB File Offset: 0x003D6AAB
		protected override void _OnCloseFrame()
		{
			this.frameMgr.CloseFrame<BossSelectBattleFrame>(this, false);
		}

		// Token: 0x0600E89D RID: 59549 RVA: 0x003D86BC File Offset: 0x003D6ABC
		protected override void _bindExUI()
		{
			this.mGoAncient = this.mBind.GetCom<Button>("GoAncient");
			this.mGoAncient.onClick.AddListener(new UnityAction(this._onGoAncientButtonClick));
			this.mGoAbyss = this.mBind.GetCom<Button>("GoAbyss");
			this.mGoAbyss.onClick.AddListener(new UnityAction(this._onGoAbyssButtonClick));
			this.mGoAbyssText = this.mBind.GetCom<Text>("GoAbyssText");
			this.mGoAncientText = this.mBind.GetCom<Text>("GoAncientText");
			this.mGoDungeon = this.mBind.GetCom<Button>("GoDungeon");
			this.mGoDungeon.onClick.AddListener(new UnityAction(this._onGoDungeonButtonClick));
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600E89E RID: 59550 RVA: 0x003D87C0 File Offset: 0x003D6BC0
		protected override void _unbindExUI()
		{
			this.mGoAncient.onClick.RemoveListener(new UnityAction(this._onGoAncientButtonClick));
			this.mGoAncient = null;
			this.mGoAbyss.onClick.RemoveListener(new UnityAction(this._onGoAbyssButtonClick));
			this.mGoAbyss = null;
			this.mGoAbyssText = null;
			this.mGoAncientText = null;
			this.mGoDungeon.onClick.RemoveListener(new UnityAction(this._onGoDungeonButtonClick));
			this.mGoDungeon = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600E89F RID: 59551 RVA: 0x003D8868 File Offset: 0x003D6C68
		private void _onGoAncientButtonClick()
		{
			ChallengeMapParamDataModel userData = new ChallengeMapParamDataModel
			{
				ModelType = DungeonModelTable.eType.AncientModel,
				BaseDungeonId = 602000
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeMapFrame>(FrameLayer.Middle, userData, string.Empty);
			this.frameMgr.CloseFrame<BossSelectBattleFrame>(this, false);
			this.TryCloseBossActivityFrame();
		}

		// Token: 0x0600E8A0 RID: 59552 RVA: 0x003D88B4 File Offset: 0x003D6CB4
		private void _onGoAbyssButtonClick()
		{
			ChallengeMapParamDataModel userData = new ChallengeMapParamDataModel
			{
				ModelType = DungeonModelTable.eType.DeepModel,
				BaseDungeonId = 701000
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeMapFrame>(FrameLayer.Middle, userData, string.Empty);
			this.frameMgr.CloseFrame<BossSelectBattleFrame>(this, false);
			this.TryCloseBossActivityFrame();
		}

		// Token: 0x0600E8A1 RID: 59553 RVA: 0x003D8900 File Offset: 0x003D6D00
		private void _onGoDungeonButtonClick()
		{
			int lastedDungeonIDByDiff = ChapterUtility.GetLastedDungeonIDByDiff(0);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			clientSystemTown.MainPlayer.CommandMoveToDungeon(lastedDungeonIDByDiff);
			this.frameMgr.CloseFrame<BossSelectBattleFrame>(this, false);
			this.TryCloseBossActivityFrame();
		}

		// Token: 0x0600E8A2 RID: 59554 RVA: 0x003D8943 File Offset: 0x003D6D43
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<BossSelectBattleFrame>(this, false);
		}

		// Token: 0x04008CFE RID: 36094
		private Button mGoAncient;

		// Token: 0x04008CFF RID: 36095
		private Button mGoAbyss;

		// Token: 0x04008D00 RID: 36096
		private Text mGoAbyssText;

		// Token: 0x04008D01 RID: 36097
		private Text mGoAncientText;

		// Token: 0x04008D02 RID: 36098
		private Button mGoDungeon;

		// Token: 0x04008D03 RID: 36099
		private Button mClose;
	}
}
