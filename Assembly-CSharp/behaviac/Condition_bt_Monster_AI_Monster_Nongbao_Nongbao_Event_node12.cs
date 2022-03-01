using System;

namespace behaviac
{
	// Token: 0x020036DD RID: 14045
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node12 : Condition
	{
		// Token: 0x060155D0 RID: 87504 RVA: 0x00671F4A File Offset: 0x0067034A
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060155D1 RID: 87505 RVA: 0x00671F6C File Offset: 0x0067036C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFA2 RID: 61346
		private HMType opl_p0;

		// Token: 0x0400EFA3 RID: 61347
		private BE_Operation opl_p1;

		// Token: 0x0400EFA4 RID: 61348
		private float opl_p2;
	}
}
