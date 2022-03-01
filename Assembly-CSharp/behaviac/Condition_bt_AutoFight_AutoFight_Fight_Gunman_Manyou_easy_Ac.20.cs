using System;

namespace behaviac
{
	// Token: 0x02002127 RID: 8487
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node48 : Condition
	{
		// Token: 0x06012BE1 RID: 76769 RVA: 0x00581A73 File Offset: 0x0057FE73
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node48()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012BE2 RID: 76770 RVA: 0x00581AA8 File Offset: 0x0057FEA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5D3 RID: 50643
		private int opl_p0;

		// Token: 0x0400C5D4 RID: 50644
		private int opl_p1;

		// Token: 0x0400C5D5 RID: 50645
		private int opl_p2;

		// Token: 0x0400C5D6 RID: 50646
		private int opl_p3;
	}
}
