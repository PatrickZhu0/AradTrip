using System;

namespace behaviac
{
	// Token: 0x020047DE RID: 18398
	public class CAgentStaticMethodVoid<P1> : CAgentMethodVoidBase
	{
		// Token: 0x0601A6D8 RID: 108248 RVA: 0x0082F2FE File Offset: 0x0082D6FE
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A6D9 RID: 108249 RVA: 0x0082F30D File Offset: 0x0082D70D
		public CAgentStaticMethodVoid(CAgentStaticMethodVoid<P1> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
		}

		// Token: 0x0601A6DA RID: 108250 RVA: 0x0082F32E File Offset: 0x0082D72E
		public override IMethod Clone()
		{
			return new CAgentStaticMethodVoid<P1>(this);
		}

		// Token: 0x0601A6DB RID: 108251 RVA: 0x0082F336 File Offset: 0x0082D736
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
		}

		// Token: 0x0601A6DC RID: 108252 RVA: 0x0082F34D File Offset: 0x0082D74D
		public override void Run(Agent self)
		{
			this._fp(((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0601A6DD RID: 108253 RVA: 0x0082F36C File Offset: 0x0082D76C
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0401288D RID: 75917
		private CAgentStaticMethodVoid<P1>.FunctionPointer _fp;

		// Token: 0x0401288E RID: 75918
		private IInstanceMember _p1;

		// Token: 0x020047DF RID: 18399
		// (Invoke) Token: 0x0601A6DF RID: 108255
		public delegate void FunctionPointer(P1 p1);
	}
}
