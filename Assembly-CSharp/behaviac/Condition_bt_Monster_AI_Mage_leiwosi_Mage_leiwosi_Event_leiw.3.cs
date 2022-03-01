using System;

namespace behaviac
{
	// Token: 0x020035AF RID: 13743
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4 : Condition
	{
		// Token: 0x0601538C RID: 86924 RVA: 0x0066585B File Offset: 0x00663C5B
		public Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x0601538D RID: 86925 RVA: 0x0066586C File Offset: 0x00663C6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED5B RID: 60763
		private EventType opl_p0;
	}
}
