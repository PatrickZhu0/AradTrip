using System;

namespace behaviac
{
	// Token: 0x02002400 RID: 9216
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node50 : Condition
	{
		// Token: 0x0601315F RID: 78175 RVA: 0x005A8423 File Offset: 0x005A6823
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node50()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x06013160 RID: 78176 RVA: 0x005A8438 File Offset: 0x005A6838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB8B RID: 52107
		private int opl_p0;
	}
}
