using System;

namespace behaviac
{
	// Token: 0x02002258 RID: 8792
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node61 : Condition
	{
		// Token: 0x06012E38 RID: 77368 RVA: 0x005917CD File Offset: 0x0058FBCD
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Axiuluo_Normal_Action_node61()
		{
			this.opl_p0 = 1700;
		}

		// Token: 0x06012E39 RID: 77369 RVA: 0x005917E0 File Offset: 0x0058FBE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C842 RID: 51266
		private int opl_p0;
	}
}
