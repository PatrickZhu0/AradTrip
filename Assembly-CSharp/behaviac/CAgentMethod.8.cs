using System;

namespace behaviac
{
	// Token: 0x0200478F RID: 18319
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7> : CAgentMethodBase<T>
	{
		// Token: 0x0601A540 RID: 107840 RVA: 0x00827981 File Offset: 0x00825D81
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A541 RID: 107841 RVA: 0x00827990 File Offset: 0x00825D90
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
			this._p7 = rhs._p7;
		}

		// Token: 0x0601A542 RID: 107842 RVA: 0x00827A04 File Offset: 0x00825E04
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7>(this);
		}

		// Token: 0x0601A543 RID: 107843 RVA: 0x00827A0C File Offset: 0x00825E0C
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
		}

		// Token: 0x0601A544 RID: 107844 RVA: 0x00827A84 File Offset: 0x00825E84
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self));
		}

		// Token: 0x0601A545 RID: 107845 RVA: 0x00827B2C File Offset: 0x00825F2C
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
		}

		// Token: 0x0401273F RID: 75583
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7>.FunctionPointer _fp;

		// Token: 0x04012740 RID: 75584
		private IInstanceMember _p1;

		// Token: 0x04012741 RID: 75585
		private IInstanceMember _p2;

		// Token: 0x04012742 RID: 75586
		private IInstanceMember _p3;

		// Token: 0x04012743 RID: 75587
		private IInstanceMember _p4;

		// Token: 0x04012744 RID: 75588
		private IInstanceMember _p5;

		// Token: 0x04012745 RID: 75589
		private IInstanceMember _p6;

		// Token: 0x04012746 RID: 75590
		private IInstanceMember _p7;

		// Token: 0x02004790 RID: 18320
		// (Invoke) Token: 0x0601A547 RID: 107847
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);
	}
}
