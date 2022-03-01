using System;

namespace behaviac
{
	// Token: 0x02002586 RID: 9606
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node41 : Condition
	{
		// Token: 0x06013454 RID: 78932 RVA: 0x005BA75A File Offset: 0x005B8B5A
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node41()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013455 RID: 78933 RVA: 0x005BA770 File Offset: 0x005B8B70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE7D RID: 52861
		private float opl_p0;
	}
}
