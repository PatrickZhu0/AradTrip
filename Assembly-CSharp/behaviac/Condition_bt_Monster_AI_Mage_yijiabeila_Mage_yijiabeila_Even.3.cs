using System;

namespace behaviac
{
	// Token: 0x020035B7 RID: 13751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4 : Condition
	{
		// Token: 0x0601539B RID: 86939 RVA: 0x00665D23 File Offset: 0x00664123
		public Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node4()
		{
			this.opl_p0 = EventType.OnHurt;
		}

		// Token: 0x0601539C RID: 86940 RVA: 0x00665D34 File Offset: 0x00664134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED68 RID: 60776
		private EventType opl_p0;
	}
}
