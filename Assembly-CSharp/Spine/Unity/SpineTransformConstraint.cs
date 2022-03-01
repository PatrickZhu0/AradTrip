using System;

namespace Spine.Unity
{
	// Token: 0x02004A31 RID: 18993
	public class SpineTransformConstraint : SpineAttributeBase
	{
		// Token: 0x0601B6F0 RID: 112368 RVA: 0x00876467 File Offset: 0x00874867
		public SpineTransformConstraint(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
