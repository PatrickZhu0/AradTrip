using System;

namespace LitJson
{
	// Token: 0x0200469E RID: 18078
	internal struct ArrayMetadata
	{
		// Token: 0x17002107 RID: 8455
		// (get) Token: 0x06019947 RID: 104775 RVA: 0x0080ED21 File Offset: 0x0080D121
		// (set) Token: 0x06019948 RID: 104776 RVA: 0x0080ED3F File Offset: 0x0080D13F
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

		// Token: 0x17002108 RID: 8456
		// (get) Token: 0x06019949 RID: 104777 RVA: 0x0080ED48 File Offset: 0x0080D148
		// (set) Token: 0x0601994A RID: 104778 RVA: 0x0080ED50 File Offset: 0x0080D150
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

		// Token: 0x17002109 RID: 8457
		// (get) Token: 0x0601994B RID: 104779 RVA: 0x0080ED59 File Offset: 0x0080D159
		// (set) Token: 0x0601994C RID: 104780 RVA: 0x0080ED61 File Offset: 0x0080D161
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

		// Token: 0x040123BC RID: 74684
		private Type element_type;

		// Token: 0x040123BD RID: 74685
		private bool is_array;

		// Token: 0x040123BE RID: 74686
		private bool is_list;
	}
}
