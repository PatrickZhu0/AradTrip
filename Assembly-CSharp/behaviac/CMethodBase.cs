using System;
using System.Reflection;

namespace behaviac
{
	// Token: 0x02004832 RID: 18482
	public class CMethodBase
	{
		// Token: 0x0601A8E5 RID: 108773 RVA: 0x00835D3C File Offset: 0x0083413C
		public CMethodBase(MethodBase m, MethodMetaInfoAttribute a, string methodNameOverride)
		{
			this.method_ = m;
			this.descAttrbute_ = a;
			this.m_variableName = (string.IsNullOrEmpty(methodNameOverride) ? this.method_.Name : methodNameOverride);
			this.m_id.SetId(this.m_variableName);
		}

		// Token: 0x0601A8E6 RID: 108774 RVA: 0x00835DA0 File Offset: 0x008341A0
		protected CMethodBase(CMethodBase copy)
		{
			this.m_variableName = copy.m_variableName;
			this.method_ = copy.method_;
			this.descAttrbute_ = copy.descAttrbute_;
			this.m_id = copy.m_id;
		}

		// Token: 0x17002288 RID: 8840
		// (get) Token: 0x0601A8E7 RID: 108775 RVA: 0x00835DF2 File Offset: 0x008341F2
		public string Name
		{
			get
			{
				return this.m_variableName;
			}
		}

		// Token: 0x0601A8E8 RID: 108776 RVA: 0x00835DFA File Offset: 0x008341FA
		public CStringID GetId()
		{
			return this.m_id;
		}

		// Token: 0x0601A8E9 RID: 108777 RVA: 0x00835E02 File Offset: 0x00834202
		public virtual bool IsNamedEvent()
		{
			return false;
		}

		// Token: 0x0601A8EA RID: 108778 RVA: 0x00835E05 File Offset: 0x00834205
		public virtual CMethodBase clone()
		{
			return new CMethodBase(this);
		}

		// Token: 0x0401294B RID: 76107
		private MethodMetaInfoAttribute descAttrbute_;

		// Token: 0x0401294C RID: 76108
		private MethodBase method_;

		// Token: 0x0401294D RID: 76109
		protected string m_variableName;

		// Token: 0x0401294E RID: 76110
		private CStringID m_id = default(CStringID);
	}
}
