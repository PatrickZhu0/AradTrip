using System;

namespace behaviac
{
	// Token: 0x020047A3 RID: 18339
	public class CAgentStaticMethod<T, P1, P2> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5A5 RID: 107941 RVA: 0x00829C6B File Offset: 0x0082806B
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5A6 RID: 107942 RVA: 0x00829C7A File Offset: 0x0082807A
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
		}

		// Token: 0x0601A5A7 RID: 107943 RVA: 0x00829CA7 File Offset: 0x008280A7
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2>(this);
		}

		// Token: 0x0601A5A8 RID: 107944 RVA: 0x00829CAF File Offset: 0x008280AF
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
		}

		// Token: 0x0601A5A9 RID: 107945 RVA: 0x00829CD4 File Offset: 0x008280D4
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0601A5AA RID: 107946 RVA: 0x00829D10 File Offset: 0x00828110
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0401279E RID: 75678
		private CAgentStaticMethod<T, P1, P2>.FunctionPointer _fp;

		// Token: 0x0401279F RID: 75679
		private IInstanceMember _p1;

		// Token: 0x040127A0 RID: 75680
		private IInstanceMember _p2;

		// Token: 0x020047A4 RID: 18340
		// (Invoke) Token: 0x0601A5AC RID: 107948
		public delegate T FunctionPointer(P1 p1, P2 p2);
	}
}
