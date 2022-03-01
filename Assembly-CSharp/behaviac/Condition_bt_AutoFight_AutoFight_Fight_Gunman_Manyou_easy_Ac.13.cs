using System;

namespace behaviac
{
	// Token: 0x0200211A RID: 8474
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node32 : Condition
	{
		// Token: 0x06012BC7 RID: 76743 RVA: 0x0058144A File Offset: 0x0057F84A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node32()
		{
			this.opl_p0 = 0.42f;
		}

		// Token: 0x06012BC8 RID: 76744 RVA: 0x00581460 File Offset: 0x0057F860
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5BA RID: 50618
		private float opl_p0;
	}
}
