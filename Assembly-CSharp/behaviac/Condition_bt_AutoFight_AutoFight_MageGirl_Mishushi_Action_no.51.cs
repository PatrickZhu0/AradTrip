using System;

namespace behaviac
{
	// Token: 0x020026F3 RID: 9971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node70 : Condition
	{
		// Token: 0x06013729 RID: 79657 RVA: 0x005CA2A9 File Offset: 0x005C86A9
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node70()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601372A RID: 79658 RVA: 0x005CA2BC File Offset: 0x005C86BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D181 RID: 53633
		private float opl_p0;
	}
}
