using System;

namespace behaviac
{
	// Token: 0x02002E0A RID: 11786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node126 : Condition
	{
		// Token: 0x060144F1 RID: 83185 RVA: 0x006197F1 File Offset: 0x00617BF1
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node126()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x060144F2 RID: 83186 RVA: 0x00619814 File Offset: 0x00617C14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE98 RID: 56984
		private BE_Target opl_p0;

		// Token: 0x0400DE99 RID: 56985
		private BE_Equal opl_p1;

		// Token: 0x0400DE9A RID: 56986
		private int opl_p2;
	}
}
