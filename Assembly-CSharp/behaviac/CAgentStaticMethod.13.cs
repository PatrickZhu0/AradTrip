using System;

namespace behaviac
{
	// Token: 0x020047B7 RID: 18359
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> : CAgentMethodBase<T>
	{
		// Token: 0x0601A609 RID: 108041 RVA: 0x0082B7C5 File Offset: 0x00829BC5
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A60A RID: 108042 RVA: 0x0082B7D4 File Offset: 0x00829BD4
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12> rhs) : base(rhs)
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
			this._p10 = rhs._p10;
			this._p11 = rhs._p11;
			this._p12 = rhs._p12;
		}

		// Token: 0x0601A60B RID: 108043 RVA: 0x0082B884 File Offset: 0x00829C84
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>(this);
		}

		// Token: 0x0601A60C RID: 108044 RVA: 0x0082B88C File Offset: 0x00829C8C
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
			this._p10 = AgentMeta.ParseProperty<P10>(paramStrs[9]);
			this._p11 = AgentMeta.ParseProperty<P11>(paramStrs[10]);
			this._p12 = AgentMeta.ParseProperty<P12>(paramStrs[11]);
		}

		// Token: 0x0601A60D RID: 108045 RVA: 0x0082B94C File Offset: 0x00829D4C
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self), ((CInstanceMember<P12>)this._p12).GetValue(self));
		}

		// Token: 0x0601A60E RID: 108046 RVA: 0x0082BA3C File Offset: 0x00829E3C
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 9);
			treeTask.SetVariable<P10>(variableName, ((CInstanceMember<P10>)this._p10).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 10);
			treeTask.SetVariable<P11>(variableName, ((CInstanceMember<P11>)this._p11).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 11);
			treeTask.SetVariable<P12>(variableName, ((CInstanceMember<P12>)this._p12).GetValue(self));
		}

		// Token: 0x040127E9 RID: 75753
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>.FunctionPointer _fp;

		// Token: 0x040127EA RID: 75754
		private IInstanceMember _p1;

		// Token: 0x040127EB RID: 75755
		private IInstanceMember _p2;

		// Token: 0x040127EC RID: 75756
		private IInstanceMember _p3;

		// Token: 0x040127ED RID: 75757
		private IInstanceMember _p4;

		// Token: 0x040127EE RID: 75758
		private IInstanceMember _p5;

		// Token: 0x040127EF RID: 75759
		private IInstanceMember _p6;

		// Token: 0x040127F0 RID: 75760
		private IInstanceMember _p7;

		// Token: 0x040127F1 RID: 75761
		private IInstanceMember _p8;

		// Token: 0x040127F2 RID: 75762
		private IInstanceMember _p9;

		// Token: 0x040127F3 RID: 75763
		private IInstanceMember _p10;

		// Token: 0x040127F4 RID: 75764
		private IInstanceMember _p11;

		// Token: 0x040127F5 RID: 75765
		private IInstanceMember _p12;

		// Token: 0x020047B8 RID: 18360
		// (Invoke) Token: 0x0601A610 RID: 108048
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12);
	}
}
