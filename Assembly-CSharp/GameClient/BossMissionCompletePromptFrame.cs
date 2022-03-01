using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017A7 RID: 6055
	public class BossMissionCompletePromptFrame : ClientFrame
	{
		// Token: 0x0600EEC4 RID: 61124 RVA: 0x00401C80 File Offset: 0x00400080
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/CompletePromptFrame";
		}

		// Token: 0x0600EEC5 RID: 61125 RVA: 0x00401C88 File Offset: 0x00400088
		protected override void _OnOpenFrame()
		{
			InvokeMethod.Invoke(this, 3f, delegate()
			{
				this.frameMgr.CloseFrame<BossMissionCompletePromptFrame>(this, false);
			});
			this.iDungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			this.UpdateBossIcon();
			this.BindUIEvent();
		}

		// Token: 0x0600EEC6 RID: 61126 RVA: 0x00401CD7 File Offset: 0x004000D7
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RemoveInvokeCall(this);
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BossMissionCompleteFrameClose, null, null, null, null);
		}

		// Token: 0x0600EEC7 RID: 61127 RVA: 0x00401CF8 File Offset: 0x004000F8
		protected override void _bindExUI()
		{
			this.mBackground = this.mBind.GetCom<Image>("Background");
			this.mCharactorIcon = this.mBind.GetCom<Image>("CharactorIcon");
		}

		// Token: 0x0600EEC8 RID: 61128 RVA: 0x00401D26 File Offset: 0x00400126
		protected override void _unbindExUI()
		{
			this.mBackground = null;
			this.mCharactorIcon = null;
		}

		// Token: 0x0600EEC9 RID: 61129 RVA: 0x00401D36 File Offset: 0x00400136
		private void BindUIEvent()
		{
		}

		// Token: 0x0600EECA RID: 61130 RVA: 0x00401D38 File Offset: 0x00400138
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600EECB RID: 61131 RVA: 0x00401D3A File Offset: 0x0040013A
		public void SetBackgroud(string spritePath)
		{
			if (this.mBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.mBackground, spritePath, true);
			}
		}

		// Token: 0x0600EECC RID: 61132 RVA: 0x00401D5C File Offset: 0x0040015C
		public void SetCharactorSprite(string spritePath)
		{
			if (this.mCharactorIcon == null)
			{
				return;
			}
			if (spritePath == null || spritePath.Length <= 0)
			{
				this.mCharactorIcon.sprite = null;
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.mCharactorIcon, spritePath, true);
			}
			RectTransform rectTransform = this.mCharactorIcon.rectTransform;
			float y = rectTransform.sizeDelta.y;
			this.mCharactorIcon.SetNativeSize();
			this.mCharactorIcon.CustomActive(null != this.mCharactorIcon.sprite);
			float y2 = rectTransform.sizeDelta.y;
			rectTransform.sizeDelta *= y / y2;
			rectTransform.localScale = Vector3.one;
		}

		// Token: 0x0600EECD RID: 61133 RVA: 0x00401E20 File Offset: 0x00400220
		private T _getDungeonTable<T>(int id)
		{
			T tableItem = Singleton<TableManager>.instance.GetTableItem<T>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem;
			}
			return default(T);
		}

		// Token: 0x0600EECE RID: 61134 RVA: 0x00401E5C File Offset: 0x0040025C
		private void UpdateBossIcon()
		{
			DungeonTable dungeonTable = this._getDungeonTable<DungeonTable>(BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID);
			if (dungeonTable != null)
			{
				this.SetBackgroud(dungeonTable.TumbPath);
				this.SetCharactorSprite(dungeonTable.TumbChPath);
			}
		}

		// Token: 0x0400922C RID: 37420
		private int iDungeonID;

		// Token: 0x0400922D RID: 37421
		private Image mBackground;

		// Token: 0x0400922E RID: 37422
		private Image mCharactorIcon;
	}
}
