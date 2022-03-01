using System;

namespace behaviac
{
	// Token: 0x020047A5 RID: 18341
	public class CAgentStaticMethod<T, P1, P2, P3> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5AF RID: 107951 RVA: 0x00829D79 File Offset: 0x00828179
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5B0 RID: 107952 RVA: 0x00829D88 File Offset: 0x00828188
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
		}

		// Token: 0x0601A5B1 RID: 107953 RVA: 0x00829DC1 File Offset: 0x008281C1
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3>(this);
		}

		// Token: 0x0601A5B2 RID: 107954 RVA: 0x00829DC9 File Offset: 0x008281C9
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
		}

		// Token: 0x0601A5B3 RID: 107955 RVA: 0x00829DFC File Offset: 0x008281FC
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x0601A5B4 RID: 107956 RVA: 0x00829E54 File Offset: 0x00828254
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			treeTask.SetVariable<P3>(variableName, ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x040127A1 RID: 75681
		private CAgentStaticMethod<T, P1, P2, P3>.FunctionPointer _fp;

		// Token: 0x040127A2 RID: 75682
		private IInstanceMember _p1;

		// Token: 0x040127A3 RID: 75683
		private IInstanceMember _p2;

		// Token: 0x040127A4 RID: 75684
		private IInstanceMember _p3;

		// Token: 0x020047A6 RID: 18342
		// (Invoke) Token: 0x0601A5B6 RID: 107958
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3);
	}
}
