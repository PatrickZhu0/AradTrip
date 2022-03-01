using System;

namespace behaviac
{
	// Token: 0x02001E73 RID: 7795
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node16 : Condition
	{
		// Token: 0x06012691 RID: 75409 RVA: 0x005622C3 File Offset: 0x005606C3
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node16()
		{
			this.opl_p0 = 9705;
		}

		// Token: 0x06012692 RID: 75410 RVA: 0x005622D8 File Offset: 0x005606D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C078 RID: 49272
		private int opl_p0;
	}
}
