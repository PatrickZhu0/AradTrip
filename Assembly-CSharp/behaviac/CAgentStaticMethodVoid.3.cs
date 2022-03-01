using System;

namespace behaviac
{
	// Token: 0x020047E0 RID: 18400
	public class CAgentStaticMethodVoid<P1, P2> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6E2 RID: 108258 RVA: 0x0082F3A7 File Offset: 0x0082D7A7
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6E3 RID: 108259 RVA: 0x0082F3B6 File Offset: 0x0082D7B6
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
		}

		// Token: 0x0601A6E4 RID: 108260 RVA: 0x0082F3E3 File Offset: 0x0082D7E3
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2>(this);
		}

		// Token: 0x0601A6E5 RID: 108261 RVA: 0x0082F3EB File Offset: 0x0082D7EB
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
		}

		// Token: 0x0601A6E6 RID: 108262 RVA: 0x0082F410 File Offset: 0x0082D810
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0601A6E7 RID: 108263 RVA: 0x0082F440 File Offset: 0x0082D840
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0401288F RID: 75919
		private CAgentStaticMethodVoid<P1, P2>.FunctionPointer _fp;

		// Token: 0x04012890 RID: 75920
		private IInstanceMember _p1;

		// Token: 0x04012891 RID: 75921
		private IInstanceMember _p2;

		// Token: 0x020047E1 RID: 18401
		// (Invoke) Token: 0x0601A6E9 RID: 108265
		public delegate void FunctionPointer(P1 p1, P2 p2);
	}
}
