using System;

namespace behaviac
{
	// Token: 0x020022FC RID: 8956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node45 : Condition
	{
		// Token: 0x06012F71 RID: 77681 RVA: 0x0059AE19 File Offset: 0x00599219
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node45()
		{
			this.opl_p0 = 1911;
		}

		// Token: 0x06012F72 RID: 77682 RVA: 0x0059AE2C File Offset: 0x0059922C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C98D RID: 51597
		private int opl_p0;
	}
}
