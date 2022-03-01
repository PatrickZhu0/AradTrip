using System;

namespace behaviac
{
	// Token: 0x0200298D RID: 10637
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node114 : Condition
	{
		// Token: 0x06013C4E RID: 80974 RVA: 0x005E9E19 File Offset: 0x005E8219
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node114()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06013C4F RID: 80975 RVA: 0x005E9E2C File Offset: 0x005E822C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6B9 RID: 54969
		private float opl_p0;
	}
}
