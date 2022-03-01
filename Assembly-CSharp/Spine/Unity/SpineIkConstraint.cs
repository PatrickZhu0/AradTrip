using System;

namespace Spine.Unity
{
	// Token: 0x02004A2F RID: 18991
	public class SpineIkConstraint : SpineAttributeBase
	{
		// Token: 0x0601B6EE RID: 112366 RVA: 0x0087641D File Offset: 0x0087481D
		public SpineIkConstraint(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}
	}
}
