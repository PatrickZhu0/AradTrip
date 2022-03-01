using System;

namespace behaviac
{
	// Token: 0x02003EA1 RID: 16033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node4 : Condition
	{
		// Token: 0x060164C1 RID: 91329 RVA: 0x006BE46B File Offset: 0x006BC86B
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Event_node4()
		{
			this.opl_p0 = 7287;
		}

		// Token: 0x060164C2 RID: 91330 RVA: 0x006BE480 File Offset: 0x006BC880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCF4 RID: 64756
		private int opl_p0;
	}
}
