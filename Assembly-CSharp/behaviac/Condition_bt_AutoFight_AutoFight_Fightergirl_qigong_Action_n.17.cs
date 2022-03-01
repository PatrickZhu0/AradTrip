using System;

namespace behaviac
{
	// Token: 0x02001F08 RID: 7944
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node26 : Condition
	{
		// Token: 0x060127B4 RID: 75700 RVA: 0x00568375 File Offset: 0x00566775
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node26()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060127B5 RID: 75701 RVA: 0x00568388 File Offset: 0x00566788
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1AB RID: 49579
		private float opl_p0;
	}
}
