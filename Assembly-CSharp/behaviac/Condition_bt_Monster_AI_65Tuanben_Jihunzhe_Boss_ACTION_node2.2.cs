using System;

namespace behaviac
{
	// Token: 0x02002F11 RID: 12049
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node21 : Condition
	{
		// Token: 0x060146F9 RID: 83705 RVA: 0x00625A03 File Offset: 0x00623E03
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node21()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x060146FA RID: 83706 RVA: 0x00625A24 File Offset: 0x00623E24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E06F RID: 57455
		private HMType opl_p0;

		// Token: 0x0400E070 RID: 57456
		private BE_Operation opl_p1;

		// Token: 0x0400E071 RID: 57457
		private float opl_p2;
	}
}
