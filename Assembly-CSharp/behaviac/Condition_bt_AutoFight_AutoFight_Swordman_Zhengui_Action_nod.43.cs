using System;

namespace behaviac
{
	// Token: 0x020029B5 RID: 10677
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node90 : Condition
	{
		// Token: 0x06013C9E RID: 81054 RVA: 0x005EAFBA File Offset: 0x005E93BA
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node90()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C9F RID: 81055 RVA: 0x005EAFD0 File Offset: 0x005E93D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D70B RID: 55051
		private float opl_p0;
	}
}
