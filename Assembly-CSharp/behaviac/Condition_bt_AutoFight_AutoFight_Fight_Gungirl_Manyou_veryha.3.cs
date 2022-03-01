using System;

namespace behaviac
{
	// Token: 0x02002066 RID: 8294
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node7 : Condition
	{
		// Token: 0x06012A65 RID: 76389 RVA: 0x00578EA6 File Offset: 0x005772A6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node7()
		{
			this.opl_p0 = 0.67f;
		}

		// Token: 0x06012A66 RID: 76390 RVA: 0x00578EBC File Offset: 0x005772BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C458 RID: 50264
		private float opl_p0;
	}
}
