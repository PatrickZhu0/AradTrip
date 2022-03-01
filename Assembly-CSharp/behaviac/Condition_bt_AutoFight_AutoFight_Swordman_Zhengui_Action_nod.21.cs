using System;

namespace behaviac
{
	// Token: 0x02002997 RID: 10647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node27 : Condition
	{
		// Token: 0x06013C62 RID: 80994 RVA: 0x005EA2DF File Offset: 0x005E86DF
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013C63 RID: 80995 RVA: 0x005EA2F4 File Offset: 0x005E86F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6CD RID: 54989
		private int opl_p0;
	}
}
