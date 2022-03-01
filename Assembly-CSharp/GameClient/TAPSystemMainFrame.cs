using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BF6 RID: 7158
	internal class TAPSystemMainFrame : ClientFrame
	{
		// Token: 0x060118A5 RID: 71845 RVA: 0x0051A7FC File Offset: 0x00518BFC
		public TAPSystemMainFrame()
		{
			TAPTabData[] array = new TAPTabData[1];
			int num = 0;
			TAPTabData taptabData = new TAPTabData();
			taptabData.eTAPSystemTabType = TAPSystemTabType.TSTT_RELATION_INFO;
			taptabData.name = TR.Value("tap_system_relation_info");
			TAPTabData taptabData2 = taptabData;
			if (TAPSystemMainFrame.<>f__mg$cache0 == null)
			{
				TAPSystemMainFrame.<>f__mg$cache0 = new TAPTabData.OpenCheck(ComTAPOpenControl.IsOpen);
			}
			taptabData2.isOpen = TAPSystemMainFrame.<>f__mg$cache0;
			TAPTabData taptabData3 = taptabData;
			if (TAPSystemMainFrame.<>f__mg$cache1 == null)
			{
				TAPSystemMainFrame.<>f__mg$cache1 = new TAPTabData.OnTabChanged(ComTAPOpenControl._OpenTAPSystem);
			}
			taptabData3.onTabChanged = TAPSystemMainFrame.<>f__mg$cache1;
			taptabData.root = null;
			array[num] = taptabData;
			this.datas = array;
			this.m_akTabs = new CachedObjectListManager<TapTabItem>();
			base..ctor();
		}

		// Token: 0x060118A6 RID: 71846 RVA: 0x0051A894 File Offset: 0x00518C94
		public static void OpenLinkFrame(string strParam)
		{
			int num = 0;
			if (int.TryParse(strParam, out num) && num >= 0 && num < 1)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<RelationFrameNew>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x060118A7 RID: 71847 RVA: 0x0051A8D0 File Offset: 0x00518CD0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TAPSystem/TAPSystemMainFrame";
		}

		// Token: 0x060118A8 RID: 71848 RVA: 0x0051A8D7 File Offset: 0x00518CD7
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as TAPSystemMainFrameData);
			DataManager<RelationDataManager>.GetInstance().SendUpdateRelation();
			this._InitTabs();
			base._AddButton("ComWnd/Title/Close", delegate
			{
				this.frameMgr.CloseFrame<TAPSystemMainFrame>(this, false);
			});
		}

		// Token: 0x060118A9 RID: 71849 RVA: 0x0051A911 File Offset: 0x00518D11
		protected override void _OnCloseFrame()
		{
			this._UnInitTabs();
			this.data = null;
		}

		// Token: 0x060118AA RID: 71850 RVA: 0x0051A920 File Offset: 0x00518D20
		private void _InitTabs()
		{
			this.goTabPrefab.CustomActive(false);
			this._CheckTabs();
			TapTabItem tapTabItem = this.m_akTabs.Find((TapTabItem x) => x.Value.eTAPSystemTabType == this.data.eTAPSystemTabType);
			if (tapTabItem == null && this.m_akTabs.ActiveObjects.Count > 0)
			{
				tapTabItem = this.m_akTabs.ActiveObjects[0];
			}
			if (tapTabItem != null)
			{
				tapTabItem.OnSelected();
			}
		}

		// Token: 0x060118AB RID: 71851 RVA: 0x0051A994 File Offset: 0x00518D94
		private void _CheckTabs()
		{
			for (int i = 0; i < this.datas.Length; i++)
			{
				TAPTabData current = this.datas[i];
				if (current != null && current.isOpen != null && current.isOpen() && this.m_akTabs.ActiveObjects.Find((TapTabItem x) => x.Value.eTAPSystemTabType == current.eTAPSystemTabType) == null)
				{
					TapTabItem tapTabItem = this.m_akTabs.Create(new object[]
					{
						this.goTabParent,
						this.goTabPrefab,
						current,
						Delegate.CreateDelegate(typeof(CachedSelectedObject<TAPTabData, TapTabItem>.OnSelectedDelegate), this, "_OnTabChanged"),
						false
					});
				}
			}
		}

		// Token: 0x060118AC RID: 71852 RVA: 0x0051AA70 File Offset: 0x00518E70
		private void _OnTabChanged(TAPTabData Value)
		{
			if (Value != null)
			{
				int num = (int)(Value.eTAPSystemTabType + 9527);
				if (Value.onTabChanged != null && !(base._GetChildFrame(num) is ClientFrame))
				{
					Value.root = this.goChildParent;
					ClientFrame clientFrame = Value.onTabChanged(Value.eTAPSystemTabType, Value);
					base._AddChildFrame(num, clientFrame);
				}
				for (int i = 0; i < 1; i++)
				{
					int num2 = i + 9527;
					ClientFrame clientFrame2 = base._GetChildFrame(num2) as ClientFrame;
					if (clientFrame2 != null)
					{
						clientFrame2.SetVisible(num2 == num);
					}
				}
			}
		}

		// Token: 0x060118AD RID: 71853 RVA: 0x0051AB11 File Offset: 0x00518F11
		private void _UnInitTabs()
		{
			this.m_akTabs.DestroyAllObjects();
		}

		// Token: 0x060118AE RID: 71854 RVA: 0x0051AB1E File Offset: 0x00518F1E
		private void _RegisterEvent()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x060118AF RID: 71855 RVA: 0x0051AB46 File Offset: 0x00518F46
		private void _UnRegisterEvent()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x060118B0 RID: 71856 RVA: 0x0051AB6E File Offset: 0x00518F6E
		private void _OnLevelChanged(int iPre, int iCur)
		{
			this._CheckTabs();
		}

		// Token: 0x0400B67B RID: 46715
		private TAPTabData[] datas;

		// Token: 0x0400B67C RID: 46716
		[UIObject("VerticalFilter")]
		private GameObject goTabParent;

		// Token: 0x0400B67D RID: 46717
		[UIObject("VerticalFilter/Filter")]
		private GameObject goTabPrefab;

		// Token: 0x0400B67E RID: 46718
		[UIObject("Root")]
		private GameObject goChildParent;

		// Token: 0x0400B67F RID: 46719
		private CachedObjectListManager<TapTabItem> m_akTabs;

		// Token: 0x0400B680 RID: 46720
		private TAPSystemMainFrameData data;

		// Token: 0x0400B681 RID: 46721
		[CompilerGenerated]
		private static TAPTabData.OpenCheck <>f__mg$cache0;

		// Token: 0x0400B682 RID: 46722
		[CompilerGenerated]
		private static TAPTabData.OnTabChanged <>f__mg$cache1;
	}
}
