using System;

namespace behaviac
{
	// Token: 0x02002E23 RID: 11811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node180 : Condition
	{
		// Token: 0x06014523 RID: 83235 RVA: 0x0061A372 File Offset: 0x00618772
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node180()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x06014524 RID: 83236 RVA: 0x0061A394 File Offset: 0x00618794
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DECB RID: 57035
		private BE_Target opl_p0;

		// Token: 0x0400DECC RID: 57036
		private BE_Equal opl_p1;

		// Token: 0x0400DECD RID: 57037
		private int opl_p2;
	}
}
