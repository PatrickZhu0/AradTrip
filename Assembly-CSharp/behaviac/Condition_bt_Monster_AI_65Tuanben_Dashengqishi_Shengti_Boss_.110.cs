using System;

namespace behaviac
{
	// Token: 0x02002E8C RID: 11916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node2 : Condition
	{
		// Token: 0x060145F3 RID: 83443 RVA: 0x00620993 File Offset: 0x0061ED93
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node2()
		{
			this.opl_p0 = 8002800;
		}

		// Token: 0x060145F4 RID: 83444 RVA: 0x006209A8 File Offset: 0x0061EDA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF76 RID: 57206
		private int opl_p0;
	}
}
