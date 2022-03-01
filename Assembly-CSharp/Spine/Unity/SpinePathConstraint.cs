using System;

namespace Spine.Unity
{
	// Token: 0x02004A30 RID: 18992
	public class SpinePathConstraint : SpineAttributeBase
	{
		// Token: 0x0601B6EF RID: 112367 RVA: 0x00876442 File Offset: 0x00874842
		public SpinePathConstraint(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
