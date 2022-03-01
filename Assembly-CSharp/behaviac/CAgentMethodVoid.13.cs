using System;

namespace behaviac
{
	// Token: 0x020047D6 RID: 18390
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6B0 RID: 108208 RVA: 0x0082E38D File Offset: 0x0082C78D
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6B1 RID: 108209 RVA: 0x0082E39C File Offset: 0x0082C79C
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> rhs) : base(rhs)
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

		// Token: 0x0601A6B2 RID: 108210 RVA: 0x0082E44C File Offset: 0x0082C84C
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(this);
		}

		// Token: 0x0601A6B3 RID: 108211 RVA: 0x0082E454 File Offset: 0x0082C854
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

		// Token: 0x0601A6B4 RID: 108212 RVA: 0x0082E514 File Offset: 0x0082C914
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self), ((CInstanceMember<P12>)this._p12).GetValue(self));
		}

		// Token: 0x0601A6B5 RID: 108213 RVA: 0x0082E608 File Offset: 0x0082CA08
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

		// Token: 0x04012862 RID: 75874
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer _fp;

		// Token: 0x04012863 RID: 75875
		private IInstanceMember _p1;

		// Token: 0x04012864 RID: 75876
		private IInstanceMember _p2;

		// Token: 0x04012865 RID: 75877
		private IInstanceMember _p3;

		// Token: 0x04012866 RID: 75878
		private IInstanceMember _p4;

		// Token: 0x04012867 RID: 75879
		private IInstanceMember _p5;

		// Token: 0x04012868 RID: 75880
		private IInstanceMember _p6;

		// Token: 0x04012869 RID: 75881
		private IInstanceMember _p7;

		// Token: 0x0401286A RID: 75882
		private IInstanceMember _p8;

		// Token: 0x0401286B RID: 75883
		private IInstanceMember _p9;

		// Token: 0x0401286C RID: 75884
		private IInstanceMember _p10;

		// Token: 0x0401286D RID: 75885
		private IInstanceMember _p11;

		// Token: 0x0401286E RID: 75886
		private IInstanceMember _p12;

		// Token: 0x020047D7 RID: 18391
		// (Invoke) Token: 0x0601A6B7 RID: 108215
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12);
	}
}
