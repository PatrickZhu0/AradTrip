using System;

namespace behaviac
{
	// Token: 0x02003EAF RID: 16047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node11 : Condition
	{
		// Token: 0x060164DC RID: 91356 RVA: 0x006BEB3B File Offset: 0x006BCF3B
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node11()
		{
			this.opl_p0 = 7284;
		}

		// Token: 0x060164DD RID: 91357 RVA: 0x006BEB50 File Offset: 0x006BCF50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD10 RID: 64784
		private int opl_p0;
	}
}
