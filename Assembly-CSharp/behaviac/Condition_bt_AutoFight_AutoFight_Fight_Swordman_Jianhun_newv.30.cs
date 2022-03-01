using System;

namespace behaviac
{
	// Token: 0x020022D5 RID: 8917
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node50 : Condition
	{
		// Token: 0x06012F25 RID: 77605 RVA: 0x00598321 File Offset: 0x00596721
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node50()
		{
			this.opl_p0 = 1913;
		}

		// Token: 0x06012F26 RID: 77606 RVA: 0x00598334 File Offset: 0x00596734
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C93C RID: 51516
		private int opl_p0;
	}
}
