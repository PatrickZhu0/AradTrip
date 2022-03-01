using System;

namespace behaviac
{
	// Token: 0x020047E8 RID: 18408
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6> : CAgentMethodVoidBase
	{
		// Token: 0x0601A70A RID: 108298 RVA: 0x0082FA0B File Offset: 0x0082DE0B
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A70B RID: 108299 RVA: 0x0082FA1C File Offset: 0x0082DE1C
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
		}

		// Token: 0x0601A70C RID: 108300 RVA: 0x0082FA84 File Offset: 0x0082DE84
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6>(this);
		}

		// Token: 0x0601A70D RID: 108301 RVA: 0x0082FA8C File Offset: 0x0082DE8C
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

		// Token: 0x0601A70E RID: 108302 RVA: 0x0082FAF4 File Offset: 0x0082DEF4
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self));
		}

		// Token: 0x0601A70F RID: 108303 RVA: 0x0082FB74 File Offset: 0x0082DF74
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

		// Token: 0x040128A1 RID: 75937
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6>.FunctionPointer _fp;

		// Token: 0x040128A2 RID: 75938
		private IInstanceMember _p1;

		// Token: 0x040128A3 RID: 75939
		private IInstanceMember _p2;

		// Token: 0x040128A4 RID: 75940
		private IInstanceMember _p3;

		// Token: 0x040128A5 RID: 75941
		private IInstanceMember _p4;

		// Token: 0x040128A6 RID: 75942
		private IInstanceMember _p5;

		// Token: 0x040128A7 RID: 75943
		private IInstanceMember _p6;

		// Token: 0x020047E9 RID: 18409
		// (Invoke) Token: 0x0601A711 RID: 108305
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6);
	}
}
