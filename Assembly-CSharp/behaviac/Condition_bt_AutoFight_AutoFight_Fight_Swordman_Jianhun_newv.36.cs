using System;

namespace behaviac
{
	// Token: 0x020022DD RID: 8925
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node14 : Condition
	{
		// Token: 0x06012F35 RID: 77621 RVA: 0x0059890B File Offset: 0x00596D0B
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node14()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012F36 RID: 77622 RVA: 0x00598920 File Offset: 0x00596D20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C94C RID: 51532
		private int opl_p0;
	}
}
