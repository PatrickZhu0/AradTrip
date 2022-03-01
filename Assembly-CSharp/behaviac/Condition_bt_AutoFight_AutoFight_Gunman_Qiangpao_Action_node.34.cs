using System;

namespace behaviac
{
	// Token: 0x0200266A RID: 9834
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node45 : Condition
	{
		// Token: 0x06013619 RID: 79385 RVA: 0x005C47F5 File Offset: 0x005C2BF5
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node45()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x0601361A RID: 79386 RVA: 0x005C4808 File Offset: 0x005C2C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D06D RID: 53357
		private float opl_p0;
	}
}
