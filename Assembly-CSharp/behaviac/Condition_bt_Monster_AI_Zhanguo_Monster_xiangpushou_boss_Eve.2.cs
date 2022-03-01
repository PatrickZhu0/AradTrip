using System;

namespace behaviac
{
	// Token: 0x02003F00 RID: 16128
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_xiangpushou_boss_Event_node2 : Condition
	{
		// Token: 0x06016576 RID: 91510 RVA: 0x006C25A7 File Offset: 0x006C09A7
		public Condition_bt_Monster_AI_Zhanguo_Monster_xiangpushou_boss_Event_node2()
		{
			this.opl_p0 = 7358;
		}

		// Token: 0x06016577 RID: 91511 RVA: 0x006C25BC File Offset: 0x006C09BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD92 RID: 64914
		private int opl_p0;
	}
}
