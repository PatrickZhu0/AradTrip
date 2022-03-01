using System;

namespace behaviac
{
	// Token: 0x0200290B RID: 10507
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node52 : Condition
	{
		// Token: 0x06013B4C RID: 80716 RVA: 0x005E3BAD File Offset: 0x005E1FAD
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node52()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06013B4D RID: 80717 RVA: 0x005E3BC0 File Offset: 0x005E1FC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D5B1 RID: 54705
		private float opl_p0;
	}
}
