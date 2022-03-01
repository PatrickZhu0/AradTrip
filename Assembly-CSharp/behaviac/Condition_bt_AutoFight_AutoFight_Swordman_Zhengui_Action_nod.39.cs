using System;

namespace behaviac
{
	// Token: 0x020029B0 RID: 10672
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node102 : Condition
	{
		// Token: 0x06013C94 RID: 81044 RVA: 0x005EADA6 File Offset: 0x005E91A6
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node102()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013C95 RID: 81045 RVA: 0x005EADBC File Offset: 0x005E91BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D700 RID: 55040
		private float opl_p0;
	}
}
