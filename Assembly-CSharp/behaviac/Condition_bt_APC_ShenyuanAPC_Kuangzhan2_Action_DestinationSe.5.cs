using System;

namespace behaviac
{
	// Token: 0x02001E78 RID: 7800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node50 : Condition
	{
		// Token: 0x0601269B RID: 75419 RVA: 0x005624D3 File Offset: 0x005608D3
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node50()
		{
			this.opl_p0 = 9701;
		}

		// Token: 0x0601269C RID: 75420 RVA: 0x005624E8 File Offset: 0x005608E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C083 RID: 49283
		private int opl_p0;
	}
}
