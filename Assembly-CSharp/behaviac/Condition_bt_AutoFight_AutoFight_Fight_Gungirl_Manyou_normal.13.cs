using System;

namespace behaviac
{
	// Token: 0x02002052 RID: 8274
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node32 : Condition
	{
		// Token: 0x06012A3E RID: 76350 RVA: 0x005779F6 File Offset: 0x00575DF6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node32()
		{
			this.opl_p0 = 0.61f;
		}

		// Token: 0x06012A3F RID: 76351 RVA: 0x00577A0C File Offset: 0x00575E0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C431 RID: 50225
		private float opl_p0;
	}
}
