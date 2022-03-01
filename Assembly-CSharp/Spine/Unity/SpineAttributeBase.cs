using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A2C RID: 18988
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
	public abstract class SpineAttributeBase : PropertyAttribute
	{
		// Token: 0x04013195 RID: 78229
		public string dataField = string.Empty;

		// Token: 0x04013196 RID: 78230
		public string startsWith = string.Empty;

		// Token: 0x04013197 RID: 78231
		public bool includeNone = true;

		// Token: 0x04013198 RID: 78232
		public bool fallbackToTextField;
	}
}
