using System;

namespace behaviac
{
	// Token: 0x0200260F RID: 9743
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node52 : Condition
	{
		// Token: 0x06013564 RID: 79204 RVA: 0x005C0BA2 File Offset: 0x005BEFA2
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node52()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06013565 RID: 79205 RVA: 0x005C0BB8 File Offset: 0x005BEFB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB0 RID: 53168
		private float opl_p0;
	}
}
