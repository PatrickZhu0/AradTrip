using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200152C RID: 5420
	public class ChapterDrugSettingFrame : ClientFrame
	{
		// Token: 0x0600D312 RID: 54034 RVA: 0x003447F8 File Offset: 0x00342BF8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterDrugSettingFrame";
		}

		// Token: 0x0600D313 RID: 54035 RVA: 0x00344800 File Offset: 0x00342C00
		protected override void _bindExUI()
		{
			this.mTitleText = this.mBind.GetCom<Text>("TitleText");
			this.mBuffDrugInfo = this.mBind.GetCom<ComChapterInfoDrug>("BuffDrugInfo");
			this.mSubmitButton = this.mBind.GetCom<Button>("SubmitButton");
			this.mSubmitButton.onClick.AddListener(new UnityAction(this._onSubmitButtonClick));
			this.mSubmitUIGray = this.mBind.GetCom<UIGray>("SubmitUIGray");
		}

		// Token: 0x0600D314 RID: 54036 RVA: 0x00344881 File Offset: 0x00342C81
		protected override void _unbindExUI()
		{
			this.mTitleText = null;
			this.mBuffDrugInfo = null;
			this.mSubmitButton.onClick.RemoveListener(new UnityAction(this._onSubmitButtonClick));
			this.mSubmitUIGray = null;
		}

		// Token: 0x0600D315 RID: 54037 RVA: 0x003448B4 File Offset: 0x00342CB4
		protected override void _OnLoadPrefabFinish()
		{
			this._loadData();
		}

		// Token: 0x0600D316 RID: 54038 RVA: 0x003448BC File Offset: 0x00342CBC
		protected override void _OnOpenFrame()
		{
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this.mDungeonTable.BuffDrugConfig);
			if (null != this.mBuffDrugInfo)
			{
				this.mBuffDrugInfo.SetBuffDrugs(this.mDungeonTable.BuffDrugConfig);
			}
		}

		// Token: 0x0600D317 RID: 54039 RVA: 0x003448FA File Offset: 0x00342CFA
		protected override void _OnCloseFrame()
		{
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this.mDungeonTable.BuffDrugConfig);
		}

		// Token: 0x0600D318 RID: 54040 RVA: 0x0034491B File Offset: 0x00342D1B
		protected override void _OnUpdate(float delta)
		{
		}

		// Token: 0x0600D319 RID: 54041 RVA: 0x00344920 File Offset: 0x00342D20
		private void _onSubmitButtonClick()
		{
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllLocalMarkedBuffDrugs(this.mDungeonTable.BuffDrugConfig);
			DataManager<ChapterBuffDrugManager>.GetInstance().SetMarkedBuffDrugsAtLocal();
			DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(true);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BuffDrugSettingSubmit, null, null, null, null);
			base.Close(false);
		}

		// Token: 0x0600D31A RID: 54042 RVA: 0x00344974 File Offset: 0x00342D74
		protected virtual void _loadData()
		{
			int dungeonID = (int)this.userData;
			this.mDungeonID.dungeonID = dungeonID;
			this.mDungeonTable = this._getDungeonTable<DungeonTable>(this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D31B RID: 54043 RVA: 0x003449B0 File Offset: 0x00342DB0
		protected T _getDungeonTable<T>(int id)
		{
			T tableItem = Singleton<TableManager>.instance.GetTableItem<T>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem;
			}
			return default(T);
		}

		// Token: 0x04007B85 RID: 31621
		private Text mTitleText;

		// Token: 0x04007B86 RID: 31622
		private ComChapterInfoDrug mBuffDrugInfo;

		// Token: 0x04007B87 RID: 31623
		private Button mSubmitButton;

		// Token: 0x04007B88 RID: 31624
		private UIGray mSubmitUIGray;

		// Token: 0x04007B89 RID: 31625
		protected DungeonTable mDungeonTable;

		// Token: 0x04007B8A RID: 31626
		protected DungeonID mDungeonID = new DungeonID(0);
	}
}
