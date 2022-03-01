using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C3 RID: 4291
	public class DungeonCommonFailFrame : ClientFrame, IDungeonFinish
	{
		// Token: 0x0600A238 RID: 41528 RVA: 0x00211E36 File Offset: 0x00210236
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonCommonFailFinish";
		}

		// Token: 0x0600A239 RID: 41529 RVA: 0x00211E40 File Offset: 0x00210240
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mComItems = this.mBind.GetCom<ComItemList>("ComItems");
			this.mExpBar = this.mBind.GetCom<ComExpBar>("ExpBar");
			this.mExpValue = this.mBind.GetCom<Text>("ExpValue");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.tip = this.mBind.GetGameObject("tip");
			this.t = this.mBind.GetGameObject("t");
			this.b = this.mBind.GetGameObject("b");
			this.finalTestContainer = this.mBind.GetGameObject("finalTest");
			this.boss01Info = this.mBind.GetCom<FailBossInfo>("HPBar_BOSS_NEW01");
			this.boss02Info = this.mBind.GetCom<FailBossInfo>("HPBar_BOSS_NEW02");
		}

		// Token: 0x0600A23A RID: 41530 RVA: 0x00211F5C File Offset: 0x0021035C
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mComItems = null;
			this.mExpBar = null;
			this.mExpValue = null;
			this.mName = null;
			this.tip = null;
		}

		// Token: 0x0600A23B RID: 41531 RVA: 0x00211FAF File Offset: 0x002103AF
		private void _onCloseButtonClick()
		{
			this._onBack();
		}

		// Token: 0x0600A23C RID: 41532 RVA: 0x00211FB7 File Offset: 0x002103B7
		protected override void _OnOpenFrame()
		{
			this._setExp(DataManager<PlayerBaseData>.GetInstance().Exp, true);
			this.SetTip();
			this.SetBossInfo();
		}

		// Token: 0x0600A23D RID: 41533 RVA: 0x00211FD6 File Offset: 0x002103D6
		private void SetTip()
		{
			if (BattleMain.battleType == BattleType.FinalTestBattle)
			{
				this.tip.CustomActive(true);
			}
		}

		// Token: 0x0600A23E RID: 41534 RVA: 0x00211FF0 File Offset: 0x002103F0
		private void _setExp(ulong val, bool force)
		{
			if (this.mExpBar != null)
			{
				this.mExpBar.SetExp(val, force, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			}
		}

		// Token: 0x0600A23F RID: 41535 RVA: 0x00212030 File Offset: 0x00210430
		private void SetBossInfo()
		{
			FinalTestBattle finalTestBattle = BattleMain.instance.GetBattle() as FinalTestBattle;
			if (this.t == null || this.b == null || this.finalTestContainer == null)
			{
				return;
			}
			if (finalTestBattle != null)
			{
				this.t.CustomActive(false);
				this.b.CustomActive(false);
				this.finalTestContainer.CustomActive(true);
				this.boss01Info.gameObject.CustomActive(finalTestBattle.bossInfo01 != null);
				this.boss02Info.gameObject.CustomActive(finalTestBattle.bossInfo02 != null);
				if (finalTestBattle.bossInfo01 != null && this.boss01Info)
				{
					this.boss01Info.SetBossInfo(finalTestBattle.bossInfo01);
				}
				if (finalTestBattle.bossInfo02 != null && this.boss02Info)
				{
					this.boss02Info.SetBossInfo(finalTestBattle.bossInfo02);
				}
			}
			else
			{
				this.finalTestContainer.CustomActive(false);
				this.t.CustomActive(true);
				this.b.CustomActive(true);
			}
		}

		// Token: 0x0600A240 RID: 41536 RVA: 0x00212164 File Offset: 0x00210564
		public void SetName(string name)
		{
			this.mName.text = name;
		}

		// Token: 0x0600A241 RID: 41537 RVA: 0x00212172 File Offset: 0x00210572
		public void SetBestTime(int time)
		{
		}

		// Token: 0x0600A242 RID: 41538 RVA: 0x00212174 File Offset: 0x00210574
		public void SetCurrentTime(int time)
		{
		}

		// Token: 0x0600A243 RID: 41539 RVA: 0x00212176 File Offset: 0x00210576
		public void SetDrops(ComItemList.Items[] items)
		{
		}

		// Token: 0x0600A244 RID: 41540 RVA: 0x00212178 File Offset: 0x00210578
		public void SetExp(ulong exp)
		{
			if (this.mExpValue != null)
			{
				this.mExpValue.text = exp.ToString();
			}
			this._setExp(DataManager<PlayerBaseData>.GetInstance().Exp + exp, false);
		}

		// Token: 0x0600A245 RID: 41541 RVA: 0x002121B6 File Offset: 0x002105B6
		public void SetDiff(int diff)
		{
		}

		// Token: 0x0600A246 RID: 41542 RVA: 0x002121B8 File Offset: 0x002105B8
		public void SetFinish(bool isFinish)
		{
		}

		// Token: 0x0600A247 RID: 41543 RVA: 0x002121BA File Offset: 0x002105BA
		public void SetLevel(int level)
		{
		}

		// Token: 0x0600A248 RID: 41544 RVA: 0x002121BC File Offset: 0x002105BC
		private void _onBack()
		{
			this.frameMgr.CloseFrame<DungeonCommonFailFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04005A63 RID: 23139
		private Button mClose;

		// Token: 0x04005A64 RID: 23140
		private ComItemList mComItems;

		// Token: 0x04005A65 RID: 23141
		private ComExpBar mExpBar;

		// Token: 0x04005A66 RID: 23142
		private Text mExpValue;

		// Token: 0x04005A67 RID: 23143
		private Text mName;

		// Token: 0x04005A68 RID: 23144
		private GameObject tip;

		// Token: 0x04005A69 RID: 23145
		private GameObject finalTestContainer;

		// Token: 0x04005A6A RID: 23146
		private FailBossInfo boss01Info;

		// Token: 0x04005A6B RID: 23147
		private FailBossInfo boss02Info;

		// Token: 0x04005A6C RID: 23148
		private GameObject t;

		// Token: 0x04005A6D RID: 23149
		private GameObject b;
	}
}
