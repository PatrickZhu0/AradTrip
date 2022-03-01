using System;

namespace behaviac
{
	// Token: 0x02002983 RID: 10627
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node11 : Condition
	{
		// Token: 0x06013C3A RID: 80954 RVA: 0x005E98E9 File Offset: 0x005E7CE9
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node11()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C3B RID: 80955 RVA: 0x005E98FC File Offset: 0x005E7CFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6A3 RID: 54947
		private float opl_p0;
	}
}
