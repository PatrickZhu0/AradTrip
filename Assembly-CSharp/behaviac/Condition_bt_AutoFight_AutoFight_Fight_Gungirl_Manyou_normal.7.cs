using System;

namespace behaviac
{
	// Token: 0x02002046 RID: 8262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node17 : Condition
	{
		// Token: 0x06012A26 RID: 76326 RVA: 0x00577472 File Offset: 0x00575872
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node17()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012A27 RID: 76327 RVA: 0x00577488 File Offset: 0x00575888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C419 RID: 50201
		private float opl_p0;
	}
}
