using System;

namespace behaviac
{
	// Token: 0x0200293F RID: 10559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node37 : Condition
	{
		// Token: 0x06013BB4 RID: 80820 RVA: 0x005E5781 File Offset: 0x005E3B81
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node37()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013BB5 RID: 80821 RVA: 0x005E5794 File Offset: 0x005E3B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D61B RID: 54811
		private float opl_p0;
	}
}
