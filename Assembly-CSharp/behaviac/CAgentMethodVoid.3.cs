using System;

namespace behaviac
{
	// Token: 0x020047C2 RID: 18370
	public class CAgentMethodVoid<P1, P2> : CAgentMethodVoidBase
	{
		// Token: 0x0601A64C RID: 108108 RVA: 0x0082C80B File Offset: 0x0082AC0B
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A64D RID: 108109 RVA: 0x0082C81A File Offset: 0x0082AC1A
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
		}

		// Token: 0x0601A64E RID: 108110 RVA: 0x0082C847 File Offset: 0x0082AC47
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2>(this);
		}

		// Token: 0x0601A64F RID: 108111 RVA: 0x0082C84F File Offset: 0x0082AC4F
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
		}

		// Token: 0x0601A650 RID: 108112 RVA: 0x0082C874 File Offset: 0x0082AC74
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0601A651 RID: 108113 RVA: 0x0082C8BC File Offset: 0x0082ACBC
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x04012817 RID: 75799
		private CAgentMethodVoid<P1, P2>.FunctionPointer _fp;

		// Token: 0x04012818 RID: 75800
		private IInstanceMember _p1;

		// Token: 0x04012819 RID: 75801
		private IInstanceMember _p2;

		// Token: 0x020047C3 RID: 18371
		// (Invoke) Token: 0x0601A653 RID: 108115
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2);
	}
}
