using System;

namespace behaviac
{
	// Token: 0x02004793 RID: 18323
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9> : CAgentMethodBase<T>
	{
		// Token: 0x0601A554 RID: 107860 RVA: 0x00827FD1 File Offset: 0x008263D1
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A555 RID: 107861 RVA: 0x00827FE0 File Offset: 0x008263E0
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9> rhs) : base(rhs)
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

		// Token: 0x0601A556 RID: 107862 RVA: 0x0082806C File Offset: 0x0082646C
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>(this);
		}

		// Token: 0x0601A557 RID: 107863 RVA: 0x00828074 File Offset: 0x00826474
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

		// Token: 0x0601A558 RID: 107864 RVA: 0x00828108 File Offset: 0x00826508
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self));
		}

		// Token: 0x0601A559 RID: 107865 RVA: 0x008281D4 File Offset: 0x008265D4
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

		// Token: 0x04012750 RID: 75600
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer _fp;

		// Token: 0x04012751 RID: 75601
		private IInstanceMember _p1;

		// Token: 0x04012752 RID: 75602
		private IInstanceMember _p2;

		// Token: 0x04012753 RID: 75603
		private IInstanceMember _p3;

		// Token: 0x04012754 RID: 75604
		private IInstanceMember _p4;

		// Token: 0x04012755 RID: 75605
		private IInstanceMember _p5;

		// Token: 0x04012756 RID: 75606
		private IInstanceMember _p6;

		// Token: 0x04012757 RID: 75607
		private IInstanceMember _p7;

		// Token: 0x04012758 RID: 75608
		private IInstanceMember _p8;

		// Token: 0x04012759 RID: 75609
		private IInstanceMember _p9;

		// Token: 0x02004794 RID: 18324
		// (Invoke) Token: 0x0601A55B RID: 107867
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9);
	}
}
