using System;

namespace behaviac
{
	// Token: 0x0200238D RID: 9101
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node57 : Condition
	{
		// Token: 0x06013081 RID: 77953 RVA: 0x005A1347 File Offset: 0x0059F747
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013082 RID: 77954 RVA: 0x005A135C File Offset: 0x0059F75C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA99 RID: 51865
		private int opl_p0;
	}
}
