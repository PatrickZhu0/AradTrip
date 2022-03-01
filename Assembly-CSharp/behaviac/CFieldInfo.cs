using System;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004834 RID: 18484
	public class CFieldInfo : CMemberBase
	{
		// Token: 0x0601A8F9 RID: 108793 RVA: 0x00835EB0 File Offset: 0x008342B0
		public CFieldInfo(FieldInfo f, MemberMetaInfoAttribute a) : base(f.Name, a)
		{
			this.field_ = f;
		}

		// Token: 0x1700228C RID: 8844
		// (get) Token: 0x0601A8FA RID: 108794 RVA: 0x00835EC6 File Offset: 0x008342C6
		public override Type MemberType
		{
			get
			{
				return this.field_.FieldType;
			}
		}

		// Token: 0x0601A8FB RID: 108795 RVA: 0x00835ED3 File Offset: 0x008342D3
		public override bool ISSTATIC()
		{
			return this.field_.IsStatic;
		}

		// Token: 0x0601A8FC RID: 108796 RVA: 0x00835EE0 File Offset: 0x008342E0
		public override string GetClassNameString()
		{
			return this.field_.DeclaringType.FullName;
		}

		// Token: 0x0601A8FD RID: 108797 RVA: 0x00835EF2 File Offset: 0x008342F2
		public override object Get(object agentFrom)
		{
			if (this.ISSTATIC())
			{
				return this.field_.GetValue(null);
			}
			return this.field_.GetValue(agentFrom);
		}

		// Token: 0x0601A8FE RID: 108798 RVA: 0x00835F18 File Offset: 0x00834318
		public override void Set(object objectFrom, object v)
		{
			this.field_.SetValue(objectFrom, v);
		}

		// Token: 0x04012953 RID: 76115
		protected FieldInfo field_;
	}
}
