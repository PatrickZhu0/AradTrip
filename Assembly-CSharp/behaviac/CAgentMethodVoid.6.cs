using System;

namespace behaviac
{
	// Token: 0x020047C8 RID: 18376
	public class CAgentMethodVoid<P1, P2, P3, P4, P5> : CAgentMethodVoidBase
	{
		// Token: 0x0601A66A RID: 108138 RVA: 0x0082CC81 File Offset: 0x0082B081
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A66B RID: 108139 RVA: 0x0082CC90 File Offset: 0x0082B090
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
		}

		// Token: 0x0601A66C RID: 108140 RVA: 0x0082CCEC File Offset: 0x0082B0EC
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5>(this);
		}

		// Token: 0x0601A66D RID: 108141 RVA: 0x0082CCF4 File Offset: 0x0082B0F4
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
		}

		// Token: 0x0601A66E RID: 108142 RVA: 0x0082CD50 File Offset: 0x0082B150
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self));
		}

		// Token: 0x0601A66F RID: 108143 RVA: 0x0082CDCC File Offset: 0x0082B1CC
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

		// Token: 0x04012823 RID: 75811
		private CAgentMethodVoid<P1, P2, P3, P4, P5>.FunctionPointer _fp;

		// Token: 0x04012824 RID: 75812
		private IInstanceMember _p1;

		// Token: 0x04012825 RID: 75813
		private IInstanceMember _p2;

		// Token: 0x04012826 RID: 75814
		private IInstanceMember _p3;

		// Token: 0x04012827 RID: 75815
		private IInstanceMember _p4;

		// Token: 0x04012828 RID: 75816
		private IInstanceMember _p5;

		// Token: 0x020047C9 RID: 18377
		// (Invoke) Token: 0x0601A671 RID: 108145
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
	}
}
