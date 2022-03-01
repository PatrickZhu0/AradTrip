using System;

namespace behaviac
{
	// Token: 0x02002CED RID: 11501
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node27 : Condition
	{
		// Token: 0x060142CA RID: 82634 RVA: 0x0060EFAE File Offset: 0x0060D3AE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node27()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060142CB RID: 82635 RVA: 0x0060EFD0 File Offset: 0x0060D3D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC77 RID: 56439
		private HMType opl_p0;

		// Token: 0x0400DC78 RID: 56440
		private BE_Operation opl_p1;

		// Token: 0x0400DC79 RID: 56441
		private float opl_p2;
	}
}
