using System;

namespace behaviac
{
	// Token: 0x02002E94 RID: 11924
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node17 : Condition
	{
		// Token: 0x06014603 RID: 83459 RVA: 0x00620BC6 File Offset: 0x0061EFC6
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node17()
		{
			this.opl_p0 = 8002800;
		}

		// Token: 0x06014604 RID: 83460 RVA: 0x00620BDC File Offset: 0x0061EFDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF85 RID: 57221
		private int opl_p0;
	}
}
