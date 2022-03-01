using System;

namespace behaviac
{
	// Token: 0x020039B5 RID: 14773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3 : Condition
	{
		// Token: 0x06015B3D RID: 88893 RVA: 0x0068E0D6 File Offset: 0x0068C4D6
		public Condition_bt_Monster_AI_Tuanben_Feiyi3_Destination_node3()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06015B3E RID: 88894 RVA: 0x0068E0EC File Offset: 0x0068C4EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4AF RID: 62639
		private float opl_p0;
	}
}
