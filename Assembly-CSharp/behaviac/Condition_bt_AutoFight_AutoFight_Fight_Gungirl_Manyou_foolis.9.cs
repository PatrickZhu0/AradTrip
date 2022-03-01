using System;

namespace behaviac
{
	// Token: 0x02001FF6 RID: 8182
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node17 : Condition
	{
		// Token: 0x06012988 RID: 76168 RVA: 0x0057374E File Offset: 0x00571B4E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node17()
		{
			this.opl_p0 = 0.24f;
		}

		// Token: 0x06012989 RID: 76169 RVA: 0x00573764 File Offset: 0x00571B64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C37B RID: 50043
		private float opl_p0;
	}
}
