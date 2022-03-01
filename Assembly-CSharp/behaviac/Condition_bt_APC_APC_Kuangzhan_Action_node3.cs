using System;

namespace behaviac
{
	// Token: 0x02001DAD RID: 7597
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan_Action_node3 : Condition
	{
		// Token: 0x06012513 RID: 75027 RVA: 0x00558E3F File Offset: 0x0055723F
		public Condition_bt_APC_APC_Kuangzhan_Action_node3()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012514 RID: 75028 RVA: 0x00558E54 File Offset: 0x00557254
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF04 RID: 48900
		private float opl_p0;
	}
}
