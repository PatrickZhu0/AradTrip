using System;

namespace behaviac
{
	// Token: 0x02002082 RID: 8322
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node42 : Condition
	{
		// Token: 0x06012A9D RID: 76445 RVA: 0x00579CB3 File Offset: 0x005780B3
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node42()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012A9E RID: 76446 RVA: 0x00579CC8 File Offset: 0x005780C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C490 RID: 50320
		private float opl_p0;
	}
}
