using System;

namespace behaviac
{
	// Token: 0x02002092 RID: 8338
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node12 : Condition
	{
		// Token: 0x06012ABC RID: 76476 RVA: 0x0057AF6A File Offset: 0x0057936A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node12()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06012ABD RID: 76477 RVA: 0x0057AF80 File Offset: 0x00579380
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4AF RID: 50351
		private float opl_p0;
	}
}
