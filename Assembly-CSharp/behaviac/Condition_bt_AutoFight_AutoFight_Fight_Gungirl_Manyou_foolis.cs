using System;

namespace behaviac
{
	// Token: 0x02001FE7 RID: 8167
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node51 : Condition
	{
		// Token: 0x0601296A RID: 76138 RVA: 0x00573006 File Offset: 0x00571406
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node51()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601296B RID: 76139 RVA: 0x0057301C File Offset: 0x0057141C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C35C RID: 50012
		private float opl_p0;
	}
}
