using System;

namespace behaviac
{
	// Token: 0x02002122 RID: 8482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node42 : Condition
	{
		// Token: 0x06012BD7 RID: 76759 RVA: 0x0058188E File Offset: 0x0057FC8E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node42()
		{
			this.opl_p0 = 0.41f;
		}

		// Token: 0x06012BD8 RID: 76760 RVA: 0x005818A4 File Offset: 0x0057FCA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5CA RID: 50634
		private float opl_p0;
	}
}
