using System;

namespace behaviac
{
	// Token: 0x020047F4 RID: 18420
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> : CAgentMethodVoidBase
	{
		// Token: 0x0601A746 RID: 108358 RVA: 0x00830E85 File Offset: 0x0082F285
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A747 RID: 108359 RVA: 0x00830E94 File Offset: 0x0082F294
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> rhs) : base(rhs)
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
			this._p12 = rhs._p12;
		}

		// Token: 0x0601A748 RID: 108360 RVA: 0x00830F44 File Offset: 0x0082F344
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(this);
		}

		// Token: 0x0601A749 RID: 108361 RVA: 0x00830F4C File Offset: 0x0082F34C
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
			this._p12 = AgentMeta.ParseProperty<P12>(paramStrs[11]);
		}

		// Token: 0x0601A74A RID: 108362 RVA: 0x0083100C File Offset: 0x0082F40C
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self), ((CInstanceMember<P12>)this._p12).GetValue(self));
		}

		// Token: 0x0601A74B RID: 108363 RVA: 0x008310F0 File Offset: 0x0082F4F0
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 11);
			treeTask.SetVariable<P12>(variableName, ((CInstanceMember<P12>)this._p12).GetValue(self));
		}

		// Token: 0x040128DA RID: 75994
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer _fp;

		// Token: 0x040128DB RID: 75995
		private IInstanceMember _p1;

		// Token: 0x040128DC RID: 75996
		private IInstanceMember _p2;

		// Token: 0x040128DD RID: 75997
		private IInstanceMember _p3;

		// Token: 0x040128DE RID: 75998
		private IInstanceMember _p4;

		// Token: 0x040128DF RID: 75999
		private IInstanceMember _p5;

		// Token: 0x040128E0 RID: 76000
		private IInstanceMember _p6;

		// Token: 0x040128E1 RID: 76001
		private IInstanceMember _p7;

		// Token: 0x040128E2 RID: 76002
		private IInstanceMember _p8;

		// Token: 0x040128E3 RID: 76003
		private IInstanceMember _p9;

		// Token: 0x040128E4 RID: 76004
		private IInstanceMember _p10;

		// Token: 0x040128E5 RID: 76005
		private IInstanceMember _p11;

		// Token: 0x040128E6 RID: 76006
		private IInstanceMember _p12;

		// Token: 0x020047F5 RID: 18421
		// (Invoke) Token: 0x0601A74D RID: 108365
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12);
	}
}
