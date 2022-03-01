using System;

namespace behaviac
{
	// Token: 0x020047B5 RID: 18357
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5FF RID: 108031 RVA: 0x0082B36E File Offset: 0x0082976E
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A600 RID: 108032 RVA: 0x0082B380 File Offset: 0x00829780
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> rhs) : base(rhs)
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

		// Token: 0x0601A601 RID: 108033 RVA: 0x0082B424 File Offset: 0x00829824
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(this);
		}

		// Token: 0x0601A602 RID: 108034 RVA: 0x0082B42C File Offset: 0x0082982C
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

		// Token: 0x0601A603 RID: 108035 RVA: 0x0082B4DC File Offset: 0x008298DC
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self));
		}

		// Token: 0x0601A604 RID: 108036 RVA: 0x0082B5BC File Offset: 0x008299BC
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

		// Token: 0x040127DD RID: 75741
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer _fp;

		// Token: 0x040127DE RID: 75742
		private IInstanceMember _p1;

		// Token: 0x040127DF RID: 75743
		private IInstanceMember _p2;

		// Token: 0x040127E0 RID: 75744
		private IInstanceMember _p3;

		// Token: 0x040127E1 RID: 75745
		private IInstanceMember _p4;

		// Token: 0x040127E2 RID: 75746
		private IInstanceMember _p5;

		// Token: 0x040127E3 RID: 75747
		private IInstanceMember _p6;

		// Token: 0x040127E4 RID: 75748
		private IInstanceMember _p7;

		// Token: 0x040127E5 RID: 75749
		private IInstanceMember _p8;

		// Token: 0x040127E6 RID: 75750
		private IInstanceMember _p9;

		// Token: 0x040127E7 RID: 75751
		private IInstanceMember _p10;

		// Token: 0x040127E8 RID: 75752
		private IInstanceMember _p11;

		// Token: 0x020047B6 RID: 18358
		// (Invoke) Token: 0x0601A606 RID: 108038
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);
	}
}
