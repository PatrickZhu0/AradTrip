using System;

namespace behaviac
{
	// Token: 0x0200240D RID: 9229
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node7 : Condition
	{
		// Token: 0x06013177 RID: 78199 RVA: 0x005A97E7 File Offset: 0x005A7BE7
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_veryhard_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06013178 RID: 78200 RVA: 0x005A97FC File Offset: 0x005A7BFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CBA3 RID: 52131
		private int opl_p0;
	}
}
