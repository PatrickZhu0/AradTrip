using System;

namespace behaviac
{
	// Token: 0x02001ECC RID: 7884
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Event_Chiyao_node2 : Condition
	{
		// Token: 0x0601273E RID: 75582 RVA: 0x00565F20 File Offset: 0x00564320
		public Condition_bt_AutoFight_AutoFight_Event_Chiyao_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x0601273F RID: 75583 RVA: 0x00565F44 File Offset: 0x00564344
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C12B RID: 49451
		private HMType opl_p0;

		// Token: 0x0400C12C RID: 49452
		private BE_Operation opl_p1;

		// Token: 0x0400C12D RID: 49453
		private float opl_p2;
	}
}
