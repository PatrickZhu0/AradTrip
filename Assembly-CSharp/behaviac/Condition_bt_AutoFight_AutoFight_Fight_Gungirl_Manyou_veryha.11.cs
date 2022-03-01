using System;

namespace behaviac
{
	// Token: 0x02002076 RID: 8310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node27 : Condition
	{
		// Token: 0x06012A85 RID: 76421 RVA: 0x00579676 File Offset: 0x00577A76
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node27()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012A86 RID: 76422 RVA: 0x0057968C File Offset: 0x00577A8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C478 RID: 50296
		private float opl_p0;
	}
}
