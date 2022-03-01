using System;

namespace behaviac
{
	// Token: 0x0200210A RID: 8458
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node12 : Condition
	{
		// Token: 0x06012BA7 RID: 76711 RVA: 0x00580C7A File Offset: 0x0057F07A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node12()
		{
			this.opl_p0 = 0.34f;
		}

		// Token: 0x06012BA8 RID: 76712 RVA: 0x00580C90 File Offset: 0x0057F090
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C59A RID: 50586
		private float opl_p0;
	}
}
