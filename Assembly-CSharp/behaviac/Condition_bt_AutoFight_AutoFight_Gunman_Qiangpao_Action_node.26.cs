using System;

namespace behaviac
{
	// Token: 0x02002660 RID: 9824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node26 : Condition
	{
		// Token: 0x06013605 RID: 79365 RVA: 0x005C43D5 File Offset: 0x005C27D5
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node26()
		{
			this.opl_p0 = 0.25f;
		}

		// Token: 0x06013606 RID: 79366 RVA: 0x005C43E8 File Offset: 0x005C27E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D057 RID: 53335
		private float opl_p0;
	}
}
