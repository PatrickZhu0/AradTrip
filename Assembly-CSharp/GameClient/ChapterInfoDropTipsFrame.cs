using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200152E RID: 5422
	public sealed class ChapterInfoDropTipsFrame : ClientFrame
	{
		// Token: 0x0600D326 RID: 54054 RVA: 0x00344E68 File Offset: 0x00343268
		public static void ShowTips(List<int[]> items)
		{
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterInfoDropTipsFrame>(null))
			{
				ChapterInfoDropTipsFrame chapterInfoDropTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ChapterInfoDropTipsFrame>(FrameLayer.Middle, null, string.Empty) as ChapterInfoDropTipsFrame;
				chapterInfoDropTipsFrame._setItems(items);
			}
		}

		// Token: 0x0600D327 RID: 54055 RVA: 0x00344EA3 File Offset: 0x003432A3
		private void _setItems(List<int[]> items)
		{
			this.mItems = items;
			this._addUnit();
		}

		// Token: 0x0600D328 RID: 54056 RVA: 0x00344EB4 File Offset: 0x003432B4
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mRoot = this.mBind.GetGameObject("root");
		}

		// Token: 0x0600D329 RID: 54057 RVA: 0x00344F09 File Offset: 0x00343309
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mRoot = null;
		}

		// Token: 0x0600D32A RID: 54058 RVA: 0x00344F35 File Offset: 0x00343335
		private void _onCloseButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600D32B RID: 54059 RVA: 0x00344F40 File Offset: 0x00343340
		private void _addUnit()
		{
			this._clearCache();
			for (int i = 0; i < this.mItems.Count; i++)
			{
				GameObject gameObject = new GameObject("line");
				Utility.AttachTo(gameObject, this.mRoot, false);
				HorizontalLayoutGroup horizontalLayoutGroup = gameObject.AddComponent<HorizontalLayoutGroup>();
				horizontalLayoutGroup.spacing = 60f;
				horizontalLayoutGroup.childForceExpandWidth = false;
				horizontalLayoutGroup.childForceExpandHeight = false;
				ComChapterInfoDrop comChapterInfoDrop = gameObject.AddComponent<ComChapterInfoDrop>();
				comChapterInfoDrop.SetDropList(new List<int>(this.mItems[i]), -1);
				this.mCache.Add(gameObject);
			}
		}

		// Token: 0x0600D32C RID: 54060 RVA: 0x00344FD2 File Offset: 0x003433D2
		private void _clearCache()
		{
			this.mCache.Clear();
		}

		// Token: 0x0600D32D RID: 54061 RVA: 0x00344FDF File Offset: 0x003433DF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDropTips";
		}

		// Token: 0x0600D32E RID: 54062 RVA: 0x00344FE6 File Offset: 0x003433E6
		protected override void _OnOpenFrame()
		{
			this._addUnit();
		}

		// Token: 0x0600D32F RID: 54063 RVA: 0x00344FEE File Offset: 0x003433EE
		protected override void _OnCloseFrame()
		{
			this._clearCache();
			this.mItems.Clear();
		}

		// Token: 0x0600D330 RID: 54064 RVA: 0x00345001 File Offset: 0x00343401
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ChapterInfoDropTipsFrame>(this, false);
		}

		// Token: 0x04007B92 RID: 31634
		private Button mClose;

		// Token: 0x04007B93 RID: 31635
		private GameObject mRoot;

		// Token: 0x04007B94 RID: 31636
		private List<int[]> mItems = new List<int[]>();

		// Token: 0x04007B95 RID: 31637
		private List<GameObject> mCache = new List<GameObject>();
	}
}
