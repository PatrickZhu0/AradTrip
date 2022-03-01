using System;

namespace behaviac
{
	// Token: 0x02002D2D RID: 11565
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node2 : Condition
	{
		// Token: 0x06014343 RID: 82755 RVA: 0x00611C5E File Offset: 0x0061005E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521978;
		}

		// Token: 0x06014344 RID: 82756 RVA: 0x00611C80 File Offset: 0x00610080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD02 RID: 56578
		private BE_Target opl_p0;

		// Token: 0x0400DD03 RID: 56579
		private BE_Equal opl_p1;

		// Token: 0x0400DD04 RID: 56580
		private int opl_p2;
	}
}
