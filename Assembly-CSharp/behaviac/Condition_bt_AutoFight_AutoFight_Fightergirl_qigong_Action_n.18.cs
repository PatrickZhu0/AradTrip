using System;

namespace behaviac
{
	// Token: 0x02001F09 RID: 7945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node27 : Condition
	{
		// Token: 0x060127B6 RID: 75702 RVA: 0x005683BB File Offset: 0x005667BB
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node27()
		{
			this.opl_p0 = 3113;
		}

		// Token: 0x060127B7 RID: 75703 RVA: 0x005683D0 File Offset: 0x005667D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1AC RID: 49580
		private int opl_p0;
	}
}
