using System;

namespace behaviac
{
	// Token: 0x0200478B RID: 18315
	public class CAgentMethod<T, P1, P2, P3, P4, P5> : CAgentMethodBase<T>
	{
		// Token: 0x0601A52C RID: 107820 RVA: 0x00827495 File Offset: 0x00825895
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A52D RID: 107821 RVA: 0x008274A4 File Offset: 0x008258A4
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
		}

		// Token: 0x0601A52E RID: 107822 RVA: 0x00827500 File Offset: 0x00825900
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5>(this);
		}

		// Token: 0x0601A52F RID: 107823 RVA: 0x00827508 File Offset: 0x00825908
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
		}

		// Token: 0x0601A530 RID: 107824 RVA: 0x00827564 File Offset: 0x00825964
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self));
		}

		// Token: 0x0601A531 RID: 107825 RVA: 0x008275EC File Offset: 0x008259EC
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 4);
			treeTask.SetVariable<P5>(variableName, ((CInstanceMember<P5>)this._p5).GetValue(self));
		}

		// Token: 0x04012732 RID: 75570
		private CAgentMethod<T, P1, P2, P3, P4, P5>.FunctionPointer _fp;

		// Token: 0x04012733 RID: 75571
		private IInstanceMember _p1;

		// Token: 0x04012734 RID: 75572
		private IInstanceMember _p2;

		// Token: 0x04012735 RID: 75573
		private IInstanceMember _p3;

		// Token: 0x04012736 RID: 75574
		private IInstanceMember _p4;

		// Token: 0x04012737 RID: 75575
		private IInstanceMember _p5;

		// Token: 0x0200478C RID: 18316
		// (Invoke) Token: 0x0601A533 RID: 107827
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
	}
}
