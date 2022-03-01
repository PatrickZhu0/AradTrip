using System;

namespace behaviac
{
	// Token: 0x02004791 RID: 18321
	public class CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8> : CAgentMethodBase<T>
	{
		// Token: 0x0601A54A RID: 107850 RVA: 0x00827C7B File Offset: 0x0082607B
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A54B RID: 107851 RVA: 0x00827C8C File Offset: 0x0082608C
		public CAgentMethod(CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8> rhs) : base(rhs)
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
		}

		// Token: 0x0601A54C RID: 107852 RVA: 0x00827D0C File Offset: 0x0082610C
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8>(this);
		}

		// Token: 0x0601A54D RID: 107853 RVA: 0x00827D14 File Offset: 0x00826114
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
		}

		// Token: 0x0601A54E RID: 107854 RVA: 0x00827D98 File Offset: 0x00826198
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self));
		}

		// Token: 0x0601A54F RID: 107855 RVA: 0x00827E54 File Offset: 0x00826254
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
		}

		// Token: 0x04012747 RID: 75591
		private CAgentMethod<T, P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer _fp;

		// Token: 0x04012748 RID: 75592
		private IInstanceMember _p1;

		// Token: 0x04012749 RID: 75593
		private IInstanceMember _p2;

		// Token: 0x0401274A RID: 75594
		private IInstanceMember _p3;

		// Token: 0x0401274B RID: 75595
		private IInstanceMember _p4;

		// Token: 0x0401274C RID: 75596
		private IInstanceMember _p5;

		// Token: 0x0401274D RID: 75597
		private IInstanceMember _p6;

		// Token: 0x0401274E RID: 75598
		private IInstanceMember _p7;

		// Token: 0x0401274F RID: 75599
		private IInstanceMember _p8;

		// Token: 0x02004792 RID: 18322
		// (Invoke) Token: 0x0601A551 RID: 107857
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8);
	}
}
