using System;

namespace behaviac
{
	// Token: 0x020029AE RID: 10670
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node111 : Condition
	{
		// Token: 0x06013C90 RID: 81040 RVA: 0x005EACB3 File Offset: 0x005E90B3
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node111()
		{
			this.opl_p0 = 1510;
		}

		// Token: 0x06013C91 RID: 81041 RVA: 0x005EACC8 File Offset: 0x005E90C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6FD RID: 55037
		private int opl_p0;
	}
}
