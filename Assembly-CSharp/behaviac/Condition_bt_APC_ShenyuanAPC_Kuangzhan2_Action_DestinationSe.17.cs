using System;

namespace behaviac
{
	// Token: 0x02001E88 RID: 7816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node25 : Condition
	{
		// Token: 0x060126BB RID: 75451 RVA: 0x00562BF4 File Offset: 0x00560FF4
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_DestinationSelect_node25()
		{
			this.opl_p0 = 9706;
		}

		// Token: 0x060126BC RID: 75452 RVA: 0x00562C08 File Offset: 0x00561008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0A8 RID: 49320
		private int opl_p0;
	}
}
