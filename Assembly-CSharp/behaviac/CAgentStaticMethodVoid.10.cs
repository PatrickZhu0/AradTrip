using System;

namespace behaviac
{
	// Token: 0x020047EE RID: 18414
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9> : CAgentMethodVoidBase
	{
		// Token: 0x0601A728 RID: 108328 RVA: 0x008302B1 File Offset: 0x0082E6B1
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A729 RID: 108329 RVA: 0x008302C0 File Offset: 0x0082E6C0
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9> rhs) : base(rhs)
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
		}

		// Token: 0x0601A72A RID: 108330 RVA: 0x0083034C File Offset: 0x0082E74C
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9>(this);
		}

		// Token: 0x0601A72B RID: 108331 RVA: 0x00830354 File Offset: 0x0082E754
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
		}

		// Token: 0x0601A72C RID: 108332 RVA: 0x008303E8 File Offset: 0x0082E7E8
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self));
		}

		// Token: 0x0601A72D RID: 108333 RVA: 0x0083049C File Offset: 0x0082E89C
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
		}

		// Token: 0x040128B9 RID: 75961
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer _fp;

		// Token: 0x040128BA RID: 75962
		private IInstanceMember _p1;

		// Token: 0x040128BB RID: 75963
		private IInstanceMember _p2;

		// Token: 0x040128BC RID: 75964
		private IInstanceMember _p3;

		// Token: 0x040128BD RID: 75965
		private IInstanceMember _p4;

		// Token: 0x040128BE RID: 75966
		private IInstanceMember _p5;

		// Token: 0x040128BF RID: 75967
		private IInstanceMember _p6;

		// Token: 0x040128C0 RID: 75968
		private IInstanceMember _p7;

		// Token: 0x040128C1 RID: 75969
		private IInstanceMember _p8;

		// Token: 0x040128C2 RID: 75970
		private IInstanceMember _p9;

		// Token: 0x020047EF RID: 18415
		// (Invoke) Token: 0x0601A72F RID: 108335
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9);
	}
}
