using System;

namespace behaviac
{
	// Token: 0x02001DB2 RID: 7602
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node14 : Condition
	{
		// Token: 0x0601251D RID: 75037 RVA: 0x0055921F File Offset: 0x0055761F
		public Condition_bt_APC_APC_Kuangzhan_Action_node14()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601251E RID: 75038 RVA: 0x00559234 File Offset: 0x00557634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF0F RID: 48911
		private float opl_p0;
	}
}
