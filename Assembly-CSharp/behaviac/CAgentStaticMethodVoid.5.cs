using System;

namespace behaviac
{
	// Token: 0x020047E4 RID: 18404
	public class CAgentStaticMethodVoid<P1, P2, P3, P4> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6F6 RID: 108278 RVA: 0x0082F603 File Offset: 0x0082DA03
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4>.FunctionPointer f, IInstanceMember p1, IInstanceMember p2, IInstanceMember p3, IInstanceMember p4)
		{
			this._fp = f;
		}

		// Token: 0x0601A6F7 RID: 108279 RVA: 0x0082F614 File Offset: 0x0082DA14
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
		}

		// Token: 0x0601A6F8 RID: 108280 RVA: 0x0082F664 File Offset: 0x0082DA64
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4>(this);
		}

		// Token: 0x0601A6F9 RID: 108281 RVA: 0x0082F66C File Offset: 0x0082DA6C
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
		}

		// Token: 0x0601A6FA RID: 108282 RVA: 0x0082F6B8 File Offset: 0x0082DAB8
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self));
		}

		// Token: 0x0601A6FB RID: 108283 RVA: 0x0082F714 File Offset: 0x0082DB14
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			treeTask.SetVariable<P3>(variableName, ((CInstanceMember<P3>)this._p3).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 3);
			treeTask.SetVariable<P4>(variableName, ((CInstanceMember<P4>)this._p4).GetValue(self));
		}

		// Token: 0x04012896 RID: 75926
		private CAgentStaticMethodVoid<P1, P2, P3, P4>.FunctionPointer _fp;

		// Token: 0x04012897 RID: 75927
		private IInstanceMember _p1;

		// Token: 0x04012898 RID: 75928
		private IInstanceMember _p2;

		// Token: 0x04012899 RID: 75929
		private IInstanceMember _p3;

		// Token: 0x0401289A RID: 75930
		private IInstanceMember _p4;

		// Token: 0x020047E5 RID: 18405
		// (Invoke) Token: 0x0601A6FD RID: 108285
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4);
	}
}
