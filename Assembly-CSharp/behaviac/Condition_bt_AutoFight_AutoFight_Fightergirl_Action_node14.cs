using System;

namespace behaviac
{
	// Token: 0x02001EE2 RID: 7906
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node14 : Condition
	{
		// Token: 0x06012769 RID: 75625 RVA: 0x005668B9 File Offset: 0x00564CB9
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node14()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601276A RID: 75626 RVA: 0x005668CC File Offset: 0x00564CCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C15E RID: 49502
		private float opl_p0;
	}
}
