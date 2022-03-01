using System;

namespace behaviac
{
	// Token: 0x02003A12 RID: 14866
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node17 : Condition
	{
		// Token: 0x06015BF0 RID: 89072 RVA: 0x006918B9 File Offset: 0x0068FCB9
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_GongmenChushou01_ACTION_node17()
		{
			this.opl_p0 = 21175;
		}

		// Token: 0x06015BF1 RID: 89073 RVA: 0x006918CC File Offset: 0x0068FCCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F50D RID: 62733
		private int opl_p0;
	}
}
