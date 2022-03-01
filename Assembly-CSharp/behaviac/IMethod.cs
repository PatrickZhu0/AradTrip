using System;

namespace behaviac
{
	// Token: 0x0200477F RID: 18303
	public interface IMethod : IInstanceMember
	{
		// Token: 0x0601A4EB RID: 107755
		IMethod Clone();

		// Token: 0x0601A4EC RID: 107756
		void Load(string instance, string[] paramStrs);

		// Token: 0x0601A4ED RID: 107757
		IValue GetIValue(Agent self);

		// Token: 0x0601A4EE RID: 107758
		IValue GetIValue(Agent self, IInstanceMember firstParam);

		// Token: 0x0601A4EF RID: 107759
		void SetTaskParams(Agent self, BehaviorTreeTask treeTask);
	}
}
