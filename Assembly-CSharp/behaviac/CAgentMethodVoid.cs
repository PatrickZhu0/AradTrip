using System;

namespace behaviac
{
	// Token: 0x020047BE RID: 18366
	public class CAgentMethodVoid : CAgentMethodVoidBase
	{
		// Token: 0x0601A638 RID: 108088 RVA: 0x0082C6EA File Offset: 0x0082AAEA
		public CAgentMethodVoid(CAgentMethodVoid.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A639 RID: 108089 RVA: 0x0082C6F9 File Offset: 0x0082AAF9
		public CAgentMethodVoid(CAgentMethodVoid rhs) : base(rhs)
		{
			this._fp = rhs._fp;
		}

		// Token: 0x0601A63A RID: 108090 RVA: 0x0082C70E File Offset: 0x0082AB0E
		public override IMethod Clone()
		{
			return new CAgentMethodVoid(this);
		}

		// Token: 0x0601A63B RID: 108091 RVA: 0x0082C716 File Offset: 0x0082AB16
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
		}

		// Token: 0x0601A63C RID: 108092 RVA: 0x0082C720 File Offset: 0x0082AB20
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent);
		}

		// Token: 0x0601A63D RID: 108093 RVA: 0x0082C746 File Offset: 0x0082AB46
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x04012814 RID: 75796
		private CAgentMethodVoid.FunctionPointer _fp;

		// Token: 0x020047BF RID: 18367
		// (Invoke) Token: 0x0601A63F RID: 108095
		public delegate void FunctionPointer(Agent a);
	}
}
