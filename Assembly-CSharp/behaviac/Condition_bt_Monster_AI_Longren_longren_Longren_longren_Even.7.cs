using System;

namespace behaviac
{
	// Token: 0x020035A8 RID: 13736
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node16 : Condition
	{
		// Token: 0x0601537F RID: 86911 RVA: 0x00665273 File Offset: 0x00663673
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node16()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 528401;
		}

		// Token: 0x06015380 RID: 86912 RVA: 0x00665294 File Offset: 0x00663694
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED49 RID: 60745
		private BE_Target opl_p0;

		// Token: 0x0400ED4A RID: 60746
		private BE_Equal opl_p1;

		// Token: 0x0400ED4B RID: 60747
		private int opl_p2;
	}
}
