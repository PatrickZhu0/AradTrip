using System;

namespace behaviac
{
	// Token: 0x02004787 RID: 18311
	public class CAgentMethod<T, P1, P2, P3> : CAgentMethodBase<T>
	{
		// Token: 0x0601A518 RID: 107800 RVA: 0x00827125 File Offset: 0x00825525
		public CAgentMethod(CAgentMethod<T, P1, P2, P3>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A519 RID: 107801 RVA: 0x00827134 File Offset: 0x00825534
		public CAgentMethod(CAgentMethod<T, P1, P2, P3> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
		}

		// Token: 0x0601A51A RID: 107802 RVA: 0x0082716D File Offset: 0x0082556D
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3>(this);
		}

		// Token: 0x0601A51B RID: 107803 RVA: 0x00827175 File Offset: 0x00825575
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
		}

		// Token: 0x0601A51C RID: 107804 RVA: 0x008271A8 File Offset: 0x008255A8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x0601A51D RID: 107805 RVA: 0x0082720C File Offset: 0x0082560C
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			treeTask.SetVariable<P3>(variableName, ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x04012729 RID: 75561
		private CAgentMethod<T, P1, P2, P3>.FunctionPointer _fp;

		// Token: 0x0401272A RID: 75562
		private IInstanceMember _p1;

		// Token: 0x0401272B RID: 75563
		private IInstanceMember _p2;

		// Token: 0x0401272C RID: 75564
		private IInstanceMember _p3;

		// Token: 0x02004788 RID: 18312
		// (Invoke) Token: 0x0601A51F RID: 107807
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3);
	}
}
