using System;

namespace behaviac
{
	// Token: 0x020036D7 RID: 14039
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6 : Condition
	{
		// Token: 0x060155C4 RID: 87492 RVA: 0x00671CA3 File Offset: 0x006700A3
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6()
		{
			this.opl_p0 = 20349;
		}

		// Token: 0x060155C5 RID: 87493 RVA: 0x00671CB8 File Offset: 0x006700B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF96 RID: 61334
		private int opl_p0;
	}
}
