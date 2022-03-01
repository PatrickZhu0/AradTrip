using System;

namespace behaviac
{
	// Token: 0x020036D6 RID: 14038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5 : Condition
	{
		// Token: 0x060155C2 RID: 87490 RVA: 0x00671C41 File Offset: 0x00670041
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThanOrEqualTo;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x060155C3 RID: 87491 RVA: 0x00671C64 File Offset: 0x00670064
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF93 RID: 61331
		private HMType opl_p0;

		// Token: 0x0400EF94 RID: 61332
		private BE_Operation opl_p1;

		// Token: 0x0400EF95 RID: 61333
		private float opl_p2;
	}
}
