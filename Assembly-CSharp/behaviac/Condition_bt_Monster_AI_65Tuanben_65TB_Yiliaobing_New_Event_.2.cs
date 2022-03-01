using System;

namespace behaviac
{
	// Token: 0x02002D2A RID: 11562
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node10 : Condition
	{
		// Token: 0x0601433D RID: 82749 RVA: 0x00611B8A File Offset: 0x0060FF8A
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521982;
		}

		// Token: 0x0601433E RID: 82750 RVA: 0x00611BAC File Offset: 0x0060FFAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCFB RID: 56571
		private BE_Target opl_p0;

		// Token: 0x0400DCFC RID: 56572
		private BE_Equal opl_p1;

		// Token: 0x0400DCFD RID: 56573
		private int opl_p2;
	}
}
