using System;

namespace behaviac
{
	// Token: 0x0200295D RID: 10589
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node13 : Condition
	{
		// Token: 0x06013BEF RID: 80879 RVA: 0x005E75D7 File Offset: 0x005E59D7
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013BF0 RID: 80880 RVA: 0x005E75EC File Offset: 0x005E59EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D655 RID: 54869
		private int opl_p0;
	}
}
