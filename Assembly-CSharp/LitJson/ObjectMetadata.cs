using System;
using System.Collections.Generic;

namespace LitJson
{
	// Token: 0x0200469F RID: 18079
	internal struct ObjectMetadata
	{
		// Token: 0x1700210A RID: 8458
		// (get) Token: 0x0601994D RID: 104781 RVA: 0x0080ED6A File Offset: 0x0080D16A
		// (set) Token: 0x0601994E RID: 104782 RVA: 0x0080ED88 File Offset: 0x0080D188
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

		// Token: 0x1700210B RID: 8459
		// (get) Token: 0x0601994F RID: 104783 RVA: 0x0080ED91 File Offset: 0x0080D191
		// (set) Token: 0x06019950 RID: 104784 RVA: 0x0080ED99 File Offset: 0x0080D199
		public bool IsDictionary
		{
			get
			{
				return this.is_dictionary;
			}
			set
			{
				this.is_dictionary = value;
			}
		}

		// Token: 0x1700210C RID: 8460
		// (get) Token: 0x06019951 RID: 104785 RVA: 0x0080EDA2 File Offset: 0x0080D1A2
		// (set) Token: 0x06019952 RID: 104786 RVA: 0x0080EDAA File Offset: 0x0080D1AA
		public IDictionary<string, PropertyMetadata> Properties
		{
			get
			{
				return this.properties;
			}
			set
			{
				this.properties = value;
			}
		}

		// Token: 0x040123BF RID: 74687
		private Type element_type;

		// Token: 0x040123C0 RID: 74688
		private bool is_dictionary;

		// Token: 0x040123C1 RID: 74689
		private IDictionary<string, PropertyMetadata> properties;
	}
}
