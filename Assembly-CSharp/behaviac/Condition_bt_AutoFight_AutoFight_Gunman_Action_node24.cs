using System;

namespace behaviac
{
	// Token: 0x02002576 RID: 9590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node24 : Condition
	{
		// Token: 0x06013434 RID: 78900 RVA: 0x005B9FD2 File Offset: 0x005B83D2
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node24()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013435 RID: 78901 RVA: 0x005B9FE8 File Offset: 0x005B83E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE5D RID: 52829
		private float opl_p0;
	}
}
