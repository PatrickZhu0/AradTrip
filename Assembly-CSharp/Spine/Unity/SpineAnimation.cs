using System;

namespace Spine.Unity
{
	// Token: 0x02004A33 RID: 18995
	public class SpineAnimation : SpineAttributeBase
	{
		// Token: 0x0601B6F2 RID: 112370 RVA: 0x008764B1 File Offset: 0x008748B1
		public SpineAnimation(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
