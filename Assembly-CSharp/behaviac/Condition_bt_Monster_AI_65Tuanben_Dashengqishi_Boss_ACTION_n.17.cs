using System;

namespace behaviac
{
	// Token: 0x02002DA1 RID: 11681
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node39 : Condition
	{
		// Token: 0x06014423 RID: 82979 RVA: 0x00615E4B File Offset: 0x0061424B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node39()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x06014424 RID: 82980 RVA: 0x00615E6C File Offset: 0x0061426C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE9 RID: 56809
		private HMType opl_p0;

		// Token: 0x0400DDEA RID: 56810
		private BE_Operation opl_p1;

		// Token: 0x0400DDEB RID: 56811
		private float opl_p2;
	}
}
