using System;

namespace behaviac
{
	// Token: 0x02004767 RID: 18279
	public interface IProperty
	{
		// Token: 0x1700226D RID: 8813
		// (get) Token: 0x0601A466 RID: 107622
		string Name { get; }

		// Token: 0x0601A467 RID: 107623
		void SetValue(Agent self, IInstanceMember right);

		// Token: 0x0601A468 RID: 107624
		void SetValueFromString(Agent self, string valueStr);

		// Token: 0x0601A469 RID: 107625
		object GetValueObject(Agent self);

		// Token: 0x0601A46A RID: 107626
		object GetValueObject(Agent self, int index);

		// Token: 0x0601A46B RID: 107627
		IInstanceMember CreateInstance(string instance, IInstanceMember indexMember);

		// Token: 0x0601A46C RID: 107628
		IValue CreateIValue();
	}
}
