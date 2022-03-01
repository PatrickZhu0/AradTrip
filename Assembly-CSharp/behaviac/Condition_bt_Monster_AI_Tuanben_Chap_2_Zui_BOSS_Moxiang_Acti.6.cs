using System;

namespace behaviac
{
	// Token: 0x02003751 RID: 14161
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node24 : Condition
	{
		// Token: 0x060156A9 RID: 87721 RVA: 0x0067628E File Offset: 0x0067468E
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node24()
		{
			this.opl_p0 = 0.33f;
		}

		// Token: 0x060156AA RID: 87722 RVA: 0x006762A4 File Offset: 0x006746A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F081 RID: 61569
		private float opl_p0;
	}
}
