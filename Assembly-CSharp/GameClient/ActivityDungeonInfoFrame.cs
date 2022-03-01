using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001399 RID: 5017
	public class ActivityDungeonInfoFrame : ClientFrame
	{
		// Token: 0x0600C2E6 RID: 49894 RVA: 0x002E82C8 File Offset: 0x002E66C8
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mName = this.mBind.GetCom<Text>("name");
			this.mDrops = this.mBind.GetCom<ComChapterInfoDrop>("drops");
			this.mDesc = this.mBind.GetCom<Text>("desc");
			this.mClosebutton = this.mBind.GetCom<Button>("closebutton");
			this.mClosebutton.onClick.AddListener(new UnityAction(this._onClosebuttonButtonClick));
		}

		// Token: 0x0600C2E7 RID: 49895 RVA: 0x002E837C File Offset: 0x002E677C
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mName = null;
			this.mDrops = null;
			this.mDesc = null;
			this.mClosebutton.onClick.RemoveListener(new UnityAction(this._onClosebuttonButtonClick));
			this.mClosebutton = null;
		}

		// Token: 0x0600C2E8 RID: 49896 RVA: 0x002E83E4 File Offset: 0x002E67E4
		private void _onCloseButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600C2E9 RID: 49897 RVA: 0x002E83EC File Offset: 0x002E67EC
		private void _onClosebuttonButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600C2EA RID: 49898 RVA: 0x002E83F4 File Offset: 0x002E67F4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/Dungeon/ActvityDungeonInfoFrame";
		}

		// Token: 0x0600C2EB RID: 49899 RVA: 0x002E83FC File Offset: 0x002E67FC
		protected override void _OnOpenFrame()
		{
			int num = (int)this.userData;
			ActivityDungeonSub subByDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByDungeonID(num);
			this.mName.text = subByDungeonID.name;
			this.mDesc.text = subByDungeonID.table.PlayDescription;
			this.mDrops.SetDropList(subByDungeonID.drops, num);
		}

		// Token: 0x0600C2EC RID: 49900 RVA: 0x002E845A File Offset: 0x002E685A
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ActivityDungeonInfoFrame>(this, false);
		}

		// Token: 0x04006E53 RID: 28243
		private Button mClose;

		// Token: 0x04006E54 RID: 28244
		private Text mName;

		// Token: 0x04006E55 RID: 28245
		private ComChapterInfoDrop mDrops;

		// Token: 0x04006E56 RID: 28246
		private Text mDesc;

		// Token: 0x04006E57 RID: 28247
		private Button mClosebutton;
	}
}
