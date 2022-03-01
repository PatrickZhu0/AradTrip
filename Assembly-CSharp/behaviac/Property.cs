using System;

namespace behaviac
{
	// Token: 0x0200482C RID: 18476
	public class Property
	{
		// Token: 0x0601A8BF RID: 108735 RVA: 0x008359E8 File Offset: 0x00833DE8
		public Property(CMemberBase pMemberBase, bool bIsConst)
		{
			this.m_memberBase = pMemberBase;
			this.m_variableId = 0U;
			this.m_bValidDefaultValue = false;
			this.m_bIsConst = bIsConst;
		}

		// Token: 0x0601A8C0 RID: 108736 RVA: 0x00835A0C File Offset: 0x00833E0C
		protected Property(Property copy)
		{
			this.m_variableName = copy.m_variableName;
			this.m_instanceName = copy.m_instanceName;
			this.m_variableId = copy.m_variableId;
			this.m_memberBase = copy.m_memberBase;
			this.m_parent = copy.m_parent;
			this.m_index = copy.m_index;
			this.m_bValidDefaultValue = copy.m_bValidDefaultValue;
			this.m_defaultValue = copy.m_defaultValue;
			this.m_bIsConst = copy.m_bIsConst;
			this.m_bIsStatic = copy.m_bIsStatic;
			this.m_bIsLocal = copy.m_bIsLocal;
			this.m_strNativeTypeName = copy.m_strNativeTypeName;
		}

		// Token: 0x17002280 RID: 8832
		// (get) Token: 0x0601A8C1 RID: 108737 RVA: 0x00835AAF File Offset: 0x00833EAF
		// (set) Token: 0x0601A8C2 RID: 108738 RVA: 0x00835AB7 File Offset: 0x00833EB7
		public IProperty BindingProperty
		{
			get
			{
				return this.m_bindingProperty;
			}
			set
			{
				this.m_bindingProperty = value;
			}
		}

		// Token: 0x17002281 RID: 8833
		// (get) Token: 0x0601A8C3 RID: 108739 RVA: 0x00835AC0 File Offset: 0x00833EC0
		// (set) Token: 0x0601A8C4 RID: 108740 RVA: 0x00835AC8 File Offset: 0x00833EC8
		public string Name
		{
			get
			{
				return this.m_variableName;
			}
			set
			{
				this.m_variableName = value;
				this.m_variableId = Utils.MakeVariableId(this.m_variableName);
			}
		}

		// Token: 0x17002282 RID: 8834
		// (get) Token: 0x0601A8C5 RID: 108741 RVA: 0x00835AE2 File Offset: 0x00833EE2
		// (set) Token: 0x0601A8C6 RID: 108742 RVA: 0x00835B17 File Offset: 0x00833F17
		public string InstanceName
		{
			get
			{
				if (!string.IsNullOrEmpty(this.m_instanceName))
				{
					return this.m_instanceName;
				}
				return (this.m_memberBase == null) ? null : this.m_memberBase.InstanceName;
			}
			set
			{
				this.m_instanceName = value;
			}
		}

		// Token: 0x17002283 RID: 8835
		// (get) Token: 0x0601A8C7 RID: 108743 RVA: 0x00835B20 File Offset: 0x00833F20
		public uint VariableId
		{
			get
			{
				return this.m_variableId;
			}
		}

		// Token: 0x17002284 RID: 8836
		// (get) Token: 0x0601A8C8 RID: 108744 RVA: 0x00835B28 File Offset: 0x00833F28
		// (set) Token: 0x0601A8C9 RID: 108745 RVA: 0x00835B30 File Offset: 0x00833F30
		public bool IsStatic
		{
			get
			{
				return this.m_bIsStatic;
			}
			set
			{
				this.m_bIsStatic = value;
			}
		}

		// Token: 0x17002285 RID: 8837
		// (get) Token: 0x0601A8CA RID: 108746 RVA: 0x00835B39 File Offset: 0x00833F39
		// (set) Token: 0x0601A8CB RID: 108747 RVA: 0x00835B41 File Offset: 0x00833F41
		public bool IsLocal
		{
			get
			{
				return this.m_bIsLocal;
			}
			set
			{
				this.m_bIsLocal = value;
			}
		}

		// Token: 0x17002286 RID: 8838
		// (get) Token: 0x0601A8CC RID: 108748 RVA: 0x00835B4A File Offset: 0x00833F4A
		public Type PropertyType
		{
			get
			{
				if (this.m_defaultValue != null)
				{
					return this.m_defaultValue.GetType();
				}
				if (this.m_memberBase != null)
				{
					return this.m_memberBase.MemberType;
				}
				return null;
			}
		}

		// Token: 0x17002287 RID: 8839
		// (get) Token: 0x0601A8CD RID: 108749 RVA: 0x00835B7B File Offset: 0x00833F7B
		// (set) Token: 0x0601A8CE RID: 108750 RVA: 0x00835B83 File Offset: 0x00833F83
		public string NativeTypeName
		{
			get
			{
				return this.m_strNativeTypeName;
			}
			set
			{
				this.m_strNativeTypeName = Utils.GetNativeTypeName(value).Replace("::", ".");
			}
		}

		// Token: 0x0601A8CF RID: 108751 RVA: 0x00835BA0 File Offset: 0x00833FA0
		public float GetRange()
		{
			if (this.m_memberBase != null)
			{
				return this.m_memberBase.GetRange();
			}
			return 1f;
		}

		// Token: 0x0601A8D0 RID: 108752 RVA: 0x00835BC0 File Offset: 0x00833FC0
		public virtual Property clone()
		{
			return new Property(this);
		}

		// Token: 0x0601A8D1 RID: 108753 RVA: 0x00835BD5 File Offset: 0x00833FD5
		public static void Cleanup()
		{
		}

		// Token: 0x0401293B RID: 76091
		private IProperty m_bindingProperty;

		// Token: 0x0401293C RID: 76092
		private bool m_bIsStatic;

		// Token: 0x0401293D RID: 76093
		private bool m_bIsLocal;

		// Token: 0x0401293E RID: 76094
		private string m_strNativeTypeName;

		// Token: 0x0401293F RID: 76095
		protected string m_variableName;

		// Token: 0x04012940 RID: 76096
		protected string m_instanceName;

		// Token: 0x04012941 RID: 76097
		protected uint m_variableId;

		// Token: 0x04012942 RID: 76098
		protected Property m_parent;

		// Token: 0x04012943 RID: 76099
		protected Property m_index;

		// Token: 0x04012944 RID: 76100
		protected readonly CMemberBase m_memberBase;

		// Token: 0x04012945 RID: 76101
		protected object m_defaultValue;

		// Token: 0x04012946 RID: 76102
		private bool m_bValidDefaultValue;

		// Token: 0x04012947 RID: 76103
		protected readonly bool m_bIsConst;
	}
}
