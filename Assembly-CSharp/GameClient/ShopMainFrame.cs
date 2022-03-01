using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A5D RID: 6749
	internal class ShopMainFrame : ClientFrame
	{
		// Token: 0x06010914 RID: 67860 RVA: 0x004AEDE4 File Offset: 0x004AD1E4
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				string[] array = strParam.Split(new char[]
				{
					'|'
				});
				if (array.Length == 3)
				{
					int num = int.Parse(array[0]);
					int iShopLinkID = int.Parse(array[1]);
					int num2 = int.Parse(array[2]);
					ShopMainFrameData shopMainFrameData = new ShopMainFrameData();
					shopMainFrameData.iShopID = num;
					shopMainFrameData.iShopLinkID = iShopLinkID;
					shopMainFrameData.iShopTabID = num2;
					if (num == 24)
					{
						DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(num, num2, 0, -1);
					}
					else
					{
						DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(num, 0, num2, -1);
					}
				}
				else if (array.Length == 4)
				{
					int num3 = int.Parse(array[0]);
					int iShopLinkID2 = int.Parse(array[1]);
					int num4 = int.Parse(array[2]);
					int iShopFrameID = int.Parse(array[3]);
					bool flag = false;
					for (int i = 0; i < DataManager<ShopDataManager>.GetInstance().mysteryShopIDs.Length; i++)
					{
						if (num3 == DataManager<ShopDataManager>.GetInstance().mysteryShopIDs[i])
						{
							flag = true;
						}
					}
					if (flag)
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<MysteryShopFrame>(null, false);
						DataManager<ShopDataManager>.GetInstance().OpenShop(num3, 0, -1, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
					}
					else
					{
						ShopMainFrameData shopMainFrameData2 = new ShopMainFrameData();
						shopMainFrameData2.iShopID = num3;
						shopMainFrameData2.iShopLinkID = iShopLinkID2;
						shopMainFrameData2.iShopTabID = num4;
						shopMainFrameData2.iShopFrameID = iShopFrameID;
						if (num3 == 24)
						{
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(num3, num4, 0, -1);
						}
						else
						{
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(num3, 0, num4, -1);
						}
					}
				}
				else if (array.Length == 5)
				{
					int shopId = int.Parse(array[0]);
					int num5 = int.Parse(array[1]);
					int num6 = int.Parse(array[2]);
					int num7 = int.Parse(array[3]);
					int num8 = int.Parse(array[4]);
					if (num8 == 1)
					{
						if (DataManager<AccountShopDataManager>.GetInstance().CheckHasChildShop(shopId))
						{
							DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(shopId, num6, 0, -1);
						}
						else
						{
							DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(shopId, 0, num6, -1);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("ShopFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x06010915 RID: 67861 RVA: 0x004AF028 File Offset: 0x004AD428
		private void _InitLinks()
		{
			this.m_kLinkData = (this.userData as ShopMainFrameData);
			if (this.m_kLinkData == null)
			{
				this.m_kLinkData = new ShopMainFrameData();
			}
			if (this.m_kLinkData.iShopFrameID == 2)
			{
				DataManager<JarDataManager>.GetInstance().RequestQuaryJarShopSocre();
			}
		}

		// Token: 0x06010916 RID: 67862 RVA: 0x004AF077 File Offset: 0x004AD477
		private void _UnInitLinks()
		{
			this.m_kLinkData = null;
		}

		// Token: 0x06010917 RID: 67863 RVA: 0x004AF080 File Offset: 0x004AD480
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/ShopMainFrame";
		}

		// Token: 0x06010918 RID: 67864 RVA: 0x004AF087 File Offset: 0x004AD487
		protected override void _OnOpenFrame()
		{
			this.m_iShopFrameId = DataManager<ShopDataManager>.GetInstance().RegisterMainFrame();
			this._InitLinks();
			this._InitFrameConfigs();
			this._InitTabs();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopMainFrameClose, new ClientEventSystem.UIEventHandler(this._OnEventClose));
		}

		// Token: 0x06010919 RID: 67865 RVA: 0x004AF0C6 File Offset: 0x004AD4C6
		private void _OnEventClose(UIEvent uiEvent)
		{
			this.frameMgr.CloseFrame<ShopMainFrame>(this, false);
		}

		// Token: 0x0601091A RID: 67866 RVA: 0x004AF0D5 File Offset: 0x004AD4D5
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopMainFrameClose, new ClientEventSystem.UIEventHandler(this._OnEventClose));
			DataManager<ShopDataManager>.GetInstance().UnRegisterMainFrame(this.m_iShopFrameId);
			this._UnInitTabs();
			this._UnInitFrameConfigs();
			this._UnInitLinks();
		}

		// Token: 0x0601091B RID: 67867 RVA: 0x004AF114 File Offset: 0x004AD514
		private void _InitTabs()
		{
			GameObject gameObject = Utility.FindChild(this.frame, "middleback/MainTab");
			GameObject gameObject2 = Utility.FindChild(this.frame, "middleback/MainTab/Prefab");
			gameObject2.CustomActive(false);
			ShopMainFrame.ShopTab shopTab = null;
			bool flag = true;
			ShopMainFrameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopMainFrameTable>(this.m_kLinkData.iShopFrameID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("shopFrame can not be found with ID = {0}", new object[]
				{
					this.m_kLinkData.iShopFrameID
				});
				return;
			}
			this.name.text = tableItem.ShopName;
			this.goHelp.CustomActive(tableItem.HelpID > 0);
			this.comHelpAssistant.eType = (HelpFrame.HelpType)tableItem.HelpID;
			for (int i = 0; i < tableItem.Children.Count; i++)
			{
				ShopTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(tableItem.Children[i], string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (tableItem2.OpenLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						ShopMainFrame.ShopTab shopTab2 = this.m_akShopTabs.Create(tableItem2.ID, new object[]
						{
							gameObject,
							gameObject2,
							tableItem2
						});
						if (shopTab2 != null)
						{
							shopTab2.AddListener(new ShopMainFrame.ShopTab.OnTabChanged(this.OnTabChanged));
							if (shopTab == null)
							{
								shopTab = shopTab2;
							}
							if (this.m_kLinkData != null && this.m_kLinkData.iShopID == tableItem2.ID)
							{
								shopTab2.OnSelected();
								flag = false;
							}
						}
					}
				}
			}
			if (flag && shopTab != null)
			{
				shopTab.OnSelected();
			}
		}

		// Token: 0x0601091C RID: 67868 RVA: 0x004AF2CC File Offset: 0x004AD6CC
		private void _UnInitTabs()
		{
			foreach (ShopMainFrame.ShopTab shopTab in this.m_akShopTabs.ActiveObjects.Values)
			{
				shopTab.RemoveListener(new ShopMainFrame.ShopTab.OnTabChanged(this.OnTabChanged));
			}
			ShopMainFrame.ShopTab.Clear();
			this.m_akShopTabs.DestroyAllObjects();
		}

		// Token: 0x0601091D RID: 67869 RVA: 0x004AF32A File Offset: 0x004AD72A
		private void _InitFrameConfigs()
		{
			this.goFrameParent = Utility.FindChild(this.frame, "ChildFrame");
			ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
			instance.onOpenChildShopFrame = (ShopDataManager.OnOpenChildShopFrame)Delegate.Combine(instance.onOpenChildShopFrame, new ShopDataManager.OnOpenChildShopFrame(this.OnOpenChildShopFrame));
		}

		// Token: 0x0601091E RID: 67870 RVA: 0x004AF368 File Offset: 0x004AD768
		private void _UnInitFrameConfigs()
		{
			ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
			instance.onOpenChildShopFrame = (ShopDataManager.OnOpenChildShopFrame)Delegate.Remove(instance.onOpenChildShopFrame, new ShopDataManager.OnOpenChildShopFrame(this.OnOpenChildShopFrame));
			for (int i = 0; i < this.m_akFrameConfigs.Count; i++)
			{
				ShopFrame.CloseMulteFrame(this.m_akFrameConfigs[i].iShopID);
				this.m_akFrameConfigs[i].frame = null;
			}
			this.m_akFrameConfigs.Clear();
			this.goFrameParent = null;
		}

		// Token: 0x0601091F RID: 67871 RVA: 0x004AF3F4 File Offset: 0x004AD7F4
		private void OnOpenChildShopFrame(int iShopID, ShopFrame shopFrame, int iId)
		{
			if (this.m_iShopFrameId != iId)
			{
				return;
			}
			FrameConfig frameConfig = new FrameConfig();
			frameConfig.iShopID = iShopID;
			frameConfig.frame = shopFrame;
			this.m_akFrameConfigs.Add(frameConfig);
		}

		// Token: 0x06010920 RID: 67872 RVA: 0x004AF430 File Offset: 0x004AD830
		private void OnTabChanged(ShopMainFrame.ShopTab shopTab)
		{
			if (this.m_akFrameConfigs.Find((FrameConfig x) => x.iShopID == shopTab.ShopItem.ID) == null)
			{
				if (this.m_kLinkData != null && shopTab.ShopItem.ID == this.m_kLinkData.iShopID)
				{
					DataManager<ShopDataManager>.GetInstance().OpenShop(shopTab.ShopItem.ID, 0, this.m_kLinkData.iShopTabID, null, this.goFrameParent, ShopFrame.ShopFrameMode.SFM_CHILD_FRAME, this.m_iShopFrameId, this.m_kLinkData.iNPCID);
				}
				else
				{
					DataManager<ShopDataManager>.GetInstance().OpenShop(shopTab.ShopItem.ID, 0, -1, null, this.goFrameParent, ShopFrame.ShopFrameMode.SFM_CHILD_FRAME, this.m_iShopFrameId, this.m_kLinkData.iNPCID);
				}
				this.m_kLinkData.iNPCID = -1;
			}
			foreach (FrameConfig frameConfig in this.m_akFrameConfigs)
			{
				frameConfig.frame.Show(frameConfig.iShopID == shopTab.ShopItem.ID, null);
			}
		}

		// Token: 0x06010921 RID: 67873 RVA: 0x004AF584 File Offset: 0x004AD984
		[UIEventHandle("ComWnd/Title/Close")]
		private void OnClickReturn()
		{
			this.frameMgr.CloseFrame<ShopMainFrame>(this, false);
		}

		// Token: 0x0400A8ED RID: 43245
		private int m_iShopFrameId;

		// Token: 0x0400A8EE RID: 43246
		private ShopMainFrameData m_kLinkData;

		// Token: 0x0400A8EF RID: 43247
		private CachedObjectDicManager<int, ShopMainFrame.ShopTab> m_akShopTabs = new CachedObjectDicManager<int, ShopMainFrame.ShopTab>();

		// Token: 0x0400A8F0 RID: 43248
		[UIControl("ComWnd/Title/Horizen/Name", typeof(Text), 0)]
		private Text name;

		// Token: 0x0400A8F1 RID: 43249
		[UIObject("ComWnd/Title/Horizen/Help")]
		private GameObject goHelp;

		// Token: 0x0400A8F2 RID: 43250
		[UIControl("ComWnd/Title/Horizen/Help", typeof(HelpAssistant), 0)]
		private HelpAssistant comHelpAssistant;

		// Token: 0x0400A8F3 RID: 43251
		private List<FrameConfig> m_akFrameConfigs = new List<FrameConfig>();

		// Token: 0x0400A8F4 RID: 43252
		private GameObject goFrameParent;

		// Token: 0x02001A5E RID: 6750
		private class ShopTab : CachedObject
		{
			// Token: 0x17001D58 RID: 7512
			// (get) Token: 0x06010923 RID: 67875 RVA: 0x004AF59B File Offset: 0x004AD99B
			public ShopTable ShopItem
			{
				get
				{
					return this.shopItem;
				}
			}

			// Token: 0x06010924 RID: 67876 RVA: 0x004AF5A3 File Offset: 0x004AD9A3
			public static void Clear()
			{
				if (ShopMainFrame.ShopTab.ms_selected != null)
				{
					ShopMainFrame.ShopTab.ms_selected.SetSelected(false);
					ShopMainFrame.ShopTab.ms_selected = null;
				}
			}

			// Token: 0x06010925 RID: 67877 RVA: 0x004AF5C0 File Offset: 0x004AD9C0
			public void AddListener(ShopMainFrame.ShopTab.OnTabChanged onTabChanged)
			{
				this.onTabChanged = (ShopMainFrame.ShopTab.OnTabChanged)Delegate.Combine(this.onTabChanged, onTabChanged);
			}

			// Token: 0x06010926 RID: 67878 RVA: 0x004AF5D9 File Offset: 0x004AD9D9
			public void RemoveListener(ShopMainFrame.ShopTab.OnTabChanged onTabChanged)
			{
				this.onTabChanged = (ShopMainFrame.ShopTab.OnTabChanged)Delegate.Remove(this.onTabChanged, onTabChanged);
			}

			// Token: 0x06010927 RID: 67879 RVA: 0x004AF5F4 File Offset: 0x004AD9F4
			public override void OnDestroy()
			{
				this.onTabChanged = null;
				this.goLocal = null;
				this.goPrefab = null;
				this.goParent = null;
				this.shopItem = null;
				if (this.toggle != null)
				{
					this.toggle.onValueChanged.RemoveAllListeners();
					this.toggle = null;
				}
				this.label = null;
				this.labelCheck = null;
				this.goCheckMark = null;
			}

			// Token: 0x06010928 RID: 67880 RVA: 0x004AF664 File Offset: 0x004ADA64
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.shopItem = (param[2] as ShopTable);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.toggle = Utility.FindComponent<Toggle>(this.goLocal, "Toggle", true);
					this.toggle.onValueChanged.AddListener(delegate(bool bValue)
					{
						if (bValue)
						{
							this.OnSelected();
						}
					});
					this.label = Utility.FindComponent<Text>(this.goLocal, "Toggle/Label", true);
					this.labelCheck = Utility.FindComponent<Text>(this.goLocal, "Toggle/CheckMark/Label", true);
					this.goCheckMark = Utility.FindChild(this.goLocal, "Toggle/CheckMark");
					this.goHelp = Utility.FindChild(this.goLocal, "Help");
					this.comHelpAssistant = this.goHelp.GetComponent<HelpAssistant>();
				}
				this.goHelp.CustomActive(false);
				this.Enable();
				this._Update();
			}

			// Token: 0x06010929 RID: 67881 RVA: 0x004AF785 File Offset: 0x004ADB85
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601092A RID: 67882 RVA: 0x004AF7A4 File Offset: 0x004ADBA4
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0601092B RID: 67883 RVA: 0x004AF7AD File Offset: 0x004ADBAD
			public override void OnRefresh(object[] param)
			{
				this._Update();
			}

			// Token: 0x0601092C RID: 67884 RVA: 0x004AF7B5 File Offset: 0x004ADBB5
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0601092D RID: 67885 RVA: 0x004AF7D4 File Offset: 0x004ADBD4
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601092E RID: 67886 RVA: 0x004AF7F3 File Offset: 0x004ADBF3
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0601092F RID: 67887 RVA: 0x004AF7F8 File Offset: 0x004ADBF8
			private void _Update()
			{
				Text text = this.label;
				string shopName = this.shopItem.ShopName;
				this.labelCheck.text = shopName;
				text.text = shopName;
				this.comHelpAssistant.eType = (HelpFrame.HelpType)this.shopItem.HelpID;
			}

			// Token: 0x06010930 RID: 67888 RVA: 0x004AF83F File Offset: 0x004ADC3F
			private void SetSelected(bool bSelected)
			{
				this.goCheckMark.CustomActive(bSelected);
				this.goHelp.CustomActive(this.shopItem.HelpID > 0 && bSelected);
			}

			// Token: 0x06010931 RID: 67889 RVA: 0x004AF870 File Offset: 0x004ADC70
			public void OnSelected()
			{
				if (this != ShopMainFrame.ShopTab.ms_selected)
				{
					if (ShopMainFrame.ShopTab.ms_selected != null)
					{
						ShopMainFrame.ShopTab.ms_selected.SetSelected(false);
					}
					ShopMainFrame.ShopTab.ms_selected = this;
					this.SetSelected(true);
				}
				if (this.onTabChanged != null)
				{
					this.onTabChanged(this);
				}
			}

			// Token: 0x0400A8F5 RID: 43253
			private ShopMainFrame.ShopTab.OnTabChanged onTabChanged;

			// Token: 0x0400A8F6 RID: 43254
			private GameObject goLocal;

			// Token: 0x0400A8F7 RID: 43255
			private GameObject goPrefab;

			// Token: 0x0400A8F8 RID: 43256
			private GameObject goParent;

			// Token: 0x0400A8F9 RID: 43257
			private ShopTable shopItem;

			// Token: 0x0400A8FA RID: 43258
			private Toggle toggle;

			// Token: 0x0400A8FB RID: 43259
			private Text label;

			// Token: 0x0400A8FC RID: 43260
			private Text labelCheck;

			// Token: 0x0400A8FD RID: 43261
			private GameObject goCheckMark;

			// Token: 0x0400A8FE RID: 43262
			private GameObject goHelp;

			// Token: 0x0400A8FF RID: 43263
			private HelpAssistant comHelpAssistant;

			// Token: 0x0400A900 RID: 43264
			public static ShopMainFrame.ShopTab ms_selected;

			// Token: 0x02001A5F RID: 6751
			// (Invoke) Token: 0x06010935 RID: 67893
			public delegate void OnTabChanged(ShopMainFrame.ShopTab eTab);
		}
	}
}
