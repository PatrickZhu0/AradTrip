using System;

namespace behaviac
{
	// Token: 0x02002F13 RID: 12051
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node1 : Condition
	{
		// Token: 0x060146FD RID: 83709 RVA: 0x00625B0E File Offset: 0x00623F0E
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node1()
		{
			this.opl_p0 = 21612;
		}

		// Token: 0x060146FE RID: 83710 RVA: 0x00625B24 File Offset: 0x00623F24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E074 RID: 57460
		private int opl_p0;
	}
}
