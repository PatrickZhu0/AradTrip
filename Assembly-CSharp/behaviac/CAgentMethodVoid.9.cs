using System;

namespace behaviac
{
	// Token: 0x020047CE RID: 18382
	public class CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8> : CAgentMethodVoidBase
	{
		// Token: 0x0601A688 RID: 108168 RVA: 0x0082D447 File Offset: 0x0082B847
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A689 RID: 108169 RVA: 0x0082D458 File Offset: 0x0082B858
		public CAgentMethodVoid(CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
			this._p3 = rhs._p3;
			this._p4 = rhs._p4;
			this._p5 = rhs._p5;
			this._p6 = rhs._p6;
			this._p7 = rhs._p7;
			this._p8 = rhs._p8;
		}

		// Token: 0x0601A68A RID: 108170 RVA: 0x0082D4D8 File Offset: 0x0082B8D8
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>(this);
		}

		// Token: 0x0601A68B RID: 108171 RVA: 0x0082D4E0 File Offset: 0x0082B8E0
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
			this._p8 = AgentMeta.ParseProperty<P8>(paramStrs[7]);
		}

		// Token: 0x0601A68C RID: 108172 RVA: 0x0082D564 File Offset: 0x0082B964
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self));
		}

		// Token: 0x0601A68D RID: 108173 RVA: 0x0082D614 File Offset: 0x0082BA14
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 7);
			treeTask.SetVariable<P8>(variableName, ((CInstanceMember<P8>)this._p8).GetValue(self));
		}

		// Token: 0x04012838 RID: 75832
		private CAgentMethodVoid<P1, P2, P3, P4, P5, P6, P7, P8>.FunctionPointer _fp;

		// Token: 0x04012839 RID: 75833
		private IInstanceMember _p1;

		// Token: 0x0401283A RID: 75834
		private IInstanceMember _p2;

		// Token: 0x0401283B RID: 75835
		private IInstanceMember _p3;

		// Token: 0x0401283C RID: 75836
		private IInstanceMember _p4;

		// Token: 0x0401283D RID: 75837
		private IInstanceMember _p5;

		// Token: 0x0401283E RID: 75838
		private IInstanceMember _p6;

		// Token: 0x0401283F RID: 75839
		private IInstanceMember _p7;

		// Token: 0x04012840 RID: 75840
		private IInstanceMember _p8;

		// Token: 0x020047CF RID: 18383
		// (Invoke) Token: 0x0601A68F RID: 108175
		public delegate void FunctionPointer(Agent a, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8);
	}
}
