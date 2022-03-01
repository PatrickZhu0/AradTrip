using System;

namespace behaviac
{
	// Token: 0x020023E3 RID: 9187
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node13 : Condition
	{
		// Token: 0x06013128 RID: 78120 RVA: 0x005A773B File Offset: 0x005A5B3B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013129 RID: 78121 RVA: 0x005A7750 File Offset: 0x005A5B50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB55 RID: 52053
		private int opl_p0;
	}
}
