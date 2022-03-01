using System;

namespace behaviac
{
	// Token: 0x02001F0C RID: 7948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node24 : Condition
	{
		// Token: 0x060127BC RID: 75708 RVA: 0x00568529 File Offset: 0x00566929
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node24()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060127BD RID: 75709 RVA: 0x0056853C File Offset: 0x0056693C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C1B3 RID: 49587
		private float opl_p0;
	}
}
