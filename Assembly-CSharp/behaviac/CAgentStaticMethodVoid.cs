using System;

namespace behaviac
{
	// Token: 0x020047DC RID: 18396
	public class CAgentStaticMethodVoid : CAgentMethodVoidBase
	{
		// Token: 0x0601A6CE RID: 108238 RVA: 0x0082F2BA File Offset: 0x0082D6BA
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6CF RID: 108239 RVA: 0x0082F2C9 File Offset: 0x0082D6C9
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid rhs) : base(rhs)
		{
			this._fp = rhs._fp;
		}

		// Token: 0x0601A6D0 RID: 108240 RVA: 0x0082F2DE File Offset: 0x0082D6DE
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid(this);
		}

		// Token: 0x0601A6D1 RID: 108241 RVA: 0x0082F2E6 File Offset: 0x0082D6E6
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
		}

		// Token: 0x0601A6D2 RID: 108242 RVA: 0x0082F2EF File Offset: 0x0082D6EF
		public override void Run(Agent self)
		{
			this._fp();
		}

		// Token: 0x0601A6D3 RID: 108243 RVA: 0x0082F2FC File Offset: 0x0082D6FC
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x0401288C RID: 75916
		private CAgentStaticMethodVoid.FunctionPointer _fp;

		// Token: 0x020047DD RID: 18397
		// (Invoke) Token: 0x0601A6D5 RID: 108245
		public delegate void FunctionPointer();
	}
}
