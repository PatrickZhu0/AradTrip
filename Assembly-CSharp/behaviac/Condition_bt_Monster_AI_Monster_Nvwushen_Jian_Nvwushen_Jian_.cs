using System;

namespace behaviac
{
	// Token: 0x020036E5 RID: 14053
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node1 : Condition
	{
		// Token: 0x060155DF RID: 87519 RVA: 0x006726B2 File Offset: 0x00670AB2
		public Condition_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521696;
		}

		// Token: 0x060155E0 RID: 87520 RVA: 0x006726D4 File Offset: 0x00670AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFB1 RID: 61361
		private BE_Target opl_p0;

		// Token: 0x0400EFB2 RID: 61362
		private BE_Equal opl_p1;

		// Token: 0x0400EFB3 RID: 61363
		private int opl_p2;
	}
}
