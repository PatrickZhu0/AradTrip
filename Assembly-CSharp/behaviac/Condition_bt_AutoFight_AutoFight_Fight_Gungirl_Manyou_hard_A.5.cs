using System;

namespace behaviac
{
	// Token: 0x0200201A RID: 8218
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node12 : Condition
	{
		// Token: 0x060129CF RID: 76239 RVA: 0x0057540A File Offset: 0x0057380A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node12()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060129D0 RID: 76240 RVA: 0x00575420 File Offset: 0x00573820
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3C2 RID: 50114
		private float opl_p0;
	}
}
