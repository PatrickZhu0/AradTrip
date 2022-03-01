using System;

namespace behaviac
{
	// Token: 0x0200206A RID: 8298
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node12 : Condition
	{
		// Token: 0x06012A6D RID: 76397 RVA: 0x00579042 File Offset: 0x00577442
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node12()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06012A6E RID: 76398 RVA: 0x00579058 File Offset: 0x00577458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C460 RID: 50272
		private float opl_p0;
	}
}
