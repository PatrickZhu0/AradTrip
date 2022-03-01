using System;

namespace behaviac
{
	// Token: 0x02002949 RID: 10569
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node99 : Condition
	{
		// Token: 0x06013BC7 RID: 80839 RVA: 0x005E6CFF File Offset: 0x005E50FF
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node99()
		{
			this.opl_p0 = 1612;
		}

		// Token: 0x06013BC8 RID: 80840 RVA: 0x005E6D14 File Offset: 0x005E5114
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D62D RID: 54829
		private int opl_p0;
	}
}
