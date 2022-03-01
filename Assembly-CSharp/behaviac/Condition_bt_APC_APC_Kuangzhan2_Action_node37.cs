using System;

namespace behaviac
{
	// Token: 0x02001D87 RID: 7559
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node37 : Condition
	{
		// Token: 0x060124C9 RID: 74953 RVA: 0x005571F9 File Offset: 0x005555F9
		public Condition_bt_APC_APC_Kuangzhan2_Action_node37()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060124CA RID: 74954 RVA: 0x0055720C File Offset: 0x0055560C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEB6 RID: 48822
		private float opl_p0;
	}
}
