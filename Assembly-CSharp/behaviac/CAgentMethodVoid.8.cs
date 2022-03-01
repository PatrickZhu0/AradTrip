using System;

namespace behaviac
{
	// Token: 0x020047CC RID: 18380
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7> : CAgentMethodVoidBase
	{
		// Token: 0x0601A67E RID: 108158 RVA: 0x0082D155 File Offset: 0x0082B555
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A67F RID: 108159 RVA: 0x0082D164 File Offset: 0x0082B564
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
			this._p7 = rhs._p7;
		}

		// Token: 0x0601A680 RID: 108160 RVA: 0x0082D1D8 File Offset: 0x0082B5D8
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7>(this);
		}

		// Token: 0x0601A681 RID: 108161 RVA: 0x0082D1E0 File Offset: 0x0082B5E0
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
			this._p6 = AgentMeta.ParseProperty<P6>(paramStrs[5]);
			this._p7 = AgentMeta.ParseProperty<P7>(paramStrs[6]);
		}

		// Token: 0x0601A682 RID: 108162 RVA: 0x0082D258 File Offset: 0x0082B658
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self));
		}

		// Token: 0x0601A683 RID: 108163 RVA: 0x0082D2F8 File Offset: 0x0082B6F8
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 6);
			treeTask.SetVariable<P7>(variableName, ((CInstanceMember<P7>)this._p7).GetValue(self));
		}

		// Token: 0x04012830 RID: 75824
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7>.FunctionPointer _fp;

		// Token: 0x04012831 RID: 75825
		private IInstanceMember _p1;

		// Token: 0x04012832 RID: 75826
		private IInstanceMember _p2;

		// Token: 0x04012833 RID: 75827
		private IInstanceMember _p3;

		// Token: 0x04012834 RID: 75828
		private IInstanceMember _p4;

		// Token: 0x04012835 RID: 75829
		private IInstanceMember _p5;

		// Token: 0x04012836 RID: 75830
		private IInstanceMember _p6;

		// Token: 0x04012837 RID: 75831
		private IInstanceMember _p7;

		// Token: 0x020047CD RID: 18381
		// (Invoke) Token: 0x0601A685 RID: 108165
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);
	}
}
