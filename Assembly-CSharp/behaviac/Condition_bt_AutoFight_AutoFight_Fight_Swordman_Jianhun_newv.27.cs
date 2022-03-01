using System;

namespace behaviac
{
	// Token: 0x020022D1 RID: 8913
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node45 : Condition
	{
		// Token: 0x06012F1D RID: 77597 RVA: 0x00598111 File Offset: 0x00596511
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Action_node45()
		{
			this.opl_p0 = 1911;
		}

		// Token: 0x06012F1E RID: 77598 RVA: 0x00598124 File Offset: 0x00596524
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C934 RID: 51508
		private int opl_p0;
	}
}
