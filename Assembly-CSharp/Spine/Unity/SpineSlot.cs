using System;

namespace Spine.Unity
{
	// Token: 0x02004A2D RID: 18989
	public class SpineSlot : SpineAttributeBase
	{
		// Token: 0x0601B6EC RID: 112364 RVA: 0x008763CB File Offset: 0x008747CB
		public SpineSlot(string startsWith = "", string dataField = "", bool containsBoundingBoxes = false, bool includeNone = true, bool fallbackToTextField = false)
		{
			this.startsWith = startsWith;
			this.dataField = dataField;
			this.containsBoundingBoxes = containsBoundingBoxes;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}

		// Token: 0x04013199 RID: 78233
		public bool containsBoundingBoxes;
	}
}
