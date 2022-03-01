using System;

namespace behaviac
{
	// Token: 0x02001E84 RID: 7812
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x060126B3 RID: 75443 RVA: 0x00562A0B File Offset: 0x00560E0B
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 9704;
		}

		// Token: 0x060126B4 RID: 75444 RVA: 0x00562A20 File Offset: 0x00560E20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C09D RID: 49309
		private int opl_p0;
	}
}
