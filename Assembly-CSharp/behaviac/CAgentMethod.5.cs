using System;

namespace behaviac
{
	// Token: 0x02004789 RID: 18313
	public class CAgentMethod<T, P1, P2, P3, P4> : CAgentMethodBase<T>
	{
		// Token: 0x0601A522 RID: 107810 RVA: 0x008272A3 File Offset: 0x008256A3
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A523 RID: 107811 RVA: 0x008272B4 File Offset: 0x008256B4
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
		}

		// Token: 0x0601A524 RID: 107812 RVA: 0x00827304 File Offset: 0x00825704
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4>(this);
		}

		// Token: 0x0601A525 RID: 107813 RVA: 0x0082730C File Offset: 0x0082570C
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
		}

		// Token: 0x0601A526 RID: 107814 RVA: 0x00827358 File Offset: 0x00825758
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self));
		}

		// Token: 0x0601A527 RID: 107815 RVA: 0x008273D0 File Offset: 0x008257D0
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

		// Token: 0x0401272D RID: 75565
		private CAgentMethod<T, P1, P2, P3, P4>.FunctionPointer _fp;

		// Token: 0x0401272E RID: 75566
		private IInstanceMember _p1;

		// Token: 0x0401272F RID: 75567
		private IInstanceMember _p2;

		// Token: 0x04012730 RID: 75568
		private IInstanceMember _p3;

		// Token: 0x04012731 RID: 75569
		private IInstanceMember _p4;

		// Token: 0x0200478A RID: 18314
		// (Invoke) Token: 0x0601A529 RID: 107817
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4);
	}
}
