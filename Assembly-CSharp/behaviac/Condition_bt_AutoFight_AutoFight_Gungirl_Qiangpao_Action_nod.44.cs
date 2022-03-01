using System;

namespace behaviac
{
	// Token: 0x0200254D RID: 9549
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node85 : Condition
	{
		// Token: 0x060133E3 RID: 78819 RVA: 0x005B745D File Offset: 0x005B585D
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node85()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133E4 RID: 78820 RVA: 0x005B7470 File Offset: 0x005B5870
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE0B RID: 52747
		private float opl_p0;
	}
}
