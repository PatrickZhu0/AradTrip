using System;

namespace behaviac
{
	// Token: 0x020047E6 RID: 18406
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5> : CAgentMethodVoidBase
	{
		// Token: 0x0601A700 RID: 108288 RVA: 0x0082F7D9 File Offset: 0x0082DBD9
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A701 RID: 108289 RVA: 0x0082F7E8 File Offset: 0x0082DBE8
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
		}

		// Token: 0x0601A702 RID: 108290 RVA: 0x0082F844 File Offset: 0x0082DC44
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5>(this);
		}

		// Token: 0x0601A703 RID: 108291 RVA: 0x0082F84C File Offset: 0x0082DC4C
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
		}

		// Token: 0x0601A704 RID: 108292 RVA: 0x0082F8A8 File Offset: 0x0082DCA8
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self));
		}

		// Token: 0x0601A705 RID: 108293 RVA: 0x0082F918 File Offset: 0x0082DD18
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
		}

		// Token: 0x0401289B RID: 75931
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5>.FunctionPointer _fp;

		// Token: 0x0401289C RID: 75932
		private IInstanceMember _p1;

		// Token: 0x0401289D RID: 75933
		private IInstanceMember _p2;

		// Token: 0x0401289E RID: 75934
		private IInstanceMember _p3;

		// Token: 0x0401289F RID: 75935
		private IInstanceMember _p4;

		// Token: 0x040128A0 RID: 75936
		private IInstanceMember _p5;

		// Token: 0x020047E7 RID: 18407
		// (Invoke) Token: 0x0601A707 RID: 108295
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
	}
}
