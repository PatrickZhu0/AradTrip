using System;

namespace behaviac
{
	// Token: 0x0200202A RID: 8234
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node32 : Condition
	{
		// Token: 0x060129EF RID: 76271 RVA: 0x00575BDA File Offset: 0x00573FDA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node32()
		{
			this.opl_p0 = 0.82f;
		}

		// Token: 0x060129F0 RID: 76272 RVA: 0x00575BF0 File Offset: 0x00573FF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3E2 RID: 50146
		private float opl_p0;
	}
}
