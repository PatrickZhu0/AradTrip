using System;

namespace behaviac
{
	// Token: 0x02002405 RID: 9221
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node57 : Condition
	{
		// Token: 0x06013169 RID: 78185 RVA: 0x005A8637 File Offset: 0x005A6A37
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x0601316A RID: 78186 RVA: 0x005A864C File Offset: 0x005A6A4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB96 RID: 52118
		private int opl_p0;
	}
}
