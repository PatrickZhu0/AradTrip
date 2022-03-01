using System;

namespace behaviac
{
	// Token: 0x02002006 RID: 8198
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node37 : Condition
	{
		// Token: 0x060129A8 RID: 76200 RVA: 0x00573E6E File Offset: 0x0057226E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node37()
		{
			this.opl_p0 = 0.29f;
		}

		// Token: 0x060129A9 RID: 76201 RVA: 0x00573E84 File Offset: 0x00572284
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C39B RID: 50075
		private float opl_p0;
	}
}
