using System;

namespace behaviac
{
	// Token: 0x0200292C RID: 10540
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node45 : Condition
	{
		// Token: 0x06013B8E RID: 80782 RVA: 0x005E4BC3 File Offset: 0x005E2FC3
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node45()
		{
			this.opl_p0 = 1911;
		}

		// Token: 0x06013B8F RID: 80783 RVA: 0x005E4BD8 File Offset: 0x005E2FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5F4 RID: 54772
		private int opl_p0;
	}
}
