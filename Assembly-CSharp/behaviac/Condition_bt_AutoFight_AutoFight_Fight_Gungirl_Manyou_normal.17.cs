using System;

namespace behaviac
{
	// Token: 0x0200205A RID: 8282
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node42 : Condition
	{
		// Token: 0x06012A4E RID: 76366 RVA: 0x00577E3A File Offset: 0x0057623A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node42()
		{
			this.opl_p0 = 0.67f;
		}

		// Token: 0x06012A4F RID: 76367 RVA: 0x00577E50 File Offset: 0x00576250
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C441 RID: 50241
		private float opl_p0;
	}
}
