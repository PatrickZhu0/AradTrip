using System;

namespace behaviac
{
	// Token: 0x0200201E RID: 8222
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node17 : Condition
	{
		// Token: 0x060129D7 RID: 76247 RVA: 0x00575656 File Offset: 0x00573A56
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node17()
		{
			this.opl_p0 = 0.73f;
		}

		// Token: 0x060129D8 RID: 76248 RVA: 0x0057566C File Offset: 0x00573A6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3CA RID: 50122
		private float opl_p0;
	}
}
