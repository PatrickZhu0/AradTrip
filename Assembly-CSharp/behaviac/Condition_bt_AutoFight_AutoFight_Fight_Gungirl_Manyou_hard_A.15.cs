using System;

namespace behaviac
{
	// Token: 0x0200202E RID: 8238
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node37 : Condition
	{
		// Token: 0x060129F7 RID: 76279 RVA: 0x00575D76 File Offset: 0x00574176
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node37()
		{
			this.opl_p0 = 0.83f;
		}

		// Token: 0x060129F8 RID: 76280 RVA: 0x00575D8C File Offset: 0x0057418C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3EA RID: 50154
		private float opl_p0;
	}
}
