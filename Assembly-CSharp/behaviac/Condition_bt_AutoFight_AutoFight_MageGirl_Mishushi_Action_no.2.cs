using System;

namespace behaviac
{
	// Token: 0x020026B1 RID: 9905
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node97 : Condition
	{
		// Token: 0x060136A5 RID: 79525 RVA: 0x005C86BD File Offset: 0x005C6ABD
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node97()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060136A6 RID: 79526 RVA: 0x005C86D0 File Offset: 0x005C6AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0FA RID: 53498
		private float opl_p0;
	}
}
