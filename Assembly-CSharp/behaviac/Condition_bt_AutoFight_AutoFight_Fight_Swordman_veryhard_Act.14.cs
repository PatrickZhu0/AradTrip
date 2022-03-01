using System;

namespace behaviac
{
	// Token: 0x02002469 RID: 9321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node40 : Condition
	{
		// Token: 0x06013222 RID: 78370 RVA: 0x005AD59F File Offset: 0x005AB99F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06013223 RID: 78371 RVA: 0x005AD5B4 File Offset: 0x005AB9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC47 RID: 52295
		private int opl_p0;
	}
}
