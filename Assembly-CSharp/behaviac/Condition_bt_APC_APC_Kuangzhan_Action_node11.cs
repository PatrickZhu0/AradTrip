using System;

namespace behaviac
{
	// Token: 0x02001DB7 RID: 7607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node11 : Condition
	{
		// Token: 0x06012527 RID: 75047 RVA: 0x0055961D File Offset: 0x00557A1D
		public Condition_bt_APC_APC_Kuangzhan_Action_node11()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012528 RID: 75048 RVA: 0x00559630 File Offset: 0x00557A30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF1B RID: 48923
		private float opl_p0;
	}
}
