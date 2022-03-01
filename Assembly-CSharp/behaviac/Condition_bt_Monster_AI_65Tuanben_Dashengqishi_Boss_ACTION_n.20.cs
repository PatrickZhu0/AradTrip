using System;

namespace behaviac
{
	// Token: 0x02002DA6 RID: 11686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node53 : Condition
	{
		// Token: 0x0601442D RID: 82989 RVA: 0x00616010 File Offset: 0x00614410
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node53()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.7f;
		}

		// Token: 0x0601442E RID: 82990 RVA: 0x00616034 File Offset: 0x00614434
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDF1 RID: 56817
		private HMType opl_p0;

		// Token: 0x0400DDF2 RID: 56818
		private BE_Operation opl_p1;

		// Token: 0x0400DDF3 RID: 56819
		private float opl_p2;
	}
}
