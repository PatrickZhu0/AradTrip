using System;

namespace behaviac
{
	// Token: 0x02002072 RID: 8306
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node22 : Condition
	{
		// Token: 0x06012A7D RID: 76413 RVA: 0x0057942A File Offset: 0x0057782A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node22()
		{
			this.opl_p0 = -2.24f;
		}

		// Token: 0x06012A7E RID: 76414 RVA: 0x00579440 File Offset: 0x00577840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C470 RID: 50288
		private float opl_p0;
	}
}
