using System;

namespace behaviac
{
	// Token: 0x02002396 RID: 9110
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node7 : Condition
	{
		// Token: 0x06013092 RID: 77970 RVA: 0x005A25F9 File Offset: 0x005A09F9
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Action_node7()
		{
			this.opl_p0 = 1609;
		}

		// Token: 0x06013093 RID: 77971 RVA: 0x005A260C File Offset: 0x005A0A0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CAAF RID: 51887
		private int opl_p0;
	}
}
