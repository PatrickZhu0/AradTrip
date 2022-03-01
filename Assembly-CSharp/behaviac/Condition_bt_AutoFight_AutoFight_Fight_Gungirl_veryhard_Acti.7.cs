using System;

namespace behaviac
{
	// Token: 0x020020AE RID: 8366
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node17 : Condition
	{
		// Token: 0x06012AF3 RID: 76531 RVA: 0x0057C476 File Offset: 0x0057A876
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node17()
		{
			this.opl_p0 = 0.65f;
		}

		// Token: 0x06012AF4 RID: 76532 RVA: 0x0057C48C File Offset: 0x0057A88C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4E6 RID: 50406
		private float opl_p0;
	}
}
