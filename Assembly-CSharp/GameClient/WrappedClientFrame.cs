using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DF2 RID: 3570
	internal class WrappedClientFrame : ClientFrame
	{
		// Token: 0x170018DD RID: 6365
		// (get) Token: 0x06008F75 RID: 36725 RVA: 0x001A8D04 File Offset: 0x001A7104
		public GameObject gameObject
		{
			get
			{
				return this.frame;
			}
		}

		// Token: 0x06008F76 RID: 36726 RVA: 0x001A8D0C File Offset: 0x001A710C
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x06008F77 RID: 36727 RVA: 0x001A8D0E File Offset: 0x001A710E
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x02000DF3 RID: 3571
		public class WrappedData
		{
		}

		// Token: 0x02000DF4 RID: 3572
		public class WrappedCachedItemObject<TFrame, TData> : CachedObject where TFrame : WrappedClientFrame, new() where TData : WrappedClientFrame.WrappedData, new()
		{
			// Token: 0x06008F7A RID: 36730 RVA: 0x001A8D20 File Offset: 0x001A7120
			public virtual void Update()
			{
			}

			// Token: 0x06008F7B RID: 36731 RVA: 0x001A8D22 File Offset: 0x001A7122
			public override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06008F7C RID: 36732 RVA: 0x001A8D41 File Offset: 0x001A7141
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06008F7D RID: 36733 RVA: 0x001A8D60 File Offset: 0x001A7160
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06008F7E RID: 36734 RVA: 0x001A8D7F File Offset: 0x001A717F
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x06008F7F RID: 36735 RVA: 0x001A8D82 File Offset: 0x001A7182
			public override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06008F80 RID: 36736 RVA: 0x001A8DA5 File Offset: 0x001A71A5
			public override void OnDestroy()
			{
				this.goLocal = null;
				this.dataScript = null;
				this.data = (TData)((object)null);
			}

			// Token: 0x04004740 RID: 18240
			protected GameObject goLocal;

			// Token: 0x04004741 RID: 18241
			protected CachedObjectBehavior dataScript;

			// Token: 0x04004742 RID: 18242
			protected TData data;
		}
	}
}
