using System;

namespace behaviac
{
	// Token: 0x02002086 RID: 8326
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node47 : Condition
	{
		// Token: 0x06012AA5 RID: 76453 RVA: 0x00579E4E File Offset: 0x0057824E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node47()
		{
			this.opl_p0 = 0.83f;
		}

		// Token: 0x06012AA6 RID: 76454 RVA: 0x00579E64 File Offset: 0x00578264
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C498 RID: 50328
		private float opl_p0;
	}
}
