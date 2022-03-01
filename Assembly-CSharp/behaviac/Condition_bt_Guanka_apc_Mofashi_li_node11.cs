using System;

namespace behaviac
{
	// Token: 0x02002A95 RID: 10901
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node11 : Condition
	{
		// Token: 0x06013E4C RID: 81484 RVA: 0x005F752D File Offset: 0x005F592D
		public Condition_bt_Guanka_apc_Mofashi_li_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013E4D RID: 81485 RVA: 0x005F7540 File Offset: 0x005F5940
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8C2 RID: 55490
		private float opl_p0;
	}
}
