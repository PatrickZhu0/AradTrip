using System;

namespace behaviac
{
	// Token: 0x020025FB RID: 9723
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node11 : Condition
	{
		// Token: 0x0601353C RID: 79164 RVA: 0x005C0276 File Offset: 0x005BE676
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node11()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601353D RID: 79165 RVA: 0x005C028C File Offset: 0x005BE68C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF84 RID: 53124
		private float opl_p0;
	}
}
