using System;

namespace behaviac
{
	// Token: 0x02001D9C RID: 7580
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node32 : Condition
	{
		// Token: 0x060124F2 RID: 74994 RVA: 0x00558023 File Offset: 0x00556423
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node32()
		{
			this.opl_p0 = 9703;
		}

		// Token: 0x060124F3 RID: 74995 RVA: 0x00558038 File Offset: 0x00556438
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEDD RID: 48861
		private int opl_p0;
	}
}
