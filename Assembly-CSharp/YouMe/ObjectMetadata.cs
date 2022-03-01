using System;
using System.Collections.Generic;

namespace YouMe
{
	// Token: 0x02004ACB RID: 19147
	internal struct ObjectMetadata
	{
		// Token: 0x170025C0 RID: 9664
		// (get) Token: 0x0601BCF6 RID: 113910 RVA: 0x0088487E File Offset: 0x00882C7E
		// (set) Token: 0x0601BCF7 RID: 113911 RVA: 0x0088489C File Offset: 0x00882C9C
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

		// Token: 0x170025C1 RID: 9665
		// (get) Token: 0x0601BCF8 RID: 113912 RVA: 0x008848A5 File Offset: 0x00882CA5
		// (set) Token: 0x0601BCF9 RID: 113913 RVA: 0x008848AD File Offset: 0x00882CAD
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

		// Token: 0x170025C2 RID: 9666
		// (get) Token: 0x0601BCFA RID: 113914 RVA: 0x008848B6 File Offset: 0x00882CB6
		// (set) Token: 0x0601BCFB RID: 113915 RVA: 0x008848BE File Offset: 0x00882CBE
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

		// Token: 0x040135EB RID: 79339
		private Type element_type;

		// Token: 0x040135EC RID: 79340
		private bool is_dictionary;

		// Token: 0x040135ED RID: 79341
		private IDictionary<string, PropertyMetadata> properties;
	}
}
