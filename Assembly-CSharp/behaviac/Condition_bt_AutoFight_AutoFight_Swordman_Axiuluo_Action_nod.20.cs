using System;

namespace behaviac
{
	// Token: 0x020028B2 RID: 10418
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node73 : Condition
	{
		// Token: 0x06013A9E RID: 80542 RVA: 0x005DF2D5 File Offset: 0x005DD6D5
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node73()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013A9F RID: 80543 RVA: 0x005DF2E8 File Offset: 0x005DD6E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4FC RID: 54524
		private float opl_p0;
	}
}
