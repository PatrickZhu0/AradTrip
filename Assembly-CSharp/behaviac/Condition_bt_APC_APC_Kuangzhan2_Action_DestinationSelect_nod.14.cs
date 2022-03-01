using System;

namespace behaviac
{
	// Token: 0x02001DA4 RID: 7588
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node5 : Condition
	{
		// Token: 0x06012502 RID: 75010 RVA: 0x005583A7 File Offset: 0x005567A7
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node5()
		{
			this.opl_p0 = 9704;
		}

		// Token: 0x06012503 RID: 75011 RVA: 0x005583BC File Offset: 0x005567BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEEF RID: 48879
		private int opl_p0;
	}
}
