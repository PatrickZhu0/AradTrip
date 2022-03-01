using System;

namespace behaviac
{
	// Token: 0x020026FE RID: 9982
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node25 : Condition
	{
		// Token: 0x0601373F RID: 79679 RVA: 0x005CA74A File Offset: 0x005C8B4A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node25()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013740 RID: 79680 RVA: 0x005CA760 File Offset: 0x005C8B60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D195 RID: 53653
		private float opl_p0;
	}
}
