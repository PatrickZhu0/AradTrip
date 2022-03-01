using System;

namespace behaviac
{
	// Token: 0x02001D4E RID: 7502
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node2 : Condition
	{
		// Token: 0x0601245B RID: 74843 RVA: 0x00554A55 File Offset: 0x00552E55
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x0601245C RID: 74844 RVA: 0x00554A68 File Offset: 0x00552E68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE4B RID: 48715
		private float opl_p0;
	}
}
