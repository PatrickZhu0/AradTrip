using System;

namespace behaviac
{
	// Token: 0x02001FFE RID: 8190
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node27 : Condition
	{
		// Token: 0x06012998 RID: 76184 RVA: 0x00573B36 File Offset: 0x00571F36
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node27()
		{
			this.opl_p0 = 0.27f;
		}

		// Token: 0x06012999 RID: 76185 RVA: 0x00573B4C File Offset: 0x00571F4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C38B RID: 50059
		private float opl_p0;
	}
}
