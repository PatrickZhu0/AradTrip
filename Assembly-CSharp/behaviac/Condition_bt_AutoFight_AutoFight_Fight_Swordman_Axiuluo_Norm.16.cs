using System;

namespace behaviac
{
	// Token: 0x02002254 RID: 8788
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node56 : Condition
	{
		// Token: 0x06012E30 RID: 77360 RVA: 0x005912F3 File Offset: 0x0058F6F3
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node56()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06012E31 RID: 77361 RVA: 0x00591308 File Offset: 0x0058F708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C836 RID: 51254
		private int opl_p0;
	}
}
