using System;

namespace behaviac
{
	// Token: 0x02002E88 RID: 11912
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node36 : Condition
	{
		// Token: 0x060145EB RID: 83435 RVA: 0x00620883 File Offset: 0x0061EC83
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node36()
		{
			this.opl_p0 = 8002700;
		}

		// Token: 0x060145EC RID: 83436 RVA: 0x00620898 File Offset: 0x0061EC98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF6F RID: 57199
		private int opl_p0;
	}
}
