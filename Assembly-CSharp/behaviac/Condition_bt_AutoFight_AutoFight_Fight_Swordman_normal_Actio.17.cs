using System;

namespace behaviac
{
	// Token: 0x02002450 RID: 9296
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node67 : Condition
	{
		// Token: 0x060131F4 RID: 78324 RVA: 0x005AC1F9 File Offset: 0x005AA5F9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_normal_Action_node67()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x060131F5 RID: 78325 RVA: 0x005AC20C File Offset: 0x005AA60C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC1D RID: 52253
		private int opl_p0;
	}
}
