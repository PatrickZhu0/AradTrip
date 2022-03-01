using System;

namespace behaviac
{
	// Token: 0x0200479F RID: 18335
	public class CAgentStaticMethod<T> : CAgentMethodBase<T>
	{
		// Token: 0x0601A590 RID: 107920 RVA: 0x00829B3E File Offset: 0x00827F3E
		public CAgentStaticMethod(CAgentStaticMethod<T>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A591 RID: 107921 RVA: 0x00829B4D File Offset: 0x00827F4D
		public CAgentStaticMethod(CAgentStaticMethod<T> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
		}

		// Token: 0x0601A592 RID: 107922 RVA: 0x00829B62 File Offset: 0x00827F62
		public override IMethod Clone()
		{
			return new CAgentStaticMethod<T>(this);
		}

		// Token: 0x0601A593 RID: 107923 RVA: 0x00829B6A File Offset: 0x00827F6A
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
		}

		// Token: 0x0601A594 RID: 107924 RVA: 0x00829B73 File Offset: 0x00827F73
		public override void Run(Agent self)
		{
			this._returnValue.value = this._fp();
		}

		// Token: 0x0601A595 RID: 107925 RVA: 0x00829B8B File Offset: 0x00827F8B
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
		}

		// Token: 0x0401279B RID: 75675
		private CAgentStaticMethod<T>.FunctionPointer _fp;

		// Token: 0x020047A0 RID: 18336
		// (Invoke) Token: 0x0601A597 RID: 107927
		public delegate T FunctionPointer();
	}
}
