using System;

namespace behaviac
{
	// Token: 0x0200236B RID: 9067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node13 : Condition
	{
		// Token: 0x06013040 RID: 77888 RVA: 0x005A044B File Offset: 0x0059E84B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013041 RID: 77889 RVA: 0x005A0460 File Offset: 0x0059E860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA58 RID: 51800
		private int opl_p0;
	}
}
