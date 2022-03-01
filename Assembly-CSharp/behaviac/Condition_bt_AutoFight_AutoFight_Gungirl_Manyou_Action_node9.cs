using System;

namespace behaviac
{
	// Token: 0x020024CD RID: 9421
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node90 : Condition
	{
		// Token: 0x060132E4 RID: 78564 RVA: 0x005B2143 File Offset: 0x005B0543
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node90()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060132E5 RID: 78565 RVA: 0x005B2158 File Offset: 0x005B0558
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD03 RID: 52483
		private float opl_p0;
	}
}
