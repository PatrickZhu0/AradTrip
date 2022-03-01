using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AF8 RID: 6904
	internal class DevelopGuidanceMainFrame : ClientFrame
	{
		// Token: 0x06010F10 RID: 69392 RVA: 0x004D69DE File Offset: 0x004D4DDE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/DevelopGuidanceFrame/DevelopGuidanceMainFrame";
		}

		// Token: 0x06010F11 RID: 69393 RVA: 0x004D69E8 File Offset: 0x004D4DE8
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				int id = 0;
				if (int.TryParse(strParam, out id))
				{
					GuidanceMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceMainTable>(id, string.Empty, string.Empty);
					if (tableItem != null)
					{
						DevelopGuidanceMainFrameData developGuidanceMainFrameData = new DevelopGuidanceMainFrameData();
						developGuidanceMainFrameData.mainItem = tableItem;
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<DevelopGuidanceMainFrame>(null, false);
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<DevelopGuidanceMainFrame>(FrameLayer.Middle, developGuidanceMainFrameData, string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x06010F12 RID: 69394 RVA: 0x004D6A74 File Offset: 0x004D4E74
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as DevelopGuidanceMainFrameData);
			this.m_kComGuidanceMainItems.Initialize(this, Utility.FindChild(this.frame, "GuidanceMainItems"));
			this._InitMainItemTabs();
		}

		// Token: 0x06010F13 RID: 69395 RVA: 0x004D6AAC File Offset: 0x004D4EAC
		private bool _CheckFunctionUnlocked(int iMainItemId)
		{
			GuidanceMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceMainTable>(iMainItemId, string.Empty, string.Empty);
			return tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.UnLockLevel;
		}

		// Token: 0x06010F14 RID: 69396 RVA: 0x004D6AF0 File Offset: 0x004D4EF0
		private void _InitMainItemTabs()
		{
			GameObject gameObject = Utility.FindChild(this.frame, "MainTabBG/ScrollView/ViewPort/MainTab");
			GameObject gameObject2 = Utility.FindChild(this.frame, "MainTabBG/ScrollView/ViewPort/MainTab/Prefab");
			gameObject2.CustomActive(false);
			ScrollRect scrollRect = Utility.FindComponent<ScrollRect>(this.frame, "GuidanceMainItems/ScrollView", true);
			scrollRect.verticalScrollbar.value = 1f;
			Delegate @delegate = Delegate.CreateDelegate(typeof(CachedSelectedObject<TabData, DevelopGuidanceTab>.OnSelectedDelegate), this, "OnTabSelected");
			List<object> list = Singleton<TableManager>.GetInstance().GetTable<GuidanceMainTable>().Values.ToList<object>();
			for (int i = 0; i < list.Count; i++)
			{
				if (this._CheckFunctionUnlocked((list[i] as GuidanceMainTable).ID))
				{
					this.m_akDevelopGuidanceTabs.Create(new object[]
					{
						gameObject,
						gameObject2,
						new TabData
						{
							mainItem = (list[i] as GuidanceMainTable)
						},
						@delegate
					});
				}
			}
			if (this.data != null)
			{
				DevelopGuidanceTab developGuidanceTab = this.m_akDevelopGuidanceTabs.ActiveObjects.Find((DevelopGuidanceTab x) => x.Value.mainItem.ID == this.data.mainItem.ID);
				if (developGuidanceTab != null)
				{
					developGuidanceTab.OnSelected();
				}
				else if (this.m_akDevelopGuidanceTabs.ActiveObjects.Count > 0)
				{
					this.m_akDevelopGuidanceTabs.ActiveObjects[0].OnSelected();
				}
			}
			else if (this.m_akDevelopGuidanceTabs.ActiveObjects.Count > 0)
			{
				this.m_akDevelopGuidanceTabs.ActiveObjects[0].OnSelected();
			}
		}

		// Token: 0x06010F15 RID: 69397 RVA: 0x004D6C8B File Offset: 0x004D508B
		private void OnTabSelected(TabData data)
		{
			if (data != null)
			{
				this.m_kComGuidanceMainItems.RefreshDatas(data.mainItem.ID);
			}
		}

		// Token: 0x06010F16 RID: 69398 RVA: 0x004D6CA9 File Offset: 0x004D50A9
		protected override void _OnCloseFrame()
		{
			CachedSelectedObject<TabData, DevelopGuidanceTab>.Clear();
			this.m_akDevelopGuidanceTabs.DestroyAllObjects();
			this.data = null;
			this.m_kComGuidanceMainItems.UnInitialize();
		}

		// Token: 0x06010F17 RID: 69399 RVA: 0x004D6CCD File Offset: 0x004D50CD
		[UIEventHandle("Title/Close")]
		private void OnClickCloseFrame()
		{
			this.frameMgr.CloseFrame<DevelopGuidanceMainFrame>(this, false);
		}

		// Token: 0x0400AE24 RID: 44580
		private DevelopGuidanceMainFrameData data;

		// Token: 0x0400AE25 RID: 44581
		private CachedObjectListManager<DevelopGuidanceTab> m_akDevelopGuidanceTabs = new CachedObjectListManager<DevelopGuidanceTab>();

		// Token: 0x0400AE26 RID: 44582
		private GuidanceMainItemList m_kComGuidanceMainItems = new GuidanceMainItemList();
	}
}
