using System;

namespace behaviac
{
	// Token: 0x02003EA6 RID: 16038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node21 : Condition
	{
		// Token: 0x060164CA RID: 91338 RVA: 0x006BE753 File Offset: 0x006BCB53
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node21()
		{
			this.opl_p0 = 7328;
		}

		// Token: 0x060164CB RID: 91339 RVA: 0x006BE768 File Offset: 0x006BCB68
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCFC RID: 64764
		private int opl_p0;
	}
}
