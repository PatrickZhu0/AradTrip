using System;

namespace behaviac
{
	// Token: 0x0200482E RID: 18478
	public struct CStringID
	{
		// Token: 0x0601A8D8 RID: 108760 RVA: 0x00835C64 File Offset: 0x00834064
		public CStringID(string str)
		{
			this.m_id = CRC32.CalcCRC(str);
		}

		// Token: 0x0601A8D9 RID: 108761 RVA: 0x00835C72 File Offset: 0x00834072
		public void SetId(string str)
		{
			this.m_id = CRC32.CalcCRC(str);
		}

		// Token: 0x0601A8DA RID: 108762 RVA: 0x00835C80 File Offset: 0x00834080
		public uint GetId()
		{
			return this.m_id;
		}

		// Token: 0x0601A8DB RID: 108763 RVA: 0x00835C88 File Offset: 0x00834088
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is CStringID)
			{
				CStringID cstringID = (CStringID)obj;
				return this.m_id == cstringID.m_id;
			}
			if (obj is string)
			{
				CStringID cstringID2 = new CStringID((string)obj);
				return this.m_id == cstringID2.m_id;
			}
			return false;
		}

		// Token: 0x0601A8DC RID: 108764 RVA: 0x00835CE8 File Offset: 0x008340E8
		public bool Equals(CStringID p)
		{
			return p != null && this.m_id == p.m_id;
		}

		// Token: 0x0601A8DD RID: 108765 RVA: 0x00835D06 File Offset: 0x00834106
		public override int GetHashCode()
		{
			return (int)this.m_id;
		}

		// Token: 0x0601A8DE RID: 108766 RVA: 0x00835D0E File Offset: 0x0083410E
		public static bool operator ==(CStringID a, CStringID b)
		{
			return a.m_id == b.m_id;
		}

		// Token: 0x0601A8DF RID: 108767 RVA: 0x00835D20 File Offset: 0x00834120
		public static bool operator !=(CStringID a, CStringID b)
		{
			return a.m_id != b.m_id;
		}

		// Token: 0x0401294A RID: 76106
		private uint m_id;
	}
}
