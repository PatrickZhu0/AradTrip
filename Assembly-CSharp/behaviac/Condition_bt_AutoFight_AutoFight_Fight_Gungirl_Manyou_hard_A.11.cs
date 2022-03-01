using System;

namespace behaviac
{
	// Token: 0x02002026 RID: 8230
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node27 : Condition
	{
		// Token: 0x060129E7 RID: 76263 RVA: 0x00575A3E File Offset: 0x00573E3E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node27()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060129E8 RID: 76264 RVA: 0x00575A54 File Offset: 0x00573E54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3DA RID: 50138
		private float opl_p0;
	}
}
