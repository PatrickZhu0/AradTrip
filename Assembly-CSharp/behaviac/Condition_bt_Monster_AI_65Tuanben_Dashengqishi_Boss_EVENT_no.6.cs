using System;

namespace behaviac
{
	// Token: 0x02002DC0 RID: 11712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node36 : Condition
	{
		// Token: 0x0601445F RID: 83039 RVA: 0x006177DF File Offset: 0x00615BDF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node36()
		{
			this.opl_p0 = 8002700;
		}

		// Token: 0x06014460 RID: 83040 RVA: 0x006177F4 File Offset: 0x00615BF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE21 RID: 56865
		private int opl_p0;
	}
}
