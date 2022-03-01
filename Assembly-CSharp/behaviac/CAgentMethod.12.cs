using System;

namespace behaviac
{
	// Token: 0x02004797 RID: 18327
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> : CAgentMethodBase<T>
	{
		// Token: 0x0601A568 RID: 107880 RVA: 0x0082878A File Offset: 0x00826B8A
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A569 RID: 107881 RVA: 0x0082879C File Offset: 0x00826B9C
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11> rhs) : base(rhs)
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

		// Token: 0x0601A56A RID: 107882 RVA: 0x00828840 File Offset: 0x00826C40
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>(this);
		}

		// Token: 0x0601A56B RID: 107883 RVA: 0x00828848 File Offset: 0x00826C48
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

		// Token: 0x0601A56C RID: 107884 RVA: 0x008288F8 File Offset: 0x00826CF8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self));
		}

		// Token: 0x0601A56D RID: 107885 RVA: 0x008289E4 File Offset: 0x00826DE4
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

		// Token: 0x04012765 RID: 75621
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>.FunctionPointer _fp;

		// Token: 0x04012766 RID: 75622
		private IInstanceMember _p1;

		// Token: 0x04012767 RID: 75623
		private IInstanceMember _p2;

		// Token: 0x04012768 RID: 75624
		private IInstanceMember _p3;

		// Token: 0x04012769 RID: 75625
		private IInstanceMember _p4;

		// Token: 0x0401276A RID: 75626
		private IInstanceMember _p5;

		// Token: 0x0401276B RID: 75627
		private IInstanceMember _p6;

		// Token: 0x0401276C RID: 75628
		private IInstanceMember _p7;

		// Token: 0x0401276D RID: 75629
		private IInstanceMember _p8;

		// Token: 0x0401276E RID: 75630
		private IInstanceMember _p9;

		// Token: 0x0401276F RID: 75631
		private IInstanceMember _p10;

		// Token: 0x04012770 RID: 75632
		private IInstanceMember _p11;

		// Token: 0x02004798 RID: 18328
		// (Invoke) Token: 0x0601A56F RID: 107887
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11);
	}
}
