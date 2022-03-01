using System;

namespace behaviac
{
	// Token: 0x02002E05 RID: 11781
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node102 : Condition
	{
		// Token: 0x060144E7 RID: 83175 RVA: 0x00619639 File Offset: 0x00617A39
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node102()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x060144E8 RID: 83176 RVA: 0x0061965C File Offset: 0x00617A5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE90 RID: 56976
		private HMType opl_p0;

		// Token: 0x0400DE91 RID: 56977
		private BE_Operation opl_p1;

		// Token: 0x0400DE92 RID: 56978
		private float opl_p2;
	}
}
