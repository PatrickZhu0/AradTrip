using System;

namespace behaviac
{
	// Token: 0x02001DA8 RID: 7592
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node25 : Condition
	{
		// Token: 0x0601250A RID: 75018 RVA: 0x00558590 File Offset: 0x00556990
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node25()
		{
			this.opl_p0 = 9706;
		}

		// Token: 0x0601250B RID: 75019 RVA: 0x005585A4 File Offset: 0x005569A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEFA RID: 48890
		private int opl_p0;
	}
}
