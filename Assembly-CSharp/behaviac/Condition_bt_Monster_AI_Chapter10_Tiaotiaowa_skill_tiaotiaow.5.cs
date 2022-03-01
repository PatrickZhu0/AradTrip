using System;

namespace behaviac
{
	// Token: 0x020030D2 RID: 12498
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2 : Condition
	{
		// Token: 0x06014A5C RID: 84572 RVA: 0x00637BBE File Offset: 0x00635FBE
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.1f;
		}

		// Token: 0x06014A5D RID: 84573 RVA: 0x00637BE0 File Offset: 0x00635FE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3C2 RID: 58306
		private HMType opl_p0;

		// Token: 0x0400E3C3 RID: 58307
		private BE_Operation opl_p1;

		// Token: 0x0400E3C4 RID: 58308
		private float opl_p2;
	}
}
