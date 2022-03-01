using System;

namespace behaviac
{
	// Token: 0x02003EA0 RID: 16032
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node3 : Condition
	{
		// Token: 0x060164BF RID: 91327 RVA: 0x006BE423 File Offset: 0x006BC823
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node3()
		{
			this.opl_p0 = 7287;
		}

		// Token: 0x060164C0 RID: 91328 RVA: 0x006BE438 File Offset: 0x006BC838
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCF3 RID: 64755
		private int opl_p0;
	}
}
