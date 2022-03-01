using System;

namespace behaviac
{
	// Token: 0x020047A9 RID: 18345
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5C3 RID: 107971 RVA: 0x0082A0CD File Offset: 0x008284CD
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5C4 RID: 107972 RVA: 0x0082A0DC File Offset: 0x008284DC
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
		}

		// Token: 0x0601A5C5 RID: 107973 RVA: 0x0082A138 File Offset: 0x00828538
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5>(this);
		}

		// Token: 0x0601A5C6 RID: 107974 RVA: 0x0082A140 File Offset: 0x00828540
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
			this._p3 = AgentMeta.ParseProperty<P3>(paramStrs[2]);
			this._p4 = AgentMeta.ParseProperty<P4>(paramStrs[3]);
			this._p5 = AgentMeta.ParseProperty<P5>(paramStrs[4]);
		}

		// Token: 0x0601A5C7 RID: 107975 RVA: 0x0082A19C File Offset: 0x0082859C
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self));
		}

		// Token: 0x0601A5C8 RID: 107976 RVA: 0x0082A214 File Offset: 0x00828614
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

		// Token: 0x040127AA RID: 75690
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5>.FunctionPointer _fp;

		// Token: 0x040127AB RID: 75691
		private IInstanceMember _p1;

		// Token: 0x040127AC RID: 75692
		private IInstanceMember _p2;

		// Token: 0x040127AD RID: 75693
		private IInstanceMember _p3;

		// Token: 0x040127AE RID: 75694
		private IInstanceMember _p4;

		// Token: 0x040127AF RID: 75695
		private IInstanceMember _p5;

		// Token: 0x020047AA RID: 18346
		// (Invoke) Token: 0x0601A5CA RID: 107978
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5);
	}
}
