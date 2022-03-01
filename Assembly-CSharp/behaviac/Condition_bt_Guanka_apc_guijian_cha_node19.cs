using System;

namespace behaviac
{
	// Token: 0x02002A40 RID: 10816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node19 : Condition
	{
		// Token: 0x06013DAC RID: 81324 RVA: 0x005F2B4D File Offset: 0x005F0F4D
		public Condition_bt_Guanka_apc_guijian_cha_node19()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013DAD RID: 81325 RVA: 0x005F2B60 File Offset: 0x005F0F60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D81F RID: 55327
		private float opl_p0;
	}
}
