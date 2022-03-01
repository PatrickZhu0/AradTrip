using System;

namespace behaviac
{
	// Token: 0x020047B1 RID: 18353
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9> : CAgentMethodBase<T>
	{
		// Token: 0x0601A5EB RID: 108011 RVA: 0x0082ABD1 File Offset: 0x00828FD1
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A5EC RID: 108012 RVA: 0x0082ABE0 File Offset: 0x00828FE0
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9> rhs) : base(rhs)
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
			this._p9 = rhs._p9;
		}

		// Token: 0x0601A5ED RID: 108013 RVA: 0x0082AC6C File Offset: 0x0082906C
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>(this);
		}

		// Token: 0x0601A5EE RID: 108014 RVA: 0x0082AC74 File Offset: 0x00829074
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
			this._p9 = AgentMeta.ParseProperty<P9>(paramStrs[8]);
		}

		// Token: 0x0601A5EF RID: 108015 RVA: 0x0082AD08 File Offset: 0x00829108
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self));
		}

		// Token: 0x0601A5F0 RID: 108016 RVA: 0x0082ADC4 File Offset: 0x008291C4
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 8);
			treeTask.SetVariable<P9>(variableName, ((CInstanceMember<P9>)this._p9).GetValue(self));
		}

		// Token: 0x040127C8 RID: 75720
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9>.FunctionPointer _fp;

		// Token: 0x040127C9 RID: 75721
		private IInstanceMember _p1;

		// Token: 0x040127CA RID: 75722
		private IInstanceMember _p2;

		// Token: 0x040127CB RID: 75723
		private IInstanceMember _p3;

		// Token: 0x040127CC RID: 75724
		private IInstanceMember _p4;

		// Token: 0x040127CD RID: 75725
		private IInstanceMember _p5;

		// Token: 0x040127CE RID: 75726
		private IInstanceMember _p6;

		// Token: 0x040127CF RID: 75727
		private IInstanceMember _p7;

		// Token: 0x040127D0 RID: 75728
		private IInstanceMember _p8;

		// Token: 0x040127D1 RID: 75729
		private IInstanceMember _p9;

		// Token: 0x020047B2 RID: 18354
		// (Invoke) Token: 0x0601A5F2 RID: 108018
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9);
	}
}
