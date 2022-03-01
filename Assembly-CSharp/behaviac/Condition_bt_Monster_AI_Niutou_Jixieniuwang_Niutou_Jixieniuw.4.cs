using System;

namespace behaviac
{
	// Token: 0x020036FD RID: 14077
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node11 : Condition
	{
		// Token: 0x06015609 RID: 87561 RVA: 0x006730C1 File Offset: 0x006714C1
		public Condition_bt_Monster_AI_Niutou_Jixieniuwang_Niutou_Jixieniuwang_Zhaohuan_wudi_node11()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.35f;
		}

		// Token: 0x0601560A RID: 87562 RVA: 0x006730E4 File Offset: 0x006714E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFCE RID: 61390
		private HMType opl_p0;

		// Token: 0x0400EFCF RID: 61391
		private BE_Operation opl_p1;

		// Token: 0x0400EFD0 RID: 61392
		private float opl_p2;
	}
}
