using System;

namespace behaviac
{
	// Token: 0x020036D9 RID: 14041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8 : Condition
	{
		// Token: 0x060155C8 RID: 87496 RVA: 0x00671D96 File Offset: 0x00670196
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.75f;
		}

		// Token: 0x060155C9 RID: 87497 RVA: 0x00671DB8 File Offset: 0x006701B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF99 RID: 61337
		private HMType opl_p0;

		// Token: 0x0400EF9A RID: 61338
		private BE_Operation opl_p1;

		// Token: 0x0400EF9B RID: 61339
		private float opl_p2;
	}
}
