using System;

namespace behaviac
{
	// Token: 0x02002966 RID: 10598
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node57 : Condition
	{
		// Token: 0x06013C01 RID: 80897 RVA: 0x005E79D3 File Offset: 0x005E5DD3
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node57()
		{
			this.opl_p0 = 1511;
		}

		// Token: 0x06013C02 RID: 80898 RVA: 0x005E79E8 File Offset: 0x005E5DE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D667 RID: 54887
		private int opl_p0;
	}
}
