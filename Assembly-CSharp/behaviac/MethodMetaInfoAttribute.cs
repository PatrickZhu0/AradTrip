using System;

namespace behaviac
{
	// Token: 0x0200475D RID: 18269
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class MethodMetaInfoAttribute : TypeMetaInfoAttribute
	{
		// Token: 0x0601A432 RID: 107570 RVA: 0x0082633D File Offset: 0x0082473D
		public MethodMetaInfoAttribute(string displayName, string description) : base(displayName, description)
		{
		}

		// Token: 0x0601A433 RID: 107571 RVA: 0x00826347 File Offset: 0x00824747
		public MethodMetaInfoAttribute()
		{
		}
	}
}
