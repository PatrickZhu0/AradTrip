using System;

namespace behaviac
{
	// Token: 0x02001EF8 RID: 7928
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node1 : Condition
	{
		// Token: 0x06012794 RID: 75668 RVA: 0x00567C9B File Offset: 0x0056609B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node1()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06012795 RID: 75669 RVA: 0x00567CB0 File Offset: 0x005660B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C189 RID: 49545
		private float opl_p0;
	}
}
