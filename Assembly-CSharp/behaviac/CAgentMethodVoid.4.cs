using System;

namespace behaviac
{
	// Token: 0x020047C4 RID: 18372
	public class CAgentMethodVoid<P1, P2, P3> : CAgentMethodVoidBase
	{
		// Token: 0x0601A656 RID: 108118 RVA: 0x0082C925 File Offset: 0x0082AD25
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A657 RID: 108119 RVA: 0x0082C934 File Offset: 0x0082AD34
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
		}

		// Token: 0x0601A658 RID: 108120 RVA: 0x0082C96D File Offset: 0x0082AD6D
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3>(this);
		}

		// Token: 0x0601A659 RID: 108121 RVA: 0x0082C975 File Offset: 0x0082AD75
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
		}

		// Token: 0x0601A65A RID: 108122 RVA: 0x0082C9A8 File Offset: 0x0082ADA8
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x0601A65B RID: 108123 RVA: 0x0082CA04 File Offset: 0x0082AE04
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 2);
			treeTask.SetVariable<P3>(variableName, ((CInstanceMember<P3>)this._p3).GetValue(self));
		}

		// Token: 0x0401281A RID: 75802
		private CAgentMethodVoid<P1, P2, P3>.FunctionPointer _fp;

		// Token: 0x0401281B RID: 75803
		private IInstanceMember _p1;

		// Token: 0x0401281C RID: 75804
		private IInstanceMember _p2;

		// Token: 0x0401281D RID: 75805
		private IInstanceMember _p3;

		// Token: 0x020047C5 RID: 18373
		// (Invoke) Token: 0x0601A65D RID: 108125
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3);
	}
}
