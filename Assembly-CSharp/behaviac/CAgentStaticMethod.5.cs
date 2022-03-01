using System;

namespace behaviac
{
	// Token: 0x020047A7 RID: 18343
	public class CAgentStaticMethod<T, P1, P2, P3, P4> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5B9 RID: 107961 RVA: 0x00829EEB File Offset: 0x008282EB
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5BA RID: 107962 RVA: 0x00829EFC File Offset: 0x008282FC
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
		}

		// Token: 0x0601A5BB RID: 107963 RVA: 0x00829F4C File Offset: 0x0082834C
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4>(this);
		}

		// Token: 0x0601A5BC RID: 107964 RVA: 0x00829F54 File Offset: 0x00828354
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
		}

		// Token: 0x0601A5BD RID: 107965 RVA: 0x00829FA0 File Offset: 0x008283A0
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self));
		}

		// Token: 0x0601A5BE RID: 107966 RVA: 0x0082A008 File Offset: 0x00828408
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
		}

		// Token: 0x040127A5 RID: 75685
		private CAgentStaticMethod<T, P1, P2, P3, P4>.FunctionPointer _fp;

		// Token: 0x040127A6 RID: 75686
		private IInstanceMember _p1;

		// Token: 0x040127A7 RID: 75687
		private IInstanceMember _p2;

		// Token: 0x040127A8 RID: 75688
		private IInstanceMember _p3;

		// Token: 0x040127A9 RID: 75689
		private IInstanceMember _p4;

		// Token: 0x020047A8 RID: 18344
		// (Invoke) Token: 0x0601A5C0 RID: 107968
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4);
	}
}
