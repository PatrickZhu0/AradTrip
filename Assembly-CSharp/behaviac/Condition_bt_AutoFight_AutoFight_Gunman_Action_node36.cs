using System;

namespace behaviac
{
	// Token: 0x02002582 RID: 9602
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node36 : Condition
	{
		// Token: 0x0601344C RID: 78924 RVA: 0x005BA5A2 File Offset: 0x005B89A2
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node36()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x0601344D RID: 78925 RVA: 0x005BA5B8 File Offset: 0x005B89B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE75 RID: 52853
		private float opl_p0;
	}
}
