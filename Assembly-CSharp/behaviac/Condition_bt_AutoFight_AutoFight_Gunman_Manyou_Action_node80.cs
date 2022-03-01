using System;

namespace behaviac
{
	// Token: 0x02002629 RID: 9769
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node80 : Condition
	{
		// Token: 0x06013598 RID: 79256 RVA: 0x005C1772 File Offset: 0x005BFB72
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node80()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x06013599 RID: 79257 RVA: 0x005C1788 File Offset: 0x005BFB88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFE6 RID: 53222
		private float opl_p0;
	}
}
