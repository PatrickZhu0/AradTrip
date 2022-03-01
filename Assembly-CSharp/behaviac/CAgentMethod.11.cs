using System;

namespace behaviac
{
	// Token: 0x02004795 RID: 18325
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> : CAgentMethodBase<T>
	{
		// Token: 0x0601A55E RID: 107870 RVA: 0x0082837F File Offset: 0x0082677F
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A55F RID: 107871 RVA: 0x00828390 File Offset: 0x00826790
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10> rhs) : base(rhs)
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

		// Token: 0x0601A560 RID: 107872 RVA: 0x00828428 File Offset: 0x00826828
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>(this);
		}

		// Token: 0x0601A561 RID: 107873 RVA: 0x00828430 File Offset: 0x00826830
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

		// Token: 0x0601A562 RID: 107874 RVA: 0x008284D4 File Offset: 0x008268D4
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self));
		}

		// Token: 0x0601A563 RID: 107875 RVA: 0x008285B0 File Offset: 0x008269B0
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

		// Token: 0x0401275A RID: 75610
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>.FunctionPointer _fp;

		// Token: 0x0401275B RID: 75611
		private IInstanceMember _p1;

		// Token: 0x0401275C RID: 75612
		private IInstanceMember _p2;

		// Token: 0x0401275D RID: 75613
		private IInstanceMember _p3;

		// Token: 0x0401275E RID: 75614
		private IInstanceMember _p4;

		// Token: 0x0401275F RID: 75615
		private IInstanceMember _p5;

		// Token: 0x04012760 RID: 75616
		private IInstanceMember _p6;

		// Token: 0x04012761 RID: 75617
		private IInstanceMember _p7;

		// Token: 0x04012762 RID: 75618
		private IInstanceMember _p8;

		// Token: 0x04012763 RID: 75619
		private IInstanceMember _p9;

		// Token: 0x04012764 RID: 75620
		private IInstanceMember _p10;

		// Token: 0x02004796 RID: 18326
		// (Invoke) Token: 0x0601A565 RID: 107877
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10);
	}
}
