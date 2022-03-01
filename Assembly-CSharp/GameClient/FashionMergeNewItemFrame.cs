using System;

namespace GameClient
{
	// Token: 0x02001B32 RID: 6962
	public class FashionMergeNewItemFrame : ClientFrame
	{
		// Token: 0x06011181 RID: 70017 RVA: 0x004E7208 File Offset: 0x004E5608
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/FashionSmithShop/FashionMergeNewItemFrame";
		}

		// Token: 0x06011182 RID: 70018 RVA: 0x004E7210 File Offset: 0x004E5610
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			FashionItemSelectedType fashionItemSelectedType = this.userData as FashionItemSelectedType;
			if (this.mFashionMergeNewItemView != null && fashionItemSelectedType != null)
			{
				this.mFashionMergeNewItemView.InitData(fashionItemSelectedType.FashionPart, fashionItemSelectedType.IsLeft, fashionItemSelectedType.NeedBlue);
			}
		}

		// Token: 0x06011183 RID: 70019 RVA: 0x004E7263 File Offset: 0x004E5663
		protected override void _bindExUI()
		{
			this.mFashionMergeNewItemView = this.mBind.GetCom<FashionMergeNewItemView>("FashionMergeNewItemView");
		}

		// Token: 0x06011184 RID: 70020 RVA: 0x004E727B File Offset: 0x004E567B
		protected override void _unbindExUI()
		{
			this.mFashionMergeNewItemView = null;
		}

		// Token: 0x0400B02C RID: 45100
		private FashionMergeNewItemView mFashionMergeNewItemView;
	}
}
