using System;

namespace behaviac
{
	// Token: 0x02004833 RID: 18483
	public class CMemberBase
	{
		// Token: 0x0601A8EB RID: 108779 RVA: 0x00835E10 File Offset: 0x00834210
		public CMemberBase(string name, MemberMetaInfoAttribute a)
		{
			this.m_name = name;
			this.m_id.SetId(name);
			if (a != null)
			{
				this.m_range = a.Range;
			}
			else
			{
				this.m_range = 1f;
			}
		}

		// Token: 0x17002289 RID: 8841
		// (get) Token: 0x0601A8EC RID: 108780 RVA: 0x00835E72 File Offset: 0x00834272
		public virtual Type MemberType
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0601A8ED RID: 108781 RVA: 0x00835E75 File Offset: 0x00834275
		public virtual bool ISSTATIC()
		{
			return false;
		}

		// Token: 0x0601A8EE RID: 108782 RVA: 0x00835E78 File Offset: 0x00834278
		public float GetRange()
		{
			return this.m_range;
		}

		// Token: 0x0601A8EF RID: 108783 RVA: 0x00835E80 File Offset: 0x00834280
		public CStringID GetId()
		{
			return this.m_id;
		}

		// Token: 0x1700228A RID: 8842
		// (get) Token: 0x0601A8F0 RID: 108784 RVA: 0x00835E88 File Offset: 0x00834288
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x0601A8F1 RID: 108785 RVA: 0x00835E90 File Offset: 0x00834290
		public virtual string GetClassNameString()
		{
			return null;
		}

		// Token: 0x1700228B RID: 8843
		// (get) Token: 0x0601A8F2 RID: 108786 RVA: 0x00835E93 File Offset: 0x00834293
		// (set) Token: 0x0601A8F3 RID: 108787 RVA: 0x00835E9B File Offset: 0x0083429B
		public string InstanceName
		{
			get
			{
				return this.m_instanceName;
			}
			set
			{
				this.m_instanceName = value;
			}
		}

		// Token: 0x0601A8F4 RID: 108788 RVA: 0x00835EA4 File Offset: 0x008342A4
		public virtual int GetTypeId()
		{
			return 0;
		}

		// Token: 0x0601A8F5 RID: 108789 RVA: 0x00835EA7 File Offset: 0x008342A7
		public virtual void Load(Agent parent, ISerializableNode node)
		{
		}

		// Token: 0x0601A8F6 RID: 108790 RVA: 0x00835EA9 File Offset: 0x008342A9
		public virtual void Save(Agent parent, ISerializableNode node)
		{
		}

		// Token: 0x0601A8F7 RID: 108791 RVA: 0x00835EAB File Offset: 0x008342AB
		public virtual object Get(object agentFrom)
		{
			return null;
		}

		// Token: 0x0601A8F8 RID: 108792 RVA: 0x00835EAE File Offset: 0x008342AE
		public virtual void Set(object objectFrom, object v)
		{
		}

		// Token: 0x0401294F RID: 76111
		protected string m_name;

		// Token: 0x04012950 RID: 76112
		private float m_range = 1f;

		// Token: 0x04012951 RID: 76113
		private CStringID m_id = default(CStringID);

		// Token: 0x04012952 RID: 76114
		private string m_instanceName;
	}
}
