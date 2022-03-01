using System;

namespace YouMe
{
	// Token: 0x02004ACA RID: 19146
	internal struct ArrayMetadata
	{
		// Token: 0x170025BD RID: 9661
		// (get) Token: 0x0601BCF0 RID: 113904 RVA: 0x00884835 File Offset: 0x00882C35
		// (set) Token: 0x0601BCF1 RID: 113905 RVA: 0x00884853 File Offset: 0x00882C53
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

		// Token: 0x170025BE RID: 9662
		// (get) Token: 0x0601BCF2 RID: 113906 RVA: 0x0088485C File Offset: 0x00882C5C
		// (set) Token: 0x0601BCF3 RID: 113907 RVA: 0x00884864 File Offset: 0x00882C64
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

		// Token: 0x170025BF RID: 9663
		// (get) Token: 0x0601BCF4 RID: 113908 RVA: 0x0088486D File Offset: 0x00882C6D
		// (set) Token: 0x0601BCF5 RID: 113909 RVA: 0x00884875 File Offset: 0x00882C75
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

		// Token: 0x040135E8 RID: 79336
		private Type element_type;

		// Token: 0x040135E9 RID: 79337
		private bool is_array;

		// Token: 0x040135EA RID: 79338
		private bool is_list;
	}
}
