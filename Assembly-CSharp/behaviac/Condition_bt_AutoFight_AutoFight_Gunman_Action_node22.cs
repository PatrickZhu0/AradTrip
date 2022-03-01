using System;

namespace behaviac
{
	// Token: 0x02002578 RID: 9592
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node22 : Condition
	{
		// Token: 0x06013438 RID: 78904 RVA: 0x005BA095 File Offset: 0x005B8495
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node22()
		{
			this.opl_p0 = 1013;
		}

		// Token: 0x06013439 RID: 78905 RVA: 0x005BA0A8 File Offset: 0x005B84A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE62 RID: 52834
		private int opl_p0;
	}
}
