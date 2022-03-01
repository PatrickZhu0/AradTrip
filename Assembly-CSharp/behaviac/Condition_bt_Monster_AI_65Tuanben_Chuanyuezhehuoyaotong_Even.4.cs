using System;

namespace behaviac
{
	// Token: 0x02002D58 RID: 11608
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9 : Condition
	{
		// Token: 0x06014393 RID: 82835 RVA: 0x006133C3 File Offset: 0x006117C3
		public Condition_bt_Monster_AI_65Tuanben_Chuanyuezhehuoyaotong_Event_node9()
		{
			this.opl_p0 = 21854;
		}

		// Token: 0x06014394 RID: 82836 RVA: 0x006133D8 File Offset: 0x006117D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD5F RID: 56671
		private int opl_p0;
	}
}
