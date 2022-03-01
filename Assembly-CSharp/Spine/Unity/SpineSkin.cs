using System;

namespace Spine.Unity
{
	// Token: 0x02004A32 RID: 18994
	public class SpineSkin : SpineAttributeBase
	{
		// Token: 0x0601B6F1 RID: 112369 RVA: 0x0087648C File Offset: 0x0087488C
		public SpineSkin(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
