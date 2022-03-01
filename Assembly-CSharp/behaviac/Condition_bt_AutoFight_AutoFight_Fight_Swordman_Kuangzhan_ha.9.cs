using System;

namespace behaviac
{
	// Token: 0x02002370 RID: 9072
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node21 : Condition
	{
		// Token: 0x06013049 RID: 77897 RVA: 0x005A071B File Offset: 0x0059EB1B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node21()
		{
			this.opl_p0 = 1505;
		}

		// Token: 0x0601304A RID: 77898 RVA: 0x005A0730 File Offset: 0x0059EB30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA60 RID: 51808
		private int opl_p0;
	}
}
