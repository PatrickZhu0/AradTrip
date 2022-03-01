using System;

namespace behaviac
{
	// Token: 0x02001FDF RID: 8159
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node42 : Condition
	{
		// Token: 0x0601295B RID: 76123 RVA: 0x00572136 File Offset: 0x00570536
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node42()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x0601295C RID: 76124 RVA: 0x0057214C File Offset: 0x0057054C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C34D RID: 49997
		private float opl_p0;
	}
}
