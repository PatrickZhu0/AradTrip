using System;

namespace behaviac
{
	// Token: 0x02002973 RID: 10611
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node27 : Condition
	{
		// Token: 0x06013C1B RID: 80923 RVA: 0x005E7F27 File Offset: 0x005E6327
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013C1C RID: 80924 RVA: 0x005E7F3C File Offset: 0x005E633C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D681 RID: 54913
		private int opl_p0;
	}
}
