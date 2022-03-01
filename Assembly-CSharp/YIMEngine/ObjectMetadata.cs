using System;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A7C RID: 19068
	internal struct ObjectMetadata
	{
		// Token: 0x17002514 RID: 9492
		// (get) Token: 0x0601BA20 RID: 113184 RVA: 0x0087CA82 File Offset: 0x0087AE82
		// (set) Token: 0x0601BA21 RID: 113185 RVA: 0x0087CAA0 File Offset: 0x0087AEA0
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

		// Token: 0x17002515 RID: 9493
		// (get) Token: 0x0601BA22 RID: 113186 RVA: 0x0087CAA9 File Offset: 0x0087AEA9
		// (set) Token: 0x0601BA23 RID: 113187 RVA: 0x0087CAB1 File Offset: 0x0087AEB1
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

		// Token: 0x17002516 RID: 9494
		// (get) Token: 0x0601BA24 RID: 113188 RVA: 0x0087CABA File Offset: 0x0087AEBA
		// (set) Token: 0x0601BA25 RID: 113189 RVA: 0x0087CAC2 File Offset: 0x0087AEC2
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

		// Token: 0x04013425 RID: 78885
		private Type element_type;

		// Token: 0x04013426 RID: 78886
		private bool is_dictionary;

		// Token: 0x04013427 RID: 78887
		private IDictionary<string, PropertyMetadata> properties;
	}
}
