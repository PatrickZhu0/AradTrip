using System;

namespace behaviac
{
	// Token: 0x020023E8 RID: 9192
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node21 : Condition
	{
		// Token: 0x06013131 RID: 78129 RVA: 0x005A7A0B File Offset: 0x005A5E0B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x06013132 RID: 78130 RVA: 0x005A7A20 File Offset: 0x005A5E20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB5D RID: 52061
		private int opl_p0;
	}
}
