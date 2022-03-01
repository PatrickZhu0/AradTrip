using System;

namespace behaviac
{
	// Token: 0x02001F1C RID: 7964
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node48 : Condition
	{
		// Token: 0x060127DC RID: 75740 RVA: 0x00568D7D File Offset: 0x0056717D
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node48()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060127DD RID: 75741 RVA: 0x00568D90 File Offset: 0x00567190
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1D5 RID: 49621
		private float opl_p0;
	}
}
