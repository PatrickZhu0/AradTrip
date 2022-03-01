using System;

namespace behaviac
{
	// Token: 0x020047CA RID: 18378
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6> : CAgentMethodVoidBase
	{
		// Token: 0x0601A674 RID: 108148 RVA: 0x0082CEBF File Offset: 0x0082B2BF
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A675 RID: 108149 RVA: 0x0082CED0 File Offset: 0x0082B2D0
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
		}

		// Token: 0x0601A676 RID: 108150 RVA: 0x0082CF38 File Offset: 0x0082B338
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6>(this);
		}

		// Token: 0x0601A677 RID: 108151 RVA: 0x0082CF40 File Offset: 0x0082B340
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
			this._p6 = AgentMeta.ParseProperty<P6>(paramStrs[5]);
		}

		// Token: 0x0601A678 RID: 108152 RVA: 0x0082CFA8 File Offset: 0x0082B3A8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self));
		}

		// Token: 0x0601A679 RID: 108153 RVA: 0x0082D034 File Offset: 0x0082B434
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 5);
			treeTask.SetVariable<P6>(variableName, ((CInstanceMember<P6>)this._p6).GetValue(self));
		}

		// Token: 0x04012829 RID: 75817
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6>.FunctionPointer _fp;

		// Token: 0x0401282A RID: 75818
		private IInstanceMember _p1;

		// Token: 0x0401282B RID: 75819
		private IInstanceMember _p2;

		// Token: 0x0401282C RID: 75820
		private IInstanceMember _p3;

		// Token: 0x0401282D RID: 75821
		private IInstanceMember _p4;

		// Token: 0x0401282E RID: 75822
		private IInstanceMember _p5;

		// Token: 0x0401282F RID: 75823
		private IInstanceMember _p6;

		// Token: 0x020047CB RID: 18379
		// (Invoke) Token: 0x0601A67B RID: 108155
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);
	}
}
