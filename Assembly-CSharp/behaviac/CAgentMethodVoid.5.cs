using System;

namespace behaviac
{
	// Token: 0x020047C6 RID: 18374
	public class CAgentMethodVoid<P1, P2, P3, P4> : CAgentMethodVoidBase
	{
		// Token: 0x0601A660 RID: 108128 RVA: 0x0082CA9B File Offset: 0x0082AE9B
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A661 RID: 108129 RVA: 0x0082CAAC File Offset: 0x0082AEAC
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
		}

		// Token: 0x0601A662 RID: 108130 RVA: 0x0082CAFC File Offset: 0x0082AEFC
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4>(this);
		}

		// Token: 0x0601A663 RID: 108131 RVA: 0x0082CB04 File Offset: 0x0082AF04
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
		}

		// Token: 0x0601A664 RID: 108132 RVA: 0x0082CB50 File Offset: 0x0082AF50
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self));
		}

		// Token: 0x0601A665 RID: 108133 RVA: 0x0082CBBC File Offset: 0x0082AFBC
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

		// Token: 0x0401281E RID: 75806
		private CAgentMethodVoid<P1, P2, P3, P4>.FunctionPointer _fp;

		// Token: 0x0401281F RID: 75807
		private IInstanceMember _p1;

		// Token: 0x04012820 RID: 75808
		private IInstanceMember _p2;

		// Token: 0x04012821 RID: 75809
		private IInstanceMember _p3;

		// Token: 0x04012822 RID: 75810
		private IInstanceMember _p4;

		// Token: 0x020047C7 RID: 18375
		// (Invoke) Token: 0x0601A667 RID: 108135
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4);
	}
}
