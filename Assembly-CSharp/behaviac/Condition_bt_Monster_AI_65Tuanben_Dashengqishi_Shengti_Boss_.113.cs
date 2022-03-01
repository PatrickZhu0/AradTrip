using System;

namespace behaviac
{
	// Token: 0x02002E93 RID: 11923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node15 : Condition
	{
		// Token: 0x06014601 RID: 83457 RVA: 0x00620B7D File Offset: 0x0061EF7D
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node15()
		{
			this.opl_p0 = 8002700;
		}

		// Token: 0x06014602 RID: 83458 RVA: 0x00620B90 File Offset: 0x0061EF90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF84 RID: 57220
		private int opl_p0;
	}
}
