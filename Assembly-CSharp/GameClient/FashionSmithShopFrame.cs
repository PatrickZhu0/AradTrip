using System;
using System.ComponentModel;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B39 RID: 6969
	internal class FashionSmithShopFrame : ClientFrame
	{
		// Token: 0x060111B1 RID: 70065 RVA: 0x004E85ED File Offset: 0x004E69ED
		public static void CommandOpen(FashionSmithShopFrameData data = null)
		{
			if (data == null)
			{
				data = new FashionSmithShopFrameData();
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionSmithShopFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x060111B2 RID: 70066 RVA: 0x004E8610 File Offset: 0x004E6A10
		public static void OpenLinkFrame(string strParam)
		{
			string[] array = strParam.Split(new char[]
			{
				'_'
			});
			if (array.Length != 2)
			{
				return;
			}
			int eFunction = 0;
			if (!int.TryParse(array[0], out eFunction))
			{
				return;
			}
			ulong linkGUID = 0UL;
			if (!ulong.TryParse(array[1], out linkGUID))
			{
				return;
			}
			FashionSmithShopFrameData userData = new FashionSmithShopFrameData
			{
				eFunction = (FashionSmithShopFrame.FunctionType)eFunction,
				linkGUID = linkGUID
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionSmithShopFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x060111B3 RID: 70067 RVA: 0x004E868A File Offset: 0x004E6A8A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionSmithshop";
		}

		// Token: 0x060111B4 RID: 70068 RVA: 0x004E8694 File Offset: 0x004E6A94
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as FashionSmithShopFrameData);
			if (this.data == null)
			{
				this.data = new FashionSmithShopFrameData
				{
					eFunction = FashionSmithShopFrame.FunctionType.FT_MODIFY
				};
			}
			else
			{
				this.data.eFunction = FashionSmithShopFrame.FunctionType.FT_MODIFY;
			}
			this._InitFunctionTabs();
		}

		// Token: 0x060111B5 RID: 70069 RVA: 0x004E86E8 File Offset: 0x004E6AE8
		protected override void _OnCloseFrame()
		{
			CachedSelectedObject<FashionSmithShopFrame.FunctionTabData, FashionSmithShopFrame.FunctionTab>.Clear();
			this.m_akFunctionTabs.DestroyAllObjects();
		}

		// Token: 0x060111B6 RID: 70070 RVA: 0x004E86FA File Offset: 0x004E6AFA
		[UIEventHandle("ComWnd/Title/Close")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<FashionSmithShopFrame>(this, false);
		}

		// Token: 0x060111B7 RID: 70071 RVA: 0x004E870C File Offset: 0x004E6B0C
		private void _InitFunctionTabs()
		{
			this.goTabPrefab.CustomActive(false);
			for (int i = 0; i < 1; i++)
			{
				if (this._IsFunctionOpen((FashionSmithShopFrame.FunctionType)i))
				{
					this.m_akFunctionTabs.Create(new object[]
					{
						this.goTabParent,
						this.goTabPrefab,
						new FashionSmithShopFrame.FunctionTabData
						{
							eFunctionType = (FashionSmithShopFrame.FunctionType)i
						},
						Delegate.CreateDelegate(typeof(CachedSelectedObject<FashionSmithShopFrame.FunctionTabData, FashionSmithShopFrame.FunctionTab>.OnSelectedDelegate), this, "_OnFunctionChanged")
					});
				}
			}
			FashionSmithShopFrame.FunctionTab functionTab = this.m_akFunctionTabs.Find((FashionSmithShopFrame.FunctionTab x) => x.Value.eFunctionType == this.data.eFunction);
			if (functionTab == null && this.m_akFunctionTabs.ActiveObjects.Count > 0)
			{
				functionTab = this.m_akFunctionTabs.ActiveObjects[0];
				this.data.eFunction = functionTab.Value.eFunctionType;
			}
			if (functionTab != null)
			{
				functionTab.OnSelected();
			}
		}

		// Token: 0x060111B8 RID: 70072 RVA: 0x004E87F8 File Offset: 0x004E6BF8
		private bool _IsFunctionOpen(FashionSmithShopFrame.FunctionType eFunction)
		{
			int[] array = new int[]
			{
				54
			};
			if (eFunction >= FashionSmithShopFrame.FunctionType.FT_MODIFY && eFunction < FashionSmithShopFrame.FunctionType.FT_COUNT)
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(array[(int)eFunction], string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.FinishLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
				}
			}
			return false;
		}

		// Token: 0x060111B9 RID: 70073 RVA: 0x004E8854 File Offset: 0x004E6C54
		private void _OnFunctionChanged(FashionSmithShopFrame.FunctionTabData value)
		{
			if (value.frame == null && value.eFunctionType == FashionSmithShopFrame.FunctionType.FT_MODIFY)
			{
				value.frame = this.frameMgr.OpenFrame<FashionAttributesModifyFrame>(this.goChildParent, this.data.linkGUID, string.Empty);
			}
			this.m_akFunctionTabs.ActiveObjects.ForEach(delegate(FashionSmithShopFrame.FunctionTab x)
			{
				if (x != null && x.Value != null && x.Value.frame != null)
				{
					x.Value.frame.Show(value.eFunctionType == x.Value.eFunctionType, null);
				}
			});
		}

		// Token: 0x0400B051 RID: 45137
		private FashionSmithShopFrameData data;

		// Token: 0x0400B052 RID: 45138
		[UIObject("VerticalFilter")]
		private GameObject goTabParent;

		// Token: 0x0400B053 RID: 45139
		[UIObject("VerticalFilter/Filter")]
		private GameObject goTabPrefab;

		// Token: 0x0400B054 RID: 45140
		private CachedObjectListManager<FashionSmithShopFrame.FunctionTab> m_akFunctionTabs = new CachedObjectListManager<FashionSmithShopFrame.FunctionTab>();

		// Token: 0x0400B055 RID: 45141
		[UIObject("ChildFrameParent")]
		private GameObject goChildParent;

		// Token: 0x02001B3A RID: 6970
		public enum FunctionType
		{
			// Token: 0x0400B057 RID: 45143
			[Description("fashion_smith_modify")]
			FT_MODIFY,
			// Token: 0x0400B058 RID: 45144
			FT_COUNT
		}

		// Token: 0x02001B3B RID: 6971
		private class FunctionTabData
		{
			// Token: 0x0400B059 RID: 45145
			public FashionSmithShopFrame.FunctionType eFunctionType = FashionSmithShopFrame.FunctionType.FT_COUNT;

			// Token: 0x0400B05A RID: 45146
			public IClientFrame frame;
		}

		// Token: 0x02001B3C RID: 6972
		private class FunctionTab : CachedSelectedObject<FashionSmithShopFrame.FunctionTabData, FashionSmithShopFrame.FunctionTab>
		{
			// Token: 0x060111BD RID: 70077 RVA: 0x004E890C File Offset: 0x004E6D0C
			public override void Initialize()
			{
				this.goCheckMark = Utility.FindChild(this.goLocal, "CheckMark");
				this.labelName = Utility.FindComponent<Text>(this.goLocal, "Text", true);
				this.checkLabelName = Utility.FindComponent<Text>(this.goLocal, "CheckMark/Text", true);
			}

			// Token: 0x060111BE RID: 70078 RVA: 0x004E8960 File Offset: 0x004E6D60
			public override void OnUpdate()
			{
				Text text = this.labelName;
				string text2 = TR.Value(Utility.GetEnumDescription<FashionSmithShopFrame.FunctionType>(base.Value.eFunctionType));
				this.checkLabelName.text = text2;
				text.text = text2;
			}

			// Token: 0x060111BF RID: 70079 RVA: 0x004E899B File Offset: 0x004E6D9B
			public override void UnInitialize()
			{
				if (base.Value.frame != null)
				{
					base.Value.frame.Close(true);
					base.Value.frame = null;
				}
			}

			// Token: 0x060111C0 RID: 70080 RVA: 0x004E89CA File Offset: 0x004E6DCA
			public override void OnDisplayChanged(bool bShow)
			{
				this.goCheckMark.CustomActive(bShow);
			}

			// Token: 0x0400B05B RID: 45147
			private GameObject goCheckMark;

			// Token: 0x0400B05C RID: 45148
			private Text labelName;

			// Token: 0x0400B05D RID: 45149
			private Text checkLabelName;
		}
	}
}
