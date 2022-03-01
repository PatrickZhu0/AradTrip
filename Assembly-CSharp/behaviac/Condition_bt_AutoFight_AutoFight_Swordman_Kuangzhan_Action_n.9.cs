using System;

namespace behaviac
{
	// Token: 0x0200294D RID: 10573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node40 : Condition
	{
		// Token: 0x06013BCF RID: 80847 RVA: 0x005E6EB3 File Offset: 0x005E52B3
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06013BD0 RID: 80848 RVA: 0x005E6EC8 File Offset: 0x005E52C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D635 RID: 54837
		private int opl_p0;
	}
}
