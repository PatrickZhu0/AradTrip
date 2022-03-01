using System;

namespace behaviac
{
	// Token: 0x02002D92 RID: 11666
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node34 : Condition
	{
		// Token: 0x06014405 RID: 82949 RVA: 0x006158E7 File Offset: 0x00613CE7
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node34()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.8f;
		}

		// Token: 0x06014406 RID: 82950 RVA: 0x00615908 File Offset: 0x00613D08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDCE RID: 56782
		private HMType opl_p0;

		// Token: 0x0400DDCF RID: 56783
		private BE_Operation opl_p1;

		// Token: 0x0400DDD0 RID: 56784
		private float opl_p2;
	}
}
