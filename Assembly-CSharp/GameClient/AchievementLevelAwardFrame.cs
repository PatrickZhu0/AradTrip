using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013C8 RID: 5064
	internal class AchievementLevelAwardFrame : ClientFrame
	{
		// Token: 0x0600C486 RID: 50310 RVA: 0x002F3322 File Offset: 0x002F1722
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActiveGroup/AchievementLevelAwardFrame";
		}

		// Token: 0x0600C487 RID: 50311 RVA: 0x002F3329 File Offset: 0x002F1729
		public static void CommandOpen(object argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AchievementLevelAwardFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600C488 RID: 50312 RVA: 0x002F3340 File Offset: 0x002F1740
		private void _LoadAllAwardItems()
		{
			if (this.mItems.Count == 0)
			{
				Dictionary<int, object>.Enumerator enumerator = Singleton<TableManager>.GetInstance().GetTable<AchievementLevelInfoTable>().GetEnumerator();
				while (enumerator.MoveNext())
				{
					List<AchievementLevelInfoTable> list = this.mItems;
					KeyValuePair<int, object> keyValuePair = enumerator.Current;
					list.Add(keyValuePair.Value as AchievementLevelInfoTable);
				}
			}
		}

		// Token: 0x0600C489 RID: 50313 RVA: 0x002F33A0 File Offset: 0x002F17A0
		private void _InitializeAwardList()
		{
			if (null != this.comAwardList)
			{
				this.comAwardList.Initialize();
				this.comAwardList.onBindItem = delegate(GameObject go)
				{
					if (null != go)
					{
						return go.GetComponent<ComAchievementAwardItem>();
					}
					return null;
				};
				this.comAwardList.onItemVisiable = delegate(ComUIListElementScript element)
				{
					if (null != element)
					{
						ComAchievementAwardItem comAchievementAwardItem = element.gameObjectBindScript as ComAchievementAwardItem;
						if (null != comAchievementAwardItem && element.m_index >= 0 && element.m_index < this.mItems.Count)
						{
							comAchievementAwardItem.OnItemVisible(this.mItems[element.m_index]);
						}
					}
				};
			}
		}

		// Token: 0x0600C48A RID: 50314 RVA: 0x002F3408 File Offset: 0x002F1808
		private void _UpdateAwardList()
		{
			if (null != this.comAwardList)
			{
				this.comAwardList.SetElementAmount(this.mItems.Count);
			}
		}

		// Token: 0x0600C48B RID: 50315 RVA: 0x002F3431 File Offset: 0x002F1831
		private void _UnInitializeAwardList()
		{
			if (null != this.comAwardList)
			{
				this.comAwardList.onBindItem = null;
				this.comAwardList.onItemVisiable = null;
				this.comAwardList = null;
			}
		}

		// Token: 0x0600C48C RID: 50316 RVA: 0x002F3464 File Offset: 0x002F1864
		protected override void _OnOpenFrame()
		{
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<AchievementLevelAwardFrame>(this, false);
			});
			this._LoadAllAwardItems();
			this._InitializeAwardList();
			this._UpdateAwardList();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementMaskPropertyChanged, new ClientEventSystem.UIEventHandler(this._OnOnAchievementMaskPropertyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
		}

		// Token: 0x0600C48D RID: 50317 RVA: 0x002F34D0 File Offset: 0x002F18D0
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementMaskPropertyChanged, new ClientEventSystem.UIEventHandler(this._OnOnAchievementMaskPropertyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementScoreChanged, new ClientEventSystem.UIEventHandler(this._OnAchievementScoreChanged));
			this._UnInitializeAwardList();
		}

		// Token: 0x0600C48E RID: 50318 RVA: 0x002F350E File Offset: 0x002F190E
		private void _OnOnAchievementMaskPropertyChanged(UIEvent uiEvent)
		{
			this._UpdateAwardList();
		}

		// Token: 0x0600C48F RID: 50319 RVA: 0x002F3516 File Offset: 0x002F1916
		private void _OnAchievementScoreChanged(UIEvent uiEvent)
		{
			this._UpdateAwardList();
		}

		// Token: 0x04006FEB RID: 28651
		[UIControl("AwardItems", typeof(ComUIListScript), 0)]
		private ComUIListScript comAwardList;

		// Token: 0x04006FEC RID: 28652
		private List<AchievementLevelInfoTable> mItems = new List<AchievementLevelInfoTable>(16);
	}
}
