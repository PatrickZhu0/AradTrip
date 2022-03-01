using System;

namespace behaviac
{
	// Token: 0x0200230D RID: 8973
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node16 : Condition
	{
		// Token: 0x06012F90 RID: 77712 RVA: 0x0059C0B2 File Offset: 0x0059A4B2
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012F91 RID: 77713 RVA: 0x0059C0E8 File Offset: 0x0059A4E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9A9 RID: 51625
		private int opl_p0;

		// Token: 0x0400C9AA RID: 51626
		private int opl_p1;

		// Token: 0x0400C9AB RID: 51627
		private int opl_p2;

		// Token: 0x0400C9AC RID: 51628
		private int opl_p3;
	}
}
