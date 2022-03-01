using System;

namespace behaviac
{
	// Token: 0x020047EC RID: 18412
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8> : CAgentMethodVoidBase
	{
		// Token: 0x0601A71E RID: 108318 RVA: 0x0082FF77 File Offset: 0x0082E377
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A71F RID: 108319 RVA: 0x0082FF88 File Offset: 0x0082E388
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8> rhs) : base(rhs)
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
		}

		// Token: 0x0601A720 RID: 108320 RVA: 0x00830008 File Offset: 0x0082E408
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>(this);
		}

		// Token: 0x0601A721 RID: 108321 RVA: 0x00830010 File Offset: 0x0082E410
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
		}

		// Token: 0x0601A722 RID: 108322 RVA: 0x00830094 File Offset: 0x0082E494
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self));
		}

		// Token: 0x0601A723 RID: 108323 RVA: 0x00830134 File Offset: 0x0082E534
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
		}

		// Token: 0x040128B0 RID: 75952
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer _fp;

		// Token: 0x040128B1 RID: 75953
		private IInstanceMember _p1;

		// Token: 0x040128B2 RID: 75954
		private IInstanceMember _p2;

		// Token: 0x040128B3 RID: 75955
		private IInstanceMember _p3;

		// Token: 0x040128B4 RID: 75956
		private IInstanceMember _p4;

		// Token: 0x040128B5 RID: 75957
		private IInstanceMember _p5;

		// Token: 0x040128B6 RID: 75958
		private IInstanceMember _p6;

		// Token: 0x040128B7 RID: 75959
		private IInstanceMember _p7;

		// Token: 0x040128B8 RID: 75960
		private IInstanceMember _p8;

		// Token: 0x020047ED RID: 18413
		// (Invoke) Token: 0x0601A725 RID: 108325
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8);
	}
}
