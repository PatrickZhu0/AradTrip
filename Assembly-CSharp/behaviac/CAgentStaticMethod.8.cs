using System;

namespace behaviac
{
	// Token: 0x020047AD RID: 18349
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5D7 RID: 107991 RVA: 0x0082A59D File Offset: 0x0082899D
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5D8 RID: 107992 RVA: 0x0082A5AC File Offset: 0x008289AC
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7> rhs) : base(rhs)
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

		// Token: 0x0601A5D9 RID: 107993 RVA: 0x0082A620 File Offset: 0x00828A20
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7>(this);
		}

		// Token: 0x0601A5DA RID: 107994 RVA: 0x0082A628 File Offset: 0x00828A28
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

		// Token: 0x0601A5DB RID: 107995 RVA: 0x0082A6A0 File Offset: 0x00828AA0
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self));
		}

		// Token: 0x0601A5DC RID: 107996 RVA: 0x0082A73C File Offset: 0x00828B3C
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

		// Token: 0x040127B7 RID: 75703
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7>.FunctionPointer _fp;

		// Token: 0x040127B8 RID: 75704
		private IInstanceMember _p1;

		// Token: 0x040127B9 RID: 75705
		private IInstanceMember _p2;

		// Token: 0x040127BA RID: 75706
		private IInstanceMember _p3;

		// Token: 0x040127BB RID: 75707
		private IInstanceMember _p4;

		// Token: 0x040127BC RID: 75708
		private IInstanceMember _p5;

		// Token: 0x040127BD RID: 75709
		private IInstanceMember _p6;

		// Token: 0x040127BE RID: 75710
		private IInstanceMember _p7;

		// Token: 0x020047AE RID: 18350
		// (Invoke) Token: 0x0601A5DE RID: 107998
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7);
	}
}
