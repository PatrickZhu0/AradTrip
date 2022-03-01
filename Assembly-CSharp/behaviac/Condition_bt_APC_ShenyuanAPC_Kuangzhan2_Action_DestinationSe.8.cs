using System;

namespace behaviac
{
	// Token: 0x02001E7C RID: 7804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node32 : Condition
	{
		// Token: 0x060126A3 RID: 75427 RVA: 0x00562687 File Offset: 0x00560A87
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node32()
		{
			this.opl_p0 = 9703;
		}

		// Token: 0x060126A4 RID: 75428 RVA: 0x0056269C File Offset: 0x00560A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C08B RID: 49291
		private int opl_p0;
	}
}
