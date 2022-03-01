using System;

namespace behaviac
{
	// Token: 0x0200477E RID: 18302
	public class CInstanceConst<T> : CInstanceMember<T>
	{
		// Token: 0x0601A4E8 RID: 107752 RVA: 0x006D7481 File Offset: 0x006D5881
		public CInstanceConst(string typeName, string valueStr)
		{
			this._value = (T)((object)AgentMeta.ParseTypeValue(typeName, valueStr));
		}

		// Token: 0x0601A4E9 RID: 107753 RVA: 0x006D749B File Offset: 0x006D589B
		public override T GetValue(Agent self)
		{
			return this._value;
		}

		// Token: 0x0601A4EA RID: 107754 RVA: 0x006D74A3 File Offset: 0x006D58A3
		public override void SetValue(Agent self, T value)
		{
			this._value = value;
		}

		// Token: 0x04012721 RID: 75553
		protected T _value;
	}
}
