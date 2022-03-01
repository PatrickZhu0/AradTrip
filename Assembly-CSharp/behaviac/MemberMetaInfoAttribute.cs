using System;
using System.Reflection;

namespace behaviac
{
	// Token: 0x0200475C RID: 18268
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class MemberMetaInfoAttribute : TypeMetaInfoAttribute
	{
		// Token: 0x0601A428 RID: 107560 RVA: 0x008261BE File Offset: 0x008245BE
		public MemberMetaInfoAttribute(string displayName, string description, bool bReadOnly) : this(displayName, description)
		{
			this.m_bIsReadonly = bReadOnly;
		}

		// Token: 0x0601A429 RID: 107561 RVA: 0x008261CF File Offset: 0x008245CF
		public MemberMetaInfoAttribute(string displayName, string description) : this(displayName, description, 1f)
		{
		}

		// Token: 0x0601A42A RID: 107562 RVA: 0x008261DE File Offset: 0x008245DE
		public MemberMetaInfoAttribute(string displayName, string description, float range)
		{
			this.m_range = 1f;
			base..ctor(displayName, description);
			this.m_range = range;
		}

		// Token: 0x0601A42B RID: 107563 RVA: 0x008261FA File Offset: 0x008245FA
		public MemberMetaInfoAttribute()
		{
			this.m_range = 1f;
			base..ctor();
		}

		// Token: 0x0601A42C RID: 107564 RVA: 0x0082620D File Offset: 0x0082460D
		public MemberMetaInfoAttribute(bool bReadonly) : this()
		{
			this.m_bIsReadonly = bReadonly;
		}

		// Token: 0x17002266 RID: 8806
		// (get) Token: 0x0601A42D RID: 107565 RVA: 0x0082621C File Offset: 0x0082461C
		public bool IsReadonly
		{
			get
			{
				return this.m_bIsReadonly;
			}
		}

		// Token: 0x0601A42E RID: 107566 RVA: 0x00826224 File Offset: 0x00824624
		private static string getEnumName(object obj)
		{
			if (obj == null)
			{
				return string.Empty;
			}
			Type type = obj.GetType();
			if (!type.IsEnum)
			{
				return string.Empty;
			}
			string name = Enum.GetName(type, obj);
			if (string.IsNullOrEmpty(name))
			{
				return string.Empty;
			}
			return name;
		}

		// Token: 0x0601A42F RID: 107567 RVA: 0x00826270 File Offset: 0x00824670
		public static string GetEnumDisplayName(object obj)
		{
			if (obj == null)
			{
				return string.Empty;
			}
			string result = MemberMetaInfoAttribute.getEnumName(obj);
			FieldInfo field = obj.GetType().GetField(obj.ToString());
			Attribute[] array = (Attribute[])field.GetCustomAttributes(typeof(MemberMetaInfoAttribute), false);
			if (array.Length > 0)
			{
				result = ((MemberMetaInfoAttribute)array[0]).DisplayName;
			}
			return result;
		}

		// Token: 0x0601A430 RID: 107568 RVA: 0x008262D4 File Offset: 0x008246D4
		public static string GetEnumDescription(object obj)
		{
			if (obj == null)
			{
				return string.Empty;
			}
			string result = MemberMetaInfoAttribute.getEnumName(obj);
			FieldInfo field = obj.GetType().GetField(obj.ToString());
			Attribute[] array = (Attribute[])field.GetCustomAttributes(typeof(MemberMetaInfoAttribute), false);
			if (array.Length > 0)
			{
				result = ((MemberMetaInfoAttribute)array[0]).Description;
			}
			return result;
		}

		// Token: 0x17002267 RID: 8807
		// (get) Token: 0x0601A431 RID: 107569 RVA: 0x00826335 File Offset: 0x00824735
		public float Range
		{
			get
			{
				return this.m_range;
			}
		}

		// Token: 0x040126F8 RID: 75512
		private bool m_bIsReadonly;

		// Token: 0x040126F9 RID: 75513
		private float m_range;
	}
}
