using System;

namespace behaviac
{
	// Token: 0x02002142 RID: 8514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node32 : Condition
	{
		// Token: 0x06012C16 RID: 76822 RVA: 0x00583266 File Offset: 0x00581666
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node32()
		{
			this.opl_p0 = 0.27f;
		}

		// Token: 0x06012C17 RID: 76823 RVA: 0x0058327C File Offset: 0x0058167C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C609 RID: 50697
		private float opl_p0;
	}
}
