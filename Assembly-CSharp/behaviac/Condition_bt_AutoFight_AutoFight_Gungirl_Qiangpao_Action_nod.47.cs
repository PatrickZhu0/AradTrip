using System;

namespace behaviac
{
	// Token: 0x02002551 RID: 9553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node89 : Condition
	{
		// Token: 0x060133EB RID: 78827 RVA: 0x005B7611 File Offset: 0x005B5A11
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node89()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060133EC RID: 78828 RVA: 0x005B7624 File Offset: 0x005B5A24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE13 RID: 52755
		private float opl_p0;
	}
}
