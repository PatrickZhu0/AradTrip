using System;

namespace behaviac
{
	// Token: 0x020047E2 RID: 18402
	public class CAgentStaticMethodVoid<P1, P2, P3> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6EC RID: 108268 RVA: 0x0082F4A9 File Offset: 0x0082D8A9
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6ED RID: 108269 RVA: 0x0082F4B8 File Offset: 0x0082D8B8
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
		}

		// Token: 0x0601A6EE RID: 108270 RVA: 0x0082F4F1 File Offset: 0x0082D8F1
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3>(this);
		}

		// Token: 0x0601A6EF RID: 108271 RVA: 0x0082F4F9 File Offset: 0x0082D8F9
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
		}

		// Token: 0x0601A6F0 RID: 108272 RVA: 0x0082F52C File Offset: 0x0082D92C
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x0601A6F1 RID: 108273 RVA: 0x0082F56C File Offset: 0x0082D96C
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			treeTask.SetVariable<P3>(variableName, ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x04012892 RID: 75922
		private CAgentStaticMethodVoid<P1, P2, P3>.FunctionPointer _fp;

		// Token: 0x04012893 RID: 75923
		private IInstanceMember _p1;

		// Token: 0x04012894 RID: 75924
		private IInstanceMember _p2;

		// Token: 0x04012895 RID: 75925
		private IInstanceMember _p3;

		// Token: 0x020047E3 RID: 18403
		// (Invoke) Token: 0x0601A6F3 RID: 108275
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3);
	}
}
