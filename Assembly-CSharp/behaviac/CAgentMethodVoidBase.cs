using System;

namespace behaviac
{
	// Token: 0x020047BD RID: 18365
	public class CAgentMethodVoidBase : IMethod, IInstanceMember
	{
		// Token: 0x0601A627 RID: 108071 RVA: 0x006D766D File Offset: 0x006D5A6D
		public CAgentMethodVoidBase()
		{
		}

		// Token: 0x0601A628 RID: 108072 RVA: 0x006D7680 File Offset: 0x006D5A80
		public CAgentMethodVoidBase(CAgentMethodVoidBase rhs)
		{
			this._instance = rhs._instance;
		}

		// Token: 0x0601A629 RID: 108073 RVA: 0x006D769F File Offset: 0x006D5A9F
		public virtual IMethod Clone()
		{
			return null;
		}

		// Token: 0x0601A62A RID: 108074 RVA: 0x006D76A2 File Offset: 0x006D5AA2
		public virtual void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
		}

		// Token: 0x0601A62B RID: 108075 RVA: 0x006D76AB File Offset: 0x006D5AAB
		public int GetCount(Agent self)
		{
			return 0;
		}

		// Token: 0x0601A62C RID: 108076 RVA: 0x006D76AE File Offset: 0x006D5AAE
		public void SetValue(Agent self, IInstanceMember right, int index)
		{
		}

		// Token: 0x0601A62D RID: 108077 RVA: 0x006D76B0 File Offset: 0x006D5AB0
		public virtual void Run(Agent self)
		{
		}

		// Token: 0x0601A62E RID: 108078 RVA: 0x006D76B2 File Offset: 0x006D5AB2
		public IValue GetIValue(Agent self)
		{
			return null;
		}

		// Token: 0x0601A62F RID: 108079 RVA: 0x006D76B5 File Offset: 0x006D5AB5
		public object GetValueObject(Agent self)
		{
			return null;
		}

		// Token: 0x0601A630 RID: 108080 RVA: 0x006D76B8 File Offset: 0x006D5AB8
		public IValue GetIValue(Agent self, IInstanceMember firstParam)
		{
			return this.GetIValue(self);
		}

		// Token: 0x0601A631 RID: 108081 RVA: 0x006D76C1 File Offset: 0x006D5AC1
		public void SetValue(Agent self, IValue value)
		{
		}

		// Token: 0x0601A632 RID: 108082 RVA: 0x006D76C3 File Offset: 0x006D5AC3
		public void SetValue(Agent self, object value)
		{
		}

		// Token: 0x0601A633 RID: 108083 RVA: 0x006D76C5 File Offset: 0x006D5AC5
		public void SetValueAs(Agent self, IInstanceMember right)
		{
		}

		// Token: 0x0601A634 RID: 108084 RVA: 0x006D76C7 File Offset: 0x006D5AC7
		public void SetValue(Agent self, IInstanceMember right)
		{
		}

		// Token: 0x0601A635 RID: 108085 RVA: 0x006D76C9 File Offset: 0x006D5AC9
		public bool Compare(Agent self, IInstanceMember right, EOperatorType comparisonType)
		{
			return false;
		}

		// Token: 0x0601A636 RID: 108086 RVA: 0x006D76CC File Offset: 0x006D5ACC
		public void Compute(Agent self, IInstanceMember right1, IInstanceMember right2, EOperatorType computeType)
		{
		}

		// Token: 0x0601A637 RID: 108087 RVA: 0x006D76CE File Offset: 0x006D5ACE
		public virtual void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x04012813 RID: 75795
		protected string _instance = "Self";
	}
}
