using System;

namespace behaviac
{
	// Token: 0x02002635 RID: 9781
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node32 : Condition
	{
		// Token: 0x060135B0 RID: 79280 RVA: 0x005C1C8E File Offset: 0x005C008E
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node32()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x060135B1 RID: 79281 RVA: 0x005C1CA4 File Offset: 0x005C00A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFFE RID: 53246
		private float opl_p0;
	}
}
