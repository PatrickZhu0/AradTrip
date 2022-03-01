using System;

namespace behaviac
{
	// Token: 0x02002E18 RID: 11800
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node160 : Condition
	{
		// Token: 0x0601450D RID: 83213 RVA: 0x00619E23 File Offset: 0x00618223
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node160()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.9f;
		}

		// Token: 0x0601450E RID: 83214 RVA: 0x00619E44 File Offset: 0x00618244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEB1 RID: 57009
		private HMType opl_p0;

		// Token: 0x0400DEB2 RID: 57010
		private BE_Operation opl_p1;

		// Token: 0x0400DEB3 RID: 57011
		private float opl_p2;
	}
}
