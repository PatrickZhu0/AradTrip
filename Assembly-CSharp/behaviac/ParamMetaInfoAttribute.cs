using System;

namespace behaviac
{
	// Token: 0x0200475E RID: 18270
	[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
	public class ParamMetaInfoAttribute : TypeMetaInfoAttribute
	{
		// Token: 0x0601A434 RID: 107572 RVA: 0x0082634F File Offset: 0x0082474F
		public ParamMetaInfoAttribute()
		{
		}

		// Token: 0x0601A435 RID: 107573 RVA: 0x0082636D File Offset: 0x0082476D
		public ParamMetaInfoAttribute(string displayName, string description, string defaultValue) : base(displayName, description)
		{
			this.defaultValue_ = defaultValue;
			this.rangeMin_ = float.MinValue;
			this.rangeMax_ = float.MaxValue;
		}

		// Token: 0x0601A436 RID: 107574 RVA: 0x008263AA File Offset: 0x008247AA
		public ParamMetaInfoAttribute(string displayName, string description, string defaultValue, float rangeMin, float rangeMax) : base(displayName, description)
		{
			this.defaultValue_ = defaultValue;
			this.rangeMin_ = rangeMin;
			this.rangeMax_ = rangeMax;
		}

		// Token: 0x17002268 RID: 8808
		// (get) Token: 0x0601A437 RID: 107575 RVA: 0x008263E1 File Offset: 0x008247E1
		public string DefaultValue
		{
			get
			{
				return this.defaultValue_;
			}
		}

		// Token: 0x17002269 RID: 8809
		// (get) Token: 0x0601A438 RID: 107576 RVA: 0x008263E9 File Offset: 0x008247E9
		public float RangeMin
		{
			get
			{
				return this.rangeMin_;
			}
		}

		// Token: 0x1700226A RID: 8810
		// (get) Token: 0x0601A439 RID: 107577 RVA: 0x008263F1 File Offset: 0x008247F1
		public float RangeMax
		{
			get
			{
				return this.rangeMax_;
			}
		}

		// Token: 0x040126FA RID: 75514
		private string defaultValue_;

		// Token: 0x040126FB RID: 75515
		private float rangeMin_ = float.MinValue;

		// Token: 0x040126FC RID: 75516
		private float rangeMax_ = float.MaxValue;
	}
}
