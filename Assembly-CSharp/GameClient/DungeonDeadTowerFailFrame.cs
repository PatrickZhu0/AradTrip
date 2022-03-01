using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C5 RID: 4293
	public class DungeonDeadTowerFailFrame : ClientFrame, IDungeonFinish
	{
		// Token: 0x0600A24C RID: 41548 RVA: 0x002121F5 File Offset: 0x002105F5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonDeadTowerFail";
		}

		// Token: 0x0600A24D RID: 41549 RVA: 0x002121FC File Offset: 0x002105FC
		protected override void _bindExUI()
		{
			this.mLevel = this.mBind.GetCom<Text>("level");
			this.mBack = this.mBind.GetCom<Button>("back");
			this.mBack.onClick.AddListener(new UnityAction(this._onBackButtonClick));
			this.mOnUplvlSkill = this.mBind.GetCom<Button>("onUplvlSkill");
			this.mOnUplvlSkill.onClick.AddListener(new UnityAction(this._onOnUplvlSkillButtonClick));
			this.mOnStrenghEquip = this.mBind.GetCom<Button>("onStrenghEquip");
			this.mOnStrenghEquip.onClick.AddListener(new UnityAction(this._onOnStrenghEquipButtonClick));
			this.mOnGetEquip = this.mBind.GetCom<Button>("onGetEquip");
			this.mOnGetEquip.onClick.AddListener(new UnityAction(this._onOnGetEquipButtonClick));
			this.mOnSummonHelp = this.mBind.GetCom<Button>("onSummonHelp");
			this.mOnSummonHelp.onClick.AddListener(new UnityAction(this._onOnSummonHelpButtonClick));
		}

		// Token: 0x0600A24E RID: 41550 RVA: 0x0021231C File Offset: 0x0021071C
		protected override void _unbindExUI()
		{
			this.mLevel = null;
			this.mBack.onClick.RemoveListener(new UnityAction(this._onBackButtonClick));
			this.mBack = null;
			this.mOnUplvlSkill.onClick.RemoveListener(new UnityAction(this._onOnUplvlSkillButtonClick));
			this.mOnUplvlSkill = null;
			this.mOnStrenghEquip.onClick.RemoveListener(new UnityAction(this._onOnStrenghEquipButtonClick));
			this.mOnStrenghEquip = null;
			this.mOnGetEquip.onClick.RemoveListener(new UnityAction(this._onOnGetEquipButtonClick));
			this.mOnGetEquip = null;
			this.mOnSummonHelp.onClick.RemoveListener(new UnityAction(this._onOnSummonHelpButtonClick));
			this.mOnSummonHelp = null;
		}

		// Token: 0x0600A24F RID: 41551 RVA: 0x002123DF File Offset: 0x002107DF
		private void _onBackButtonClick()
		{
			this._onBack();
		}

		// Token: 0x0600A250 RID: 41552 RVA: 0x002123E7 File Offset: 0x002107E7
		private void _onOnUplvlSkillButtonClick()
		{
			Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(SkillTreeFrame), null));
			this._onBack();
		}

		// Token: 0x0600A251 RID: 41553 RVA: 0x00212409 File Offset: 0x00210809
		private void _onOnStrenghEquipButtonClick()
		{
			Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(SmithShopNewFrame), null));
			this._onBack();
		}

		// Token: 0x0600A252 RID: 41554 RVA: 0x0021242B File Offset: 0x0021082B
		private void _onOnGetEquipButtonClick()
		{
			Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(PocketJarFrame), null));
			this._onBack();
		}

		// Token: 0x0600A253 RID: 41555 RVA: 0x0021244D File Offset: 0x0021084D
		private void _onOnSummonHelpButtonClick()
		{
			this._onBack();
		}

		// Token: 0x0600A254 RID: 41556 RVA: 0x00212455 File Offset: 0x00210855
		public void SetLevel(int level)
		{
			if (null != this.mLevel)
			{
				this.mLevel.text = string.Format("{0}", level);
			}
		}

		// Token: 0x0600A255 RID: 41557 RVA: 0x00212483 File Offset: 0x00210883
		public void SetName(string name)
		{
		}

		// Token: 0x0600A256 RID: 41558 RVA: 0x00212485 File Offset: 0x00210885
		public void SetBestTime(int time)
		{
		}

		// Token: 0x0600A257 RID: 41559 RVA: 0x00212487 File Offset: 0x00210887
		public void SetCurrentTime(int time)
		{
		}

		// Token: 0x0600A258 RID: 41560 RVA: 0x00212489 File Offset: 0x00210889
		public void SetDrops(ComItemList.Items[] items)
		{
		}

		// Token: 0x0600A259 RID: 41561 RVA: 0x0021248B File Offset: 0x0021088B
		public void SetExp(ulong exp)
		{
		}

		// Token: 0x0600A25A RID: 41562 RVA: 0x0021248D File Offset: 0x0021088D
		public void SetDiff(int diff)
		{
		}

		// Token: 0x0600A25B RID: 41563 RVA: 0x0021248F File Offset: 0x0021088F
		public void SetFinish(bool isFinish)
		{
		}

		// Token: 0x0600A25C RID: 41564 RVA: 0x00212491 File Offset: 0x00210891
		private void _onBack()
		{
			this.frameMgr.CloseFrame<DungeonDeadTowerFailFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04005A74 RID: 23156
		private Text mLevel;

		// Token: 0x04005A75 RID: 23157
		private Button mBack;

		// Token: 0x04005A76 RID: 23158
		private Button mOnUplvlSkill;

		// Token: 0x04005A77 RID: 23159
		private Button mOnStrenghEquip;

		// Token: 0x04005A78 RID: 23160
		private Button mOnGetEquip;

		// Token: 0x04005A79 RID: 23161
		private Button mOnSummonHelp;
	}
}
