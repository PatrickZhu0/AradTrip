using System;

namespace behaviac
{
	// Token: 0x0200291C RID: 10524
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node13 : Condition
	{
		// Token: 0x06013B6E RID: 80750 RVA: 0x005E443B File Offset: 0x005E283B
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node13()
		{
			this.opl_p0 = 1503;
		}

		// Token: 0x06013B6F RID: 80751 RVA: 0x005E4450 File Offset: 0x005E2850
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5D4 RID: 54740
		private int opl_p0;
	}
}
