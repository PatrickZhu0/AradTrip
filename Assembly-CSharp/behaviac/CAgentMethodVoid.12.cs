using System;

namespace behaviac
{
	// Token: 0x020047D4 RID: 18388
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6A6 RID: 108198 RVA: 0x0082DF32 File Offset: 0x0082C332
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6A7 RID: 108199 RVA: 0x0082DF44 File Offset: 0x0082C344
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
			this._p7 = rhs._p7;
			this._p8 = rhs._p8;
			this._p9 = rhs._p9;
			this._p10 = rhs._p10;
			this._p11 = rhs._p11;
		}

		// Token: 0x0601A6A8 RID: 108200 RVA: 0x0082DFE8 File Offset: 0x0082C3E8
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(this);
		}

		// Token: 0x0601A6A9 RID: 108201 RVA: 0x0082DFF0 File Offset: 0x0082C3F0
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
			this._p8 = AgentMeta.ParseProperty<P8>(paramStrs[7]);
			this._p9 = AgentMeta.ParseProperty<P9>(paramStrs[8]);
			this._p10 = AgentMeta.ParseProperty<P10>(paramStrs[9]);
			this._p11 = AgentMeta.ParseProperty<P11>(paramStrs[10]);
		}

		// Token: 0x0601A6AA RID: 108202 RVA: 0x0082E0A0 File Offset: 0x0082C4A0
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self));
		}

		// Token: 0x0601A6AB RID: 108203 RVA: 0x0082E184 File Offset: 0x0082C584
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 7);
			treeTask.SetVariable<P8>(variableName, ((CInstanceMember<P8>)this._p8).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 8);
			treeTask.SetVariable<P9>(variableName, ((CInstanceMember<P9>)this._p9).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 9);
			treeTask.SetVariable<P10>(variableName, ((CInstanceMember<P10>)this._p10).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 10);
			treeTask.SetVariable<P11>(variableName, ((CInstanceMember<P11>)this._p11).GetValue(self));
		}

		// Token: 0x04012856 RID: 75862
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer _fp;

		// Token: 0x04012857 RID: 75863
		private IInstanceMember _p1;

		// Token: 0x04012858 RID: 75864
		private IInstanceMember _p2;

		// Token: 0x04012859 RID: 75865
		private IInstanceMember _p3;

		// Token: 0x0401285A RID: 75866
		private IInstanceMember _p4;

		// Token: 0x0401285B RID: 75867
		private IInstanceMember _p5;

		// Token: 0x0401285C RID: 75868
		private IInstanceMember _p6;

		// Token: 0x0401285D RID: 75869
		private IInstanceMember _p7;

		// Token: 0x0401285E RID: 75870
		private IInstanceMember _p8;

		// Token: 0x0401285F RID: 75871
		private IInstanceMember _p9;

		// Token: 0x04012860 RID: 75872
		private IInstanceMember _p10;

		// Token: 0x04012861 RID: 75873
		private IInstanceMember _p11;

		// Token: 0x020047D5 RID: 18389
		// (Invoke) Token: 0x0601A6AD RID: 108205
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);
	}
}
