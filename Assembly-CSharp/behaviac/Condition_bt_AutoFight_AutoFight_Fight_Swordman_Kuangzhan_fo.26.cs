using System;

namespace behaviac
{
	// Token: 0x02002358 RID: 9048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node50 : Condition
	{
		// Token: 0x0601301D RID: 77853 RVA: 0x0059EE67 File Offset: 0x0059D267
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_foolish_Action_node50()
		{
			this.opl_p0 = 1607;
		}

		// Token: 0x0601301E RID: 77854 RVA: 0x0059EE7C File Offset: 0x0059D27C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA35 RID: 51765
		private int opl_p0;
	}
}
