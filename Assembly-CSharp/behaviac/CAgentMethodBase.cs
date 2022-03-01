using System;

namespace behaviac
{
	// Token: 0x02004780 RID: 18304
	public class CAgentMethodBase<T> : CInstanceMember<T>, IMethod, IInstanceMember
	{
		// Token: 0x0601A4F0 RID: 107760 RVA: 0x006D777C File Offset: 0x006D5B7C
		protected CAgentMethodBase()
		{
			this._returnValue = new TValue<T>(default(T));
		}

		// Token: 0x0601A4F1 RID: 107761 RVA: 0x006D77A3 File Offset: 0x006D5BA3
		protected CAgentMethodBase(CAgentMethodBase<T> rhs)
		{
			this._returnValue = rhs._returnValue.Clone();
		}

		// Token: 0x0601A4F2 RID: 107762 RVA: 0x006D77BC File Offset: 0x006D5BBC
		public virtual IMethod Clone()
		{
			return null;
		}

		// Token: 0x0601A4F3 RID: 107763 RVA: 0x006D77BF File Offset: 0x006D5BBF
		public virtual void Load(string instance, string[] paramStrs)
		{
		}

		// Token: 0x0601A4F4 RID: 107764 RVA: 0x006D77C1 File Offset: 0x006D5BC1
		public override void Run(Agent self)
		{
		}

		// Token: 0x0601A4F5 RID: 107765 RVA: 0x006D77C3 File Offset: 0x006D5BC3
		public override T GetValue(Agent self)
		{
			if (!object.ReferenceEquals(self, null))
			{
				this.Run(self);
			}
			return this._returnValue.value;
		}

		// Token: 0x0601A4F6 RID: 107766 RVA: 0x006D77E3 File Offset: 0x006D5BE3
		public virtual IValue GetIValue(Agent self)
		{
			if (!object.ReferenceEquals(self, null))
			{
				this.Run(self);
			}
			return this._returnValue;
		}

		// Token: 0x0601A4F7 RID: 107767 RVA: 0x006D7800 File Offset: 0x006D5C00
		public virtual IValue GetIValue(Agent self, IInstanceMember firstParam)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			firstParam.Run(parentAgent);
			return this.GetIValue(self);
		}

		// Token: 0x0601A4F8 RID: 107768 RVA: 0x006D7828 File Offset: 0x006D5C28
		public virtual void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x04012722 RID: 75554
		protected TValue<T> _returnValue;
	}
}
