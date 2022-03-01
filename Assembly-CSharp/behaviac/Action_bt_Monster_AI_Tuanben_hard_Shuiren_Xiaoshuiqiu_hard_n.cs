using System;

namespace behaviac
{
	// Token: 0x02003D95 RID: 15765
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node10 : Action
	{
		// Token: 0x060162BE RID: 90814 RVA: 0x006B4039 File Offset: 0x006B2439
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 87110031;
			this.method_p1 = false;
		}

		// Token: 0x060162BF RID: 90815 RVA: 0x006B405A File Offset: 0x006B245A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB0E RID: 64270
		private int method_p0;

		// Token: 0x0400FB0F RID: 64271
		private bool method_p1;
	}
}
