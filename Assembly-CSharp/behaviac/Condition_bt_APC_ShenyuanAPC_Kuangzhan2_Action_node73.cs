using System;

namespace behaviac
{
	// Token: 0x02001E6B RID: 7787
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node73 : Condition
	{
		// Token: 0x06012682 RID: 75394 RVA: 0x005619F7 File Offset: 0x0055FDF7
		public Condition_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node73()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012683 RID: 75395 RVA: 0x00561A0C File Offset: 0x0055FE0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C06C RID: 49260
		private float opl_p0;
	}
}
