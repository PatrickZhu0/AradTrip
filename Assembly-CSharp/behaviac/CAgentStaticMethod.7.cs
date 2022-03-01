using System;

namespace behaviac
{
	// Token: 0x020047AB RID: 18347
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5CD RID: 107981 RVA: 0x0082A307 File Offset: 0x00828707
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5CE RID: 107982 RVA: 0x0082A318 File Offset: 0x00828718
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
		}

		// Token: 0x0601A5CF RID: 107983 RVA: 0x0082A380 File Offset: 0x00828780
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6>(this);
		}

		// Token: 0x0601A5D0 RID: 107984 RVA: 0x0082A388 File Offset: 0x00828788
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

		// Token: 0x0601A5D1 RID: 107985 RVA: 0x0082A3F0 File Offset: 0x008287F0
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self));
		}

		// Token: 0x0601A5D2 RID: 107986 RVA: 0x0082A47C File Offset: 0x0082887C
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

		// Token: 0x040127B0 RID: 75696
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6>.FunctionPointer _fp;

		// Token: 0x040127B1 RID: 75697
		private IInstanceMember _p1;

		// Token: 0x040127B2 RID: 75698
		private IInstanceMember _p2;

		// Token: 0x040127B3 RID: 75699
		private IInstanceMember _p3;

		// Token: 0x040127B4 RID: 75700
		private IInstanceMember _p4;

		// Token: 0x040127B5 RID: 75701
		private IInstanceMember _p5;

		// Token: 0x040127B6 RID: 75702
		private IInstanceMember _p6;

		// Token: 0x020047AC RID: 18348
		// (Invoke) Token: 0x0601A5D4 RID: 107988
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);
	}
}
