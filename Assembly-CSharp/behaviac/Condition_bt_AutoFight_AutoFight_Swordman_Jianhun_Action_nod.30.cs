using System;

namespace behaviac
{
	// Token: 0x0200292B RID: 10539
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node44 : Condition
	{
		// Token: 0x06013B8C RID: 80780 RVA: 0x005E4B7D File Offset: 0x005E2F7D
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node44()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013B8D RID: 80781 RVA: 0x005E4B90 File Offset: 0x005E2F90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5F3 RID: 54771
		private float opl_p0;
	}
}
