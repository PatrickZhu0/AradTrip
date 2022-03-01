using System;

namespace behaviac
{
	// Token: 0x02004778 RID: 18296
	public interface IInstantiatedVariable
	{
		// Token: 0x0601A4B8 RID: 107704
		object GetValueObject(Agent self);

		// Token: 0x0601A4B9 RID: 107705
		object GetValueObject(Agent self, int index);

		// Token: 0x0601A4BA RID: 107706
		void SetValueFromString(Agent self, string valueStr);

		// Token: 0x0601A4BB RID: 107707
		void SetValue(Agent self, object value);

		// Token: 0x0601A4BC RID: 107708
		void SetValue(Agent self, object value, int index);

		// Token: 0x1700226F RID: 8815
		// (get) Token: 0x0601A4BD RID: 107709
		string Name { get; }

		// Token: 0x0601A4BE RID: 107710
		void Log(Agent self);

		// Token: 0x0601A4BF RID: 107711
		IInstantiatedVariable clone();

		// Token: 0x0601A4C0 RID: 107712
		void CopyTo(Agent pAgent);

		// Token: 0x0601A4C1 RID: 107713
		void Save(ISerializableNode node);
	}
}
