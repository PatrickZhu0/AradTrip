using System;

namespace behaviac
{
	// Token: 0x020047A1 RID: 18337
	public class CAgentStaticMethod<T, P1> : CAgentMethodBase<T>
	{
		// Token: 0x0601A59A RID: 107930 RVA: 0x00829B8D File Offset: 0x00827F8D
		public CAgentStaticMethod(CAgentStaticMethod<T, P1>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A59B RID: 107931 RVA: 0x00829B9C File Offset: 0x00827F9C
		public CAgentStaticMethod(CAgentStaticMethod<T, P1> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
		}

		// Token: 0x0601A59C RID: 107932 RVA: 0x00829BBD File Offset: 0x00827FBD
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T, P1>(this);
		}

		// Token: 0x0601A59D RID: 107933 RVA: 0x00829BC5 File Offset: 0x00827FC5
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
		}

		// Token: 0x0601A59E RID: 107934 RVA: 0x00829BDC File Offset: 0x00827FDC
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0601A59F RID: 107935 RVA: 0x00829C05 File Offset: 0x00828005
		public override IValue GetIValue(Agent self, IInstanceMember firstParam)
		{
			this._returnValue.value = this._fp(((CInstanceMember<P1>)firstParam).GetValue(self));
			return this._returnValue;
		}

		// Token: 0x0601A5A0 RID: 107936 RVA: 0x00829C30 File Offset: 0x00828030
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0401279C RID: 75676
		private CAgentStaticMethod<T, P1>.FunctionPointer _fp;

		// Token: 0x0401279D RID: 75677
		private IInstanceMember _p1;

		// Token: 0x020047A2 RID: 18338
		// (Invoke) Token: 0x0601A5A2 RID: 107938
		public delegate T FunctionPointer(P1 p1);
	}
}
