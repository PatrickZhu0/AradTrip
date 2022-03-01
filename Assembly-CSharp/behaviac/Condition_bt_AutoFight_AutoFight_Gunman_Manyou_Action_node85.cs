using System;

namespace behaviac
{
	// Token: 0x02002639 RID: 9785
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node85 : Condition
	{
		// Token: 0x060135B8 RID: 79288 RVA: 0x005C1E42 File Offset: 0x005C0242
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node85()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060135B9 RID: 79289 RVA: 0x005C1E58 File Offset: 0x005C0258
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D006 RID: 53254
		private float opl_p0;
	}
}
