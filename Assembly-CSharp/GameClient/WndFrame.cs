using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000DF0 RID: 3568
	public class WndFrame : ClientFrame
	{
		// Token: 0x06008F69 RID: 36713 RVA: 0x001A8B04 File Offset: 0x001A6F04
		protected override void _bindExUI()
		{
			this.mCoin1 = this.mBind.GetCom<ComCommonConsume>("coin1");
			this.mCoin2 = this.mBind.GetCom<ComCommonConsume>("coin2");
			this.mCoin3 = this.mBind.GetCom<ComCommonConsume>("coin3");
			this.mCoin4 = this.mBind.GetCom<ComCommonConsume>("coin4");
			this.mHelp = this.mBind.GetCom<Button>("help");
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mContent = this.mBind.GetCom<RectTransform>("content");
		}

		// Token: 0x06008F6A RID: 36714 RVA: 0x001A8BC1 File Offset: 0x001A6FC1
		protected override void _unbindExUI()
		{
			this.mCoin1 = null;
			this.mCoin2 = null;
			this.mCoin3 = null;
			this.mCoin4 = null;
			this.mHelp = null;
			this.mClose = null;
			this.mName = null;
			this.mContent = null;
		}

		// Token: 0x06008F6B RID: 36715 RVA: 0x001A8BFB File Offset: 0x001A6FFB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/ComWnd";
		}

		// Token: 0x06008F6C RID: 36716 RVA: 0x001A8C02 File Offset: 0x001A7002
		public virtual string GetContentPath()
		{
			return string.Empty;
		}

		// Token: 0x06008F6D RID: 36717 RVA: 0x001A8C09 File Offset: 0x001A7009
		public virtual string GetSubFrameName()
		{
			return string.Empty;
		}

		// Token: 0x06008F6E RID: 36718 RVA: 0x001A8C10 File Offset: 0x001A7010
		public virtual string GetTitle()
		{
			return string.Empty;
		}

		// Token: 0x06008F6F RID: 36719 RVA: 0x001A8C17 File Offset: 0x001A7017
		public string GetBindPath(string path)
		{
			return string.Format("Content/{0}(Clone)/{1}", this.GetSubFrameName(), path);
		}

		// Token: 0x06008F70 RID: 36720 RVA: 0x001A8C2C File Offset: 0x001A702C
		public void SetCoinType(byte idx, ComCommonConsume.eType type, ComCommonConsume.eCountType countType, int itemId)
		{
			switch (idx)
			{
			case 0:
				this.mCoin1.SetData(type, countType, itemId);
				break;
			case 1:
				this.mCoin2.SetData(type, countType, itemId);
				break;
			case 2:
				this.mCoin3.SetData(type, countType, itemId);
				break;
			case 3:
				this.mCoin4.SetData(type, countType, itemId);
				break;
			}
		}

		// Token: 0x06008F71 RID: 36721 RVA: 0x001A8CA9 File Offset: 0x001A70A9
		protected override bool AttachContent()
		{
			this.content = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.GetContentPath(), true, 0U);
			this.content.transform.SetParent(this.mContent, false);
			this._InitTitle();
			return true;
		}

		// Token: 0x06008F72 RID: 36722 RVA: 0x001A8CE1 File Offset: 0x001A70E1
		protected void _InitTitle()
		{
			this.mName.text = this.GetTitle();
		}

		// Token: 0x04004736 RID: 18230
		private ComCommonConsume mCoin1;

		// Token: 0x04004737 RID: 18231
		private ComCommonConsume mCoin2;

		// Token: 0x04004738 RID: 18232
		private ComCommonConsume mCoin3;

		// Token: 0x04004739 RID: 18233
		private ComCommonConsume mCoin4;

		// Token: 0x0400473A RID: 18234
		private Button mHelp;

		// Token: 0x0400473B RID: 18235
		private Button mClose;

		// Token: 0x0400473C RID: 18236
		private Text mName;

		// Token: 0x0400473D RID: 18237
		private RectTransform mContent;

		// Token: 0x02000DF1 RID: 3569
		private class CoinType
		{
			// Token: 0x0400473E RID: 18238
			public ComCommonConsume.eType type;

			// Token: 0x0400473F RID: 18239
			public uint value;
		}
	}
}
