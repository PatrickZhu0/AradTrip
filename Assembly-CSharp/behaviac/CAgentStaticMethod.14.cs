using System;

namespace behaviac
{
	// Token: 0x020047B9 RID: 18361
	public class CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> : CAgentMethodBase<T>
	{
		// Token: 0x0601A613 RID: 108051 RVA: 0x0082BC74 File Offset: 0x0082A074
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A614 RID: 108052 RVA: 0x0082BC84 File Offset: 0x0082A084
		public CAgentStaticMethod(CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13> rhs) : base(rhs)
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
			this._p13 = rhs._p13;
		}

		// Token: 0x0601A615 RID: 108053 RVA: 0x0082BD40 File Offset: 0x0082A140
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>(this);
		}

		// Token: 0x0601A616 RID: 108054 RVA: 0x0082BD48 File Offset: 0x0082A148
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
			this._p13 = AgentMeta.ParseProperty<P13>(paramStrs[12]);
		}

		// Token: 0x0601A617 RID: 108055 RVA: 0x0082BE18 File Offset: 0x0082A218
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self), ((CInstanceMember<P3>)this._p3).GetValue(self), ((CInstanceMember<P4>)this._p4).GetValue(self), ((CInstanceMember<P5>)this._p5).GetValue(self), ((CInstanceMember<P6>)this._p6).GetValue(self), ((CInstanceMember<P7>)this._p7).GetValue(self), ((CInstanceMember<P8>)this._p8).GetValue(self), ((CInstanceMember<P9>)this._p9).GetValue(self), ((CInstanceMember<P10>)this._p10).GetValue(self), ((CInstanceMember<P11>)this._p11).GetValue(self), ((CInstanceMember<P12>)this._p12).GetValue(self), ((CInstanceMember<P13>)this._p13).GetValue(self));
		}

		// Token: 0x0601A618 RID: 108056 RVA: 0x0082BF18 File Offset: 0x0082A318
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
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 12);
			treeTask.SetVariable<P13>(variableName, ((CInstanceMember<P13>)this._p13).GetValue(self));
		}

		// Token: 0x040127F6 RID: 75766
		private CAgentStaticMethod<T, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>.FunctionPointer _fp;

		// Token: 0x040127F7 RID: 75767
		private IInstanceMember _p1;

		// Token: 0x040127F8 RID: 75768
		private IInstanceMember _p2;

		// Token: 0x040127F9 RID: 75769
		private IInstanceMember _p3;

		// Token: 0x040127FA RID: 75770
		private IInstanceMember _p4;

		// Token: 0x040127FB RID: 75771
		private IInstanceMember _p5;

		// Token: 0x040127FC RID: 75772
		private IInstanceMember _p6;

		// Token: 0x040127FD RID: 75773
		private IInstanceMember _p7;

		// Token: 0x040127FE RID: 75774
		private IInstanceMember _p8;

		// Token: 0x040127FF RID: 75775
		private IInstanceMember _p9;

		// Token: 0x04012800 RID: 75776
		private IInstanceMember _p10;

		// Token: 0x04012801 RID: 75777
		private IInstanceMember _p11;

		// Token: 0x04012802 RID: 75778
		private IInstanceMember _p12;

		// Token: 0x04012803 RID: 75779
		private IInstanceMember _p13;

		// Token: 0x020047BA RID: 18362
		// (Invoke) Token: 0x0601A61A RID: 108058
		public delegate T FunctionPointer(P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13);
	}
}
