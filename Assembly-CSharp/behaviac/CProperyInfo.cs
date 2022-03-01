using System;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004835 RID: 18485
	public class CProperyInfo : CMemberBase
	{
		// Token: 0x0601A8FF RID: 108799 RVA: 0x00835F27 File Offset: 0x00834327
		public CProperyInfo(PropertyInfo p, MemberMetaInfoAttribute a) : base(p.Name, a)
		{
			this.property_ = p;
		}

		// Token: 0x0601A900 RID: 108800 RVA: 0x00835F3D File Offset: 0x0083433D
		private static MethodInfo getGetMethod(PropertyInfo property)
		{
			return property.GetGetMethod();
		}

		// Token: 0x0601A901 RID: 108801 RVA: 0x00835F45 File Offset: 0x00834345
		private static MethodInfo getSetMethod(PropertyInfo property)
		{
			return property.GetSetMethod();
		}

		// Token: 0x1700228D RID: 8845
		// (get) Token: 0x0601A902 RID: 108802 RVA: 0x00835F4D File Offset: 0x0083434D
		public override Type MemberType
		{
			get
			{
				return this.property_.PropertyType;
			}
		}

		// Token: 0x0601A903 RID: 108803 RVA: 0x00835F5A File Offset: 0x0083435A
		public override string GetClassNameString()
		{
			return this.property_.DeclaringType.FullName;
		}

		// Token: 0x0601A904 RID: 108804 RVA: 0x00835F6C File Offset: 0x0083436C
		public override object Get(object agentFrom)
		{
			if (this.ISSTATIC())
			{
				MethodInfo getMethod = CProperyInfo.getGetMethod(this.property_);
				if (getMethod != null)
				{
					return getMethod.Invoke(null, null);
				}
			}
			else
			{
				MethodInfo getMethod2 = CProperyInfo.getGetMethod(this.property_);
				if (getMethod2 != null)
				{
					return getMethod2.Invoke(agentFrom, null);
				}
			}
			return null;
		}

		// Token: 0x0601A905 RID: 108805 RVA: 0x00835FC0 File Offset: 0x008343C0
		public override void Set(object objectFrom, object v)
		{
			MethodInfo setMethod = CProperyInfo.getSetMethod(this.property_);
			if (setMethod != null)
			{
				setMethod.Invoke(objectFrom, new object[]
				{
					v
				});
			}
		}

		// Token: 0x04012954 RID: 76116
		private PropertyInfo property_;
	}
}
