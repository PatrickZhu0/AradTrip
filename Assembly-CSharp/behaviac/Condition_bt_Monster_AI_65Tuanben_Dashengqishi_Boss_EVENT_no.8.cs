using System;

namespace behaviac
{
	// Token: 0x02002DC4 RID: 11716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node2 : Condition
	{
		// Token: 0x06014467 RID: 83047 RVA: 0x006178EF File Offset: 0x00615CEF
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node2()
		{
			this.opl_p0 = 8002800;
		}

		// Token: 0x06014468 RID: 83048 RVA: 0x00617904 File Offset: 0x00615D04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotifyEx(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE28 RID: 56872
		private int opl_p0;
	}
}
