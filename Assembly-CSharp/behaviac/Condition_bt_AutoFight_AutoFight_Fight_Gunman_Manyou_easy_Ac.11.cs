using System;

namespace behaviac
{
	// Token: 0x02002116 RID: 8470
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node27 : Condition
	{
		// Token: 0x06012BBF RID: 76735 RVA: 0x005812AE File Offset: 0x0057F6AE
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node27()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012BC0 RID: 76736 RVA: 0x005812C4 File Offset: 0x0057F6C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5B2 RID: 50610
		private float opl_p0;
	}
}
