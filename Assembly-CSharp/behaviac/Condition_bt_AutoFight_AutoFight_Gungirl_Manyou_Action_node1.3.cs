using System;

namespace behaviac
{
	// Token: 0x02002501 RID: 9473
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node14 : Condition
	{
		// Token: 0x0601334C RID: 78668 RVA: 0x005B3B42 File Offset: 0x005B1F42
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node14()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601334D RID: 78669 RVA: 0x005B3B58 File Offset: 0x005B1F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD6C RID: 52588
		private float opl_p0;
	}
}
