using System;

namespace behaviac
{
	// Token: 0x02001F15 RID: 7957
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node37 : Condition
	{
		// Token: 0x060127CE RID: 75726 RVA: 0x005688ED File Offset: 0x00566CED
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node37()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060127CF RID: 75727 RVA: 0x00568900 File Offset: 0x00566D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1C6 RID: 49606
		private float opl_p0;
	}
}
