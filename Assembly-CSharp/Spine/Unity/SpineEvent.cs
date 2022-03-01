using System;

namespace Spine.Unity
{
	// Token: 0x02004A2E RID: 18990
	public class SpineEvent : SpineAttributeBase
	{
		// Token: 0x0601B6ED RID: 112365 RVA: 0x008763F8 File Offset: 0x008747F8
		public SpineEvent(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
