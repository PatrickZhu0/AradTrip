using System;

namespace behaviac
{
	// Token: 0x02003D3F RID: 15679
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node58 : Action
	{
		// Token: 0x06016214 RID: 90644 RVA: 0x006B08E7 File Offset: 0x006AECE7
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node58()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
		}

		// Token: 0x06016215 RID: 90645 RVA: 0x006B08FD File Offset: 0x006AECFD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA7F RID: 64127
		private int method_p0;
	}
}
