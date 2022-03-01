using System;

namespace YIMEngine
{
	// Token: 0x02004A7B RID: 19067
	internal struct ArrayMetadata
	{
		// Token: 0x17002511 RID: 9489
		// (get) Token: 0x0601BA1A RID: 113178 RVA: 0x0087CA39 File Offset: 0x0087AE39
		// (set) Token: 0x0601BA1B RID: 113179 RVA: 0x0087CA57 File Offset: 0x0087AE57
		public Type ElementType
		{
			get
			{
				if (this.element_type == null)
				{
					return typeof(JsonData);
				}
				return this.element_type;
			}
			set
			{
				this.element_type = value;
			}
		}

		// Token: 0x17002512 RID: 9490
		// (get) Token: 0x0601BA1C RID: 113180 RVA: 0x0087CA60 File Offset: 0x0087AE60
		// (set) Token: 0x0601BA1D RID: 113181 RVA: 0x0087CA68 File Offset: 0x0087AE68
		public bool IsArray
		{
			get
			{
				return this.is_array;
			}
			set
			{
				this.is_array = value;
			}
		}

		// Token: 0x17002513 RID: 9491
		// (get) Token: 0x0601BA1E RID: 113182 RVA: 0x0087CA71 File Offset: 0x0087AE71
		// (set) Token: 0x0601BA1F RID: 113183 RVA: 0x0087CA79 File Offset: 0x0087AE79
		public bool IsList
		{
			get
			{
				return this.is_list;
			}
			set
			{
				this.is_list = value;
			}
		}

		// Token: 0x04013422 RID: 78882
		private Type element_type;

		// Token: 0x04013423 RID: 78883
		private bool is_array;

		// Token: 0x04013424 RID: 78884
		private bool is_list;
	}
}
