using System;

namespace behaviac
{
	// Token: 0x0200211E RID: 8478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node37 : Condition
	{
		// Token: 0x06012BCF RID: 76751 RVA: 0x005815E6 File Offset: 0x0057F9E6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node37()
		{
			this.opl_p0 = 0.43f;
		}

		// Token: 0x06012BD0 RID: 76752 RVA: 0x005815FC File Offset: 0x0057F9FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5C2 RID: 50626
		private float opl_p0;
	}
}
