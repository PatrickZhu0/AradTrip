using System;

namespace behaviac
{
	// Token: 0x0200478D RID: 18317
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6> : CAgentMethodBase<T>
	{
		// Token: 0x0601A536 RID: 107830 RVA: 0x008276DF File Offset: 0x00825ADF
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A537 RID: 107831 RVA: 0x008276F0 File Offset: 0x00825AF0
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
		}

		// Token: 0x0601A538 RID: 107832 RVA: 0x00827758 File Offset: 0x00825B58
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6>(this);
		}

		// Token: 0x0601A539 RID: 107833 RVA: 0x00827760 File Offset: 0x00825B60
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
			this._p6 = AgentMeta.ParseProperty<P6>(paramStrs[5]);
		}

		// Token: 0x0601A53A RID: 107834 RVA: 0x008277C8 File Offset: 0x00825BC8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self));
		}

		// Token: 0x0601A53B RID: 107835 RVA: 0x00827860 File Offset: 0x00825C60
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
		}

		// Token: 0x04012738 RID: 75576
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6>.FunctionPointer _fp;

		// Token: 0x04012739 RID: 75577
		private IInstanceMember _p1;

		// Token: 0x0401273A RID: 75578
		private IInstanceMember _p2;

		// Token: 0x0401273B RID: 75579
		private IInstanceMember _p3;

		// Token: 0x0401273C RID: 75580
		private IInstanceMember _p4;

		// Token: 0x0401273D RID: 75581
		private IInstanceMember _p5;

		// Token: 0x0401273E RID: 75582
		private IInstanceMember _p6;

		// Token: 0x0200478E RID: 18318
		// (Invoke) Token: 0x0601A53D RID: 107837
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);
	}
}
