using System;

namespace behaviac
{
	// Token: 0x0200475A RID: 18266
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
	public class TypeMetaInfoAttribute : Attribute
	{
		// Token: 0x0601A420 RID: 107552 RVA: 0x00826154 File Offset: 0x00824554
		public TypeMetaInfoAttribute(string displayName, string description)
		{
			this.displayName_ = displayName;
			this.desc_ = description;
		}

		// Token: 0x0601A421 RID: 107553 RVA: 0x0082616A File Offset: 0x0082456A
		public TypeMetaInfoAttribute(string displayName, string description, ERefType refType)
		{
			this.displayName_ = displayName;
			this.desc_ = description;
			this.refType_ = refType;
		}

		// Token: 0x0601A422 RID: 107554 RVA: 0x00826187 File Offset: 0x00824587
		public TypeMetaInfoAttribute()
		{
		}

		// Token: 0x0601A423 RID: 107555 RVA: 0x0082618F File Offset: 0x0082458F
		public TypeMetaInfoAttribute(ERefType refType)
		{
			this.refType_ = refType;
		}

		// Token: 0x17002263 RID: 8803
		// (get) Token: 0x0601A424 RID: 107556 RVA: 0x0082619E File Offset: 0x0082459E
		public string DisplayName
		{
			get
			{
				return this.displayName_;
			}
		}

		// Token: 0x17002264 RID: 8804
		// (get) Token: 0x0601A425 RID: 107557 RVA: 0x008261A6 File Offset: 0x008245A6
		public string Description
		{
			get
			{
				return this.desc_;
			}
		}

		// Token: 0x17002265 RID: 8805
		// (get) Token: 0x0601A426 RID: 107558 RVA: 0x008261AE File Offset: 0x008245AE
		public ERefType RefType
		{
			get
			{
				return this.refType_;
			}
		}

		// Token: 0x040126F5 RID: 75509
		private string displayName_;

		// Token: 0x040126F6 RID: 75510
		private string desc_;

		// Token: 0x040126F7 RID: 75511
		private ERefType refType_;
	}
}
