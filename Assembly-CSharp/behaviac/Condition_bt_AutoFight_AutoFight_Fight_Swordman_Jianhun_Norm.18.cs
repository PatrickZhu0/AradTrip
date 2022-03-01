using System;

namespace behaviac
{
	// Token: 0x02002300 RID: 8960
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node14 : Condition
	{
		// Token: 0x06012F79 RID: 77689 RVA: 0x0059B027 File Offset: 0x00599427
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_Normal_Action_node14()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06012F7A RID: 77690 RVA: 0x0059B03C File Offset: 0x0059943C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C995 RID: 51605
		private int opl_p0;
	}
}
