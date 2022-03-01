using System;

namespace behaviac
{
	// Token: 0x02002607 RID: 9735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node57 : Condition
	{
		// Token: 0x06013554 RID: 79188 RVA: 0x005C07E2 File Offset: 0x005BEBE2
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node57()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06013555 RID: 79189 RVA: 0x005C07F8 File Offset: 0x005BEBF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFA0 RID: 53152
		private float opl_p0;
	}
}
