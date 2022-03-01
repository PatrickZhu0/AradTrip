using System;

namespace behaviac
{
	// Token: 0x02001D03 RID: 7427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node12 : Condition
	{
		// Token: 0x060123CB RID: 74699 RVA: 0x00550CD3 File Offset: 0x0054F0D3
		public Condition_bt_APC_APC_Demian_Action_node12()
		{
			this.opl_p0 = 8005;
		}

		// Token: 0x060123CC RID: 74700 RVA: 0x00550CE8 File Offset: 0x0054F0E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDC2 RID: 48578
		private int opl_p0;
	}
}
