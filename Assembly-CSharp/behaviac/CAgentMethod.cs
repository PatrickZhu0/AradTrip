using System;

namespace behaviac
{
	// Token: 0x02004781 RID: 18305
	public class CAgentMethod<T> : CAgentMethodBase<T>
	{
		// Token: 0x0601A4F9 RID: 107769 RVA: 0x00826E81 File Offset: 0x00825281
		public CAgentMethod(CAgentMethod<T>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A4FA RID: 107770 RVA: 0x00826E90 File Offset: 0x00825290
		public CAgentMethod(CAgentMethod<T> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
		}

		// Token: 0x0601A4FB RID: 107771 RVA: 0x00826EA5 File Offset: 0x008252A5
		public override IMethod Clone()
		{
			return new CAgentMethod<T>(this);
		}

		// Token: 0x0601A4FC RID: 107772 RVA: 0x00826EAD File Offset: 0x008252AD
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
		}

		// Token: 0x0601A4FD RID: 107773 RVA: 0x00826EB8 File Offset: 0x008252B8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent);
		}

		// Token: 0x0601A4FE RID: 107774 RVA: 0x00826EE9 File Offset: 0x008252E9
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x04012723 RID: 75555
		private CAgentMethod<T>.FunctionPointer _fp;

		// Token: 0x02004782 RID: 18306
		// (Invoke) Token: 0x0601A500 RID: 107776
		public delegate T FunctionPointer(Agent a);
	}
}
