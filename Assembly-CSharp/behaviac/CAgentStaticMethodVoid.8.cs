using System;

namespace behaviac
{
	// Token: 0x020047EA RID: 18410
	public class CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7> : CAgentMethodVoidBase
	{
		// Token: 0x0601A714 RID: 108308 RVA: 0x0082FC95 File Offset: 0x0082E095
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A715 RID: 108309 RVA: 0x0082FCA4 File Offset: 0x0082E0A4
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
			this._p7 = rhs._p7;
		}

		// Token: 0x0601A716 RID: 108310 RVA: 0x0082FD18 File Offset: 0x0082E118
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7>(this);
		}

		// Token: 0x0601A717 RID: 108311 RVA: 0x0082FD20 File Offset: 0x0082E120
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
		}

		// Token: 0x0601A718 RID: 108312 RVA: 0x0082FD98 File Offset: 0x0082E198
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self));
		}

		// Token: 0x0601A719 RID: 108313 RVA: 0x0082FE28 File Offset: 0x0082E228
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
		}

		// Token: 0x040128A8 RID: 75944
		private CAgentStaticMethodVoid<P1, P2, P3, P4, P5, P6, P7>.FunctionPointer _fp;

		// Token: 0x040128A9 RID: 75945
		private IInstanceMember _p1;

		// Token: 0x040128AA RID: 75946
		private IInstanceMember _p2;

		// Token: 0x040128AB RID: 75947
		private IInstanceMember _p3;

		// Token: 0x040128AC RID: 75948
		private IInstanceMember _p4;

		// Token: 0x040128AD RID: 75949
		private IInstanceMember _p5;

		// Token: 0x040128AE RID: 75950
		private IInstanceMember _p6;

		// Token: 0x040128AF RID: 75951
		private IInstanceMember _p7;

		// Token: 0x020047EB RID: 18411
		// (Invoke) Token: 0x0601A71B RID: 108315
		public delegate void FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);
	}
}
