using System;

namespace behaviac
{
	// Token: 0x020047D2 RID: 18386
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> : CAgentMethodVoidBase
	{
		// Token: 0x0601A69C RID: 108188 RVA: 0x0082DB33 File Offset: 0x0082BF33
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A69D RID: 108189 RVA: 0x0082DB44 File Offset: 0x0082BF44
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> rhs) : base(rhs)
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
		}

		// Token: 0x0601A69E RID: 108190 RVA: 0x0082DBDC File Offset: 0x0082BFDC
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(this);
		}

		// Token: 0x0601A69F RID: 108191 RVA: 0x0082DBE4 File Offset: 0x0082BFE4
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
		}

		// Token: 0x0601A6A0 RID: 108192 RVA: 0x0082DC88 File Offset: 0x0082C088
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self));
		}

		// Token: 0x0601A6A1 RID: 108193 RVA: 0x0082DD58 File Offset: 0x0082C158
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
		}

		// Token: 0x0401284B RID: 75851
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.FunctionPointer _fp;

		// Token: 0x0401284C RID: 75852
		private IInstanceMember _p1;

		// Token: 0x0401284D RID: 75853
		private IInstanceMember _p2;

		// Token: 0x0401284E RID: 75854
		private IInstanceMember _p3;

		// Token: 0x0401284F RID: 75855
		private IInstanceMember _p4;

		// Token: 0x04012850 RID: 75856
		private IInstanceMember _p5;

		// Token: 0x04012851 RID: 75857
		private IInstanceMember _p6;

		// Token: 0x04012852 RID: 75858
		private IInstanceMember _p7;

		// Token: 0x04012853 RID: 75859
		private IInstanceMember _p8;

		// Token: 0x04012854 RID: 75860
		private IInstanceMember _p9;

		// Token: 0x04012855 RID: 75861
		private IInstanceMember _p10;

		// Token: 0x020047D3 RID: 18387
		// (Invoke) Token: 0x0601A6A3 RID: 108195
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10);
	}
}
