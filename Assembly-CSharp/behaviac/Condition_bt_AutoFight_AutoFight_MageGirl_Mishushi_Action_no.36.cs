using System;

namespace behaviac
{
	// Token: 0x020026DF RID: 9951
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node9 : Condition
	{
		// Token: 0x06013701 RID: 79617 RVA: 0x005C9A25 File Offset: 0x005C7E25
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node9()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06013702 RID: 79618 RVA: 0x005C9A38 File Offset: 0x005C7E38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D159 RID: 53593
		private float opl_p0;
	}
}
