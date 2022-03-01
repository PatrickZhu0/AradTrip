using System;

namespace behaviac
{
	// Token: 0x02001F10 RID: 7952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node10 : Condition
	{
		// Token: 0x060127C4 RID: 75716 RVA: 0x005686DD File Offset: 0x00566ADD
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node10()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060127C5 RID: 75717 RVA: 0x005686F0 File Offset: 0x00566AF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1BB RID: 49595
		private float opl_p0;
	}
}
