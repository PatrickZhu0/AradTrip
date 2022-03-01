using System;

namespace behaviac
{
	// Token: 0x02004766 RID: 18278
	public interface IInstanceMember
	{
		// Token: 0x0601A45D RID: 107613
		int GetCount(Agent self);

		// Token: 0x0601A45E RID: 107614
		void SetValue(Agent self, IInstanceMember right, int index);

		// Token: 0x0601A45F RID: 107615
		object GetValueObject(Agent self);

		// Token: 0x0601A460 RID: 107616
		void SetValue(Agent self, object value);

		// Token: 0x0601A461 RID: 107617
		void SetValue(Agent self, IInstanceMember right);

		// Token: 0x0601A462 RID: 107618
		void SetValueAs(Agent self, IInstanceMember right);

		// Token: 0x0601A463 RID: 107619
		bool Compare(Agent self, IInstanceMember right, EOperatorType comparisonType);

		// Token: 0x0601A464 RID: 107620
		void Compute(Agent self, IInstanceMember right1, IInstanceMember right2, EOperatorType computeType);

		// Token: 0x0601A465 RID: 107621
		void Run(Agent self);
	}
}
