using System;

namespace behaviac
{
	// Token: 0x02001E80 RID: 7808
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node27 : Condition
	{
		// Token: 0x060126AB RID: 75435 RVA: 0x00562837 File Offset: 0x00560C37
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node27()
		{
			this.opl_p0 = 9702;
		}

		// Token: 0x060126AC RID: 75436 RVA: 0x0056284C File Offset: 0x00560C4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C093 RID: 49299
		private int opl_p0;
	}
}
