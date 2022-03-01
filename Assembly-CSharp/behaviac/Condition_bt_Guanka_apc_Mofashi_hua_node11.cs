using System;

namespace behaviac
{
	// Token: 0x02002A87 RID: 10887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_hua_node11 : Condition
	{
		// Token: 0x06013E32 RID: 81458 RVA: 0x005F6B11 File Offset: 0x005F4F11
		public Condition_bt_Guanka_apc_Mofashi_hua_node11()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06013E33 RID: 81459 RVA: 0x005F6B24 File Offset: 0x005F4F24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8A8 RID: 55464
		private float opl_p0;
	}
}
