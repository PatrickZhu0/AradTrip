using System;

namespace behaviac
{
	// Token: 0x02003D51 RID: 15697
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node32 : Action
	{
		// Token: 0x06016238 RID: 90680 RVA: 0x006B0E38 File Offset: 0x006AF238
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node32()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06016239 RID: 90681 RVA: 0x006B0E4E File Offset: 0x006AF24E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CounterAddUp(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA9A RID: 64154
		private int method_p0;
	}
}
