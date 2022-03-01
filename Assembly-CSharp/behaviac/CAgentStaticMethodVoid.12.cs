using System;

namespace behaviac
{
	// Token: 0x020047F2 RID: 18418
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> : CAgentMethodVoidBase
	{
		// Token: 0x0601A73C RID: 108348 RVA: 0x00830A3A File Offset: 0x0082EE3A
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A73D RID: 108349 RVA: 0x00830A4C File Offset: 0x0082EE4C
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> rhs) : base(rhs)
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

		// Token: 0x0601A73E RID: 108350 RVA: 0x00830AF0 File Offset: 0x0082EEF0
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(this);
		}

		// Token: 0x0601A73F RID: 108351 RVA: 0x00830AF8 File Offset: 0x0082EEF8
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

		// Token: 0x0601A740 RID: 108352 RVA: 0x00830BA8 File Offset: 0x0082EFA8
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self));
		}

		// Token: 0x0601A741 RID: 108353 RVA: 0x00830C7C File Offset: 0x0082F07C
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

		// Token: 0x040128CE RID: 75982
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer _fp;

		// Token: 0x040128CF RID: 75983
		private IInstanceMember _p1;

		// Token: 0x040128D0 RID: 75984
		private IInstanceMember _p2;

		// Token: 0x040128D1 RID: 75985
		private IInstanceMember _p3;

		// Token: 0x040128D2 RID: 75986
		private IInstanceMember _p4;

		// Token: 0x040128D3 RID: 75987
		private IInstanceMember _p5;

		// Token: 0x040128D4 RID: 75988
		private IInstanceMember _p6;

		// Token: 0x040128D5 RID: 75989
		private IInstanceMember _p7;

		// Token: 0x040128D6 RID: 75990
		private IInstanceMember _p8;

		// Token: 0x040128D7 RID: 75991
		private IInstanceMember _p9;

		// Token: 0x040128D8 RID: 75992
		private IInstanceMember _p10;

		// Token: 0x040128D9 RID: 75993
		private IInstanceMember _p11;

		// Token: 0x020047F3 RID: 18419
		// (Invoke) Token: 0x0601A743 RID: 108355
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);
	}
}
